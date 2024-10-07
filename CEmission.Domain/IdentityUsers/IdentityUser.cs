using CEmission.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.IdentityUsers {
    public class IdentityUser {
    public virtual Guid Id { get; protected set; }
    public virtual string UserName { get; set; }
    public virtual string NormalizedUserName { get; protected set; }
    public virtual string Email { get; set; }
    public virtual string NormalizedEmail { get; protected set; }
    public virtual string PasswordHash { get; protected set; }
    public virtual string PhoneNumber { get; set; }
        public IdentityUser()
        {
            Id = Guid.NewGuid();
            UserName = string.Empty;
            NormalizedUserName = string.Empty;
            Email = string.Empty;
            NormalizedEmail = string.Empty;
            PasswordHash = string.Empty;
            PhoneNumber = string.Empty;
        }
        public IdentityUser(string username, string email, string phonenumber, string password)
        {
            Id = Guid.NewGuid();
            UserName = username;
            Email = email;
            PhoneNumber= phonenumber;

            NormalizedUserName = username.ToUpper();
            NormalizedEmail= email.ToUpper();

            PasswordHash = Utility.Encriptar(password);

        }
    }
}
