using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.IdentityUsers {
    public class IdentityUsersConsts {
        public const int UsernameMinLength = 1;
        public const int UsernameMaxLength = 100;
        
        public const int EmailMinLength = 1;
        public const int EmailMaxLength = 100;
        
        public const int PasswordHashMinLength = 1;
        public const int PasswordHashMaxLength = 2500;
        
        public const int PhoneNumberMinLength = 1;
        public const int PhoneNumberMaxLength = 15;

    }
}
