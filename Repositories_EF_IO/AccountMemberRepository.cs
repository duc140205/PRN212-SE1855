using BusinessObjects_EF_IO;
using DataAccessLayer_EF_IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF_IO
{
    public class AccountMemberRepository : IAccountMemberRepository
    {
        AccountMemberDAO accountMemberDAO = new AccountMemberDAO();
        public AccountMember Login(string email, string password)
        {
            return accountMemberDAO.Login(email, password);
        }
    }
}
