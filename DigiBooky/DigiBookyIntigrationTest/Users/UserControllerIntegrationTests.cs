using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Digibooky_api;
using Digibooky_api.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace Digibooky_IntigrationTest.Users
{
    public class UserControllerIntegrationTests
    {

        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserControllerIntegrationTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task RegisterNewUser()
        {
            // Arrange
            UserDTOWithIdentificationNumber testUser = new UserDTOWithIdentificationNumber();
            testUser.Email = "xxxx@hotmail.com";
            testUser.Birthdate = new DateTime(1987, 4, 21);
            testUser.UserIdentification = "LP_21041987";
            var content = JsonConvert.SerializeObject(testUser);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/User", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var returnUser = JsonConvert.DeserializeObject<UserDTOWithoutIdentificationNumber>(responseString);
            Assert.Equal("xxxx@hotmail.com", returnUser.Email);
        }
    }
}
