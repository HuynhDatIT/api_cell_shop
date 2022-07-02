using cell_shop_api.Base.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace cell_shop_api.Base
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var id = httpContextAccessor.HttpContext?.Items["AccountId"];
            
            if (id != null)
                GetCurrentAccountId = Int32.Parse(id.ToString());

        }
        public int GetCurrentAccountId { get; }
    }
}
