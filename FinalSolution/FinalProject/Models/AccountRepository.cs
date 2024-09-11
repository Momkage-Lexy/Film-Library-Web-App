using System.Collections.Generic;
using System.Linq;

namespace FinalProject.Models{

    public static class AccountRepository{
    
        public static List<Account> profile = new List<Account>();

        public static void AddProfile (Account account)
        {
            profile.Add(account);
        }

        public static void RemoveProfile ()
        {
            profile.Clear();
        }
    }
}