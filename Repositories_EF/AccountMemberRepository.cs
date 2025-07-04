using BusinessObjects_EF;
using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class AccountMemberRepository : IAccountMemberRepository
    {
        AccountMemberDAO accountMemberDAO = new AccountMemberDAO();
        public AccountMember login(string email, string password)
        {
            return accountMemberDAO.login(email, password);
        }
    }
}
