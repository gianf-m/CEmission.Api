using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.LoginAppServices {
    public class LoginResponseDto {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token {  get; set; }
    }
}
