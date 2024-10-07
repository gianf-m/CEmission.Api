
using CEmission.Emissions;
using CEmission.LoginAppServices;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Json;


namespace Testing {
    public class EmissionControllerTesting {
        [Fact]
        public async Task EmissionPost_Test() {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            Random rnd = new Random();

            EmissionCreateDto vCreate = new EmissionCreateDto { 
                Description = "description",
                Quantity = rnd.Next(1, 101),
                EmissionDate = DateTime.Now,
                Type = "type default",
                CompanyId = 2
            };

            for (int i = 0; i < 20; i++) {
                var vResponse = await client.PostAsync($"/api/app/emission?Description=dsad&Quantity={rnd.Next(1, 101)}&EmissionDate=2024-10-07T18%3A53%3A07.481Z&Type=asda&CompanyId=2", null);
                Assert.Equal(HttpStatusCode.OK, vResponse.StatusCode);
            }
        }

        [Fact]
        public async Task EmissionGet_Test() {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            Random rnd = new Random();

            var vResponse = await client.GetAsync($"/api/app/emission");
            Assert.Equal(HttpStatusCode.OK, vResponse.StatusCode);

        }

        [Fact]
        public async Task EmissionGetId_Test() {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            Random rnd = new Random();

            var vResponse = await client.GetAsync($"/api/app/emission?Id={rnd.Next(1,10)}");
            Assert.Equal(HttpStatusCode.OK, vResponse.StatusCode);

        }

        [Fact]
        public async Task EmissionByCompanyId_Test() {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            Random rnd = new Random();

            var vResponse = await client.GetAsync($"/api/app/emission/company/Id={rnd.Next(1, 10)}");
            Assert.Equal(HttpStatusCode.OK, vResponse.StatusCode);

        }
    }
}