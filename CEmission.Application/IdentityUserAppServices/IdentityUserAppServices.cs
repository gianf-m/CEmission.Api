using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CEmission.Application.AutoMapper;

namespace CEmission.IdentityUsers {
    public class IdentityUserAppServices: IIdentityUserAppServices {
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly Mapper ObjectMapper = MapperConfig.InitializeAutomapper();
        public IdentityUserAppServices(IIdentityUserRepository identityUserRepository) {
            _identityUserRepository = identityUserRepository;
        }

        public virtual async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto valCreateUserDto) {
            IdentityUser vNewUser = new IdentityUser(valCreateUserDto.UserName, valCreateUserDto.Email, valCreateUserDto.Phonenumber, valCreateUserDto.Password);
            await _identityUserRepository.CreateAsync(vNewUser);
            return ObjectMapper.Map<IdentityUserDto>(vNewUser);
        }

        public virtual async Task<IdentityUserDto> GetAsync(Guid valId) {
            return ObjectMapper.Map<IdentityUserDto>(await _identityUserRepository.GetAsync(valId));
        }
    }
}
