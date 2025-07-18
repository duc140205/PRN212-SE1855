using BusinessObjects_EF_IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF_IO
{
    public class AccountMemberDAO
    {
        MyStoreContext context = new MyStoreContext();
        public AccountMember Login(string email, string password)
        {
            return context.AccountMembers
                .Where(am => am.EmailAddress == email && am.MemberPassword == password)
                .FirstOrDefault();
        }
    }
}
