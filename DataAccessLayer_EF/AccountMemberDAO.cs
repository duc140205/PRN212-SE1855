using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF
{
    public class AccountMemberDAO
    {
        MyStoreContext context = new MyStoreContext();
        public AccountMember login(string email, string password)
        {
            return context.AccountMembers
                .FirstOrDefault(x => x.EmailAddress == email && x.MemberPassword == password);
        }
    }
}
