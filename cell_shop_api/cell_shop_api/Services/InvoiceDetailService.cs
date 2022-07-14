using AutoMapper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvoiceDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetInvoiceDetail>> GetInvoiceDetailByInvoiceAsync(int invoiceId)
        {
            var invoice = await _unitOfWork.InvoiceRepository.GetByIdAsync(invoiceId);

            if (invoice == null) return null;

            var invoiceDetails = await _unitOfWork.InvoiceDetailRepository
                                            .GetInvoiceDetailsByInvoiceAsync(invoiceId);

            return _mapper.Map<IList<GetInvoiceDetail>>(invoiceDetails);
        }
    }
}
