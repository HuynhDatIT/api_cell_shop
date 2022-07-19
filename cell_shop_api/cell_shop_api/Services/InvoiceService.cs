using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Enum;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly IEmailService _emailService;
        private string role;
        private int _currenAccountId;
        public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;

            role = _claimsService.GetCurrentRole;
            _currenAccountId = _claimsService.GetCurrentAccountId;
            _emailService = emailService;
        }

        private async Task SendEmailAsync(Invoice invoice)
        {
            var emailRequest = _mapper.Map<EmailRequest>(invoice);

            var account = await _unitOfWork.AccountRepository.GetByIdAsync(_currenAccountId);

            emailRequest.AccountName = account.FullName;

            emailRequest.To = account.Email;

            _emailService.SendEmailInvoice(emailRequest);
        }

        public async Task<DeliveryStatus?> CancelInvocieAsync(int invoiceId)
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetByIdAsync(invoiceId);

            if (invoice == null) return null;

            if(role == "user")
            {
                if (invoice.DeliveryStatus == DeliveryStatus.Order)
                {
                    invoice.DeliveryStatus = DeliveryStatus.Cancel;

                    _unitOfWork.InvoiceRepository.Update(invoice);

                    foreach (var invoiceDetail in invoice.InvoiceDetails)
                    {
                        var product = await _unitOfWork.ProductRepository.GetByIdAsync(invoiceDetail.ProductId);

                        if (product == null) continue;

                        product.Stock += invoiceDetail.Quantity;

                        _unitOfWork.ProductRepository.Update(product);
                    }
                    _unitOfWork.SaveChanges();
                }
                try
                {
                    await SendEmailAsync(invoice);
                }
                catch (System.Exception)
                {
                    throw;
                }

                return invoice.DeliveryStatus;
            }
            
            invoice.DeliveryStatus = DeliveryStatus.Cancel;

            _unitOfWork.InvoiceRepository.Update(invoice);

            foreach (var invoiceDetail in invoice.InvoiceDetails)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(invoiceDetail.ProductId);

                if (product == null) continue;

                product.Stock += invoiceDetail.Quantity;

                _unitOfWork.ProductRepository.Update(product);
            }

            _unitOfWork.SaveChanges();
            try
            {
                await SendEmailAsync(invoice);
            }
            catch (System.Exception)
            {
                throw;
            }

            return invoice.DeliveryStatus;
        }

        public async Task<DeliveryStatus?> ChangeStatusInvocie(int invoiceId)
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetByIdAsync(invoiceId);

            if (invoice == null) return null;

            if (((int)invoice.DeliveryStatus) >= 2) 
                return invoice.DeliveryStatus;

            invoice.DeliveryStatus += 1;

            _unitOfWork.InvoiceRepository.Update(invoice);
            
            _unitOfWork.SaveChanges();

            await SendEmailAsync(invoice);

            return invoice.DeliveryStatus;
        }

        public async Task<IEnumerable<GetInvoice>> GetAllAsync()
        {
            var invoices = await _unitOfWork.InvoiceRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GetInvoice>>(invoices);
        }
    }
}
