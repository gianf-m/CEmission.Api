
using CEmission.Emissions;
using CEmission.LoginAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;


namespace Testing {
    public class EmissionControllerTesting {
        private string Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJDRUVtaXNzaW9ucyIsImp0aSI6Ijk0OGI0ZDNjLTI1MjUtNDg3ZS04NDY0LTA3ZGRjYWE5YzMwYiIsImlhdCI6MTcyODMyOTE3NCwiaWQiOiI1MWRkYWFhNy0xMzZhLTQyMmMtOGQzOS1jNmE5NTM4OTBlZmIiLCJ1c2VybmFtZSI6Ik1hc3RlciIsImVtYWlsIjoiTWFzdGVyQE1hc3Rlci5jb20iLCJleHAiOjE3MzM1MTMxNzQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcxMDEiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MTAxIn0.YGrC6mrMyyUnBq7Zji85hK-JcceRSosJbbUTSd-_KeI";

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
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7081/api/app/emission?Description=dsad&Quantity={rnd.Next(1, 101)}&EmissionDate=2024-10-07T18%3A53%3A07.481Z&Type=asda&CompanyId=2")) {
                    requestMessage.Headers.Authorization =
                        new AuthenticationHeaderValue("Bearer", Token);

                    var vResponse = await client.SendAsync(requestMessage);
                    Assert.Equal(HttpStatusCode.OK, vResponse.StatusCode);
                }
            }
        }

        [Fact]
        public async Task EmissionGet_Test() {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            Random rnd = new Random();

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7081/api/app/emission")) {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", Token);

                var vResponse = await client.SendAsync(requestMessage);
                Assert.Equal(HttpStatusCode.OK, vResponse.StatusCode);
            }
        }

        [Fact]
        public async Task EmissionGetId_Test() {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            Random rnd = new Random();
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7081/api/app/emission?Id={rnd.Next(1, 10)}")) {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", Token);

                var vResponse = await client.SendAsync(requestMessage);
                Assert.Equal(HttpStatusCode.OK, vResponse.StatusCode);
            }

        }

        [Fact]
        public async Task EmissionByCompanyId_Test() {
            await using var application = new WebApplicationFactory<Program>();
            using var client = application.CreateClient();
            Random rnd = new Random();
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7081/api/app/emission/company/Id={rnd.Next(1, 10)}")) {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", Token);

                var vResponse = await client.SendAsync(requestMessage);
                Assert.Equal(HttpStatusCode.OK, vResponse.StatusCode);
            }

        }
    }
}