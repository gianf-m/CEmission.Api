using CEmission.IdentityUsers;
using CEmission.LoginAppServices;
using DocumentFormat.OpenXml.Office2013.Excel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;

namespace Testing {
    public class LoginControllerTesting {
        [Fact]
        public async Task Login_Test() {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            var vResponse = await client.GetStringAsync($"/api/app/login?UserName=Master&Password=GenericPw1.");
            Assert.Equal("Success", JsonConvert.DeserializeObject<LoginResponseDto>(vResponse).Message);

        }
    }
}