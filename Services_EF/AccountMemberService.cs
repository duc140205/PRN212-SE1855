using BusinessObjects_EF;
using Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services_EF
{
    public class AccountMemberService : IAccountMemberService
    {
        IAccountMemberRepository repository = new AccountMemberRepository();
        public AccountMemberService()
        {
            repository = new AccountMemberRepository();
        }
        public AccountMember login(string email, string password)
        {
            return repository.login(email, password);
        }
    }
}
