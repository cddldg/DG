using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace DG.Controllers.WebApi
{
    
    public class TokenAuthController : ApiBaseController
    {
        public TokenAuthController()
        {
           
        }

        [HttpGet]
        public string Authenticate()
        {
            var accessToken = "sdfsdfsdfsf";
            var model= new
            {
                AccessToken = accessToken,
                EncryptedAccessToken = "3333",
                ExpireInSeconds = 60,
                UserId = 1
            };
            return model.ToString();
        }
    }
}
