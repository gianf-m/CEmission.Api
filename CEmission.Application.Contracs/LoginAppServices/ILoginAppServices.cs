using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.LoginAppServices {
    public interface ILoginAppServices {
        Task<LoginResponseDto> Login(LoginRequestDto valLoginRequestDto);
    }
}
