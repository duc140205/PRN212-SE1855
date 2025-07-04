using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public interface IAccountMemberService
    {
        public AccountMember login(string email, string password);
    }
}
