using ACC.Safety;
using DG.Application;
using DG.Application.Member;
using DG.Application.Member.Dtos;
using DG.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Controllers.Api
{
    public class MemberController:BaseApiController
    {
        private IMemberService _memberService;

        public MemberController(IMemberService memberService) 
        {
            
            _memberService = memberService;
        }
        
        
        [HttpPost]
        public MemberOutput Add(AddMemberInput input)
        {
            var p = _memberService.Add(input);
            return p;
        }


        
    }
}
