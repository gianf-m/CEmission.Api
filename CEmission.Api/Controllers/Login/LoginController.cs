using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace CEmission.LoginAppServices {

    [Area("app")]
    [ControllerName("Login")]
    [Route("api/app/login")]
#if DEBUG
    [ApiExplorerSettings(IgnoreApi = false)]
#endif
    public class LoginController : Controller, ILoginAppServices {
        private readonly ILoginAppServices _loginAppServices;
        public LoginController(ILoginAppServices loginAppServices) {
            _loginAppServices = loginAppServices;
        }

        [HttpGet]
        public Task<LoginResponseDto> Login(LoginRequestDto valLoginRequestDto) {
            return _loginAppServices.Login(valLoginRequestDto);
        }


    }
}
