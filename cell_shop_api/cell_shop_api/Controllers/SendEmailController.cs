﻿

using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public SendEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult SendEmail()
        {
            try
            {
                var email = new EmailRequest {

                    DateInvoice = DateTime.Now.ToString(),
                    DeliveryAddress = "sasdsfdjsfsfj",
                    DeliveryName = "huynhdat",
                    DeliveryPhone = "028398",
                    Total = 1234,
                    To = "huynhtandat080297@gmail.com",
                    AccountName = "Huyndhat"
                };
                _emailService.SendEmail(email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
