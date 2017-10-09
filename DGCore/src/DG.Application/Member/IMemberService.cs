using ACC.Application;
using DG.Application.Member.Dtos;
using DG.Core.Entities;
using DG.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Application.Member
{
    public interface IMemberService: IAppService
    {
        MemberOutput Add(AddMemberInput input);
        long Delete(AddMemberInput input);
        long DeleteByKey(long key);
        
    }
}
