﻿using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly IMapper _mapper;
        private int _currenAccountId;

        public OrderService(IUnitOfWork unitOfWork, 
                            IClaimsService claimsService, 
                            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _mapper = mapper;   
        }

        public async Task<bool> CreateOrderAsync(CreateOrder createOrder)
        {
            /* Procces - Step by step
            1. Get AccountId
            2. Create Invoice, Create list InvoiceDetails
            3. Reduce Stock Product
                3.1 - Get productById in list InvoiceDetails
                3.2 - Update Stock
             */
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                // step 1
                _currenAccountId = _claimsService.GetCurrentAccountId;

                var invoice = _mapper.Map<Invoice>(createOrder);

                invoice.AccountId = _currenAccountId;
                // step 2
                await _unitOfWork.InvoiceRepository.AddAsync(invoice);

                await _unitOfWork.SaveChangesAsync();
                //step 3
                foreach (var invoiceDetail in invoice.InvoiceDetails)
                {
                    var product = await _unitOfWork
                                        .ProductRepository
                                        .GetByIdAsync(invoiceDetail.ProductId);

                    product.Stock -= invoiceDetail.Quantity;

                    if (product.Stock < 0)
                        throw new Exception();

                    _unitOfWork.ProductRepository.Update(product);
                }
                 _unitOfWork.SaveChanges();
               
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }      
            

        }
    }
}