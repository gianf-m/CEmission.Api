using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.IdentityUsers {
    public interface IIdentityUserRepository {
        Task<bool> UsernameExist(string valUsername);
        Task CreateAsync(IdentityUser valIdentityUser);
        Task<IdentityUser> GetAsync(Guid valIdentityUserId);
        Task UpdateAsync(IdentityUser valIdentityUser);
        Task<IdentityUser> GetAsync(string valUsername);
    }
}
