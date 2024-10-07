using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using CEmission.IdentityUsers;

namespace CEmission.IdentityUsers {
    [Area("app")]
    [ControllerName("IdentityUser")]
    [Route("api/app/identityUser")]
    [Authorize]
    public class IdentityUserController : Controller, IIdentityUserAppServices {
        private readonly IIdentityUserAppServices _identityUserAppServices;
        public IdentityUserController(IIdentityUserAppServices identityUserAppServices) {
            _identityUserAppServices = identityUserAppServices;
        }

        [HttpPost]
        public Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto valCreateUserDto) {
            return _identityUserAppServices.CreateAsync(valCreateUserDto);
        }


    }

}
