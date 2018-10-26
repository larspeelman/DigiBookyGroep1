using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.DTO;
using DigiBooky;
using Domain.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace DigiBookyIntigrationTest.Users
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
            UserDTO testUser = new UserDTO();
            testUser.Email = "xxxx@hotmail.com";
            testUser.Birthdate = new DateTime(1987, 4, 21);
            testUser.Id = "LP_21041987";
            var content = JsonConvert.SerializeObject(testUser);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/User", stringContent);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var returnUser = JsonConvert.DeserializeObject<User>(responseString);
            Assert.Equal("LP_21041987",returnUser.IdentificationNumber);
        }
    }
}
