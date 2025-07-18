using BusinessObjects_EF_IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF_IO
{
    public interface IAccountMemberService
    {
        public AccountMember Login(string email, string password);
    }
}
