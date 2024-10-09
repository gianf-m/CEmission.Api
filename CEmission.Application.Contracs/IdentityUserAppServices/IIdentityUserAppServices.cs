using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.IdentityUsers {
    public interface IIdentityUserAppServices {
        Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto valCreateUserDto);
        Task<IdentityUserDto> GetAsync(Guid valId);
    }
}
