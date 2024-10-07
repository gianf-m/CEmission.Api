using CEmission.Domain;
using CEmission.IdentityUsers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utility = CEmission.Domain.Utility;

namespace CEmission.LoginAppServices {
    public class LoginAppServices : ILoginAppServices {
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IConfiguration _configuration;
        public LoginAppServices(IIdentityUserRepository identityUserRepository, IConfiguration configuration) {
            _identityUserRepository = identityUserRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto valLoginRequestDto) {
            LoginResponseDto vResult = new LoginResponseDto();
            bool vUsernameExist = await _identityUserRepository.UsernameExist(valLoginRequestDto.UserName);
            if (!vUsernameExist) {
                vResult.Success = false;
                vResult.Message = "Invalid Username or Password";
                return vResult;
            }

            IdentityUser vUser = await _identityUserRepository.GetAsync(valLoginRequestDto.UserName);
            string vPasswordhash = Utility.Encriptar(valLoginRequestDto.Password);
            if (vUser.PasswordHash != vPasswordhash) {
                vResult.Success = false;
                vResult.Message = "Invalid Username or Password";
                return vResult;
            }

            string vKey = _configuration.GetSection("Jwt:Key").Value;
            string vIssuer = _configuration.GetSection("Jwt:Issuer").Value;
            string vAudience = _configuration.GetSection("Jwt:Audience").Value;
            string vSubject = _configuration.GetSection("Jwt:Subject").Value;

            var claims = GetClaims(vSubject, vUser.Id, vUser.UserName, vUser.Email);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(vKey));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                vIssuer,
                vAudience,
                claims,
                expires: DateTime.Now.AddDays(60),
                signingCredentials: signIn
                );

            vResult.Success = true;
            vResult.Message = "Success";
            vResult.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return vResult;

        }

        private Claim[] GetClaims(string valSubject, Guid valUserId, string valUsername, string valEmail) {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, valSubject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.Now).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim("id", valUserId.ToString()),
                new Claim("username", valUsername),
                new Claim("email", valEmail)
            };
            return claims;
        }


    }
}
