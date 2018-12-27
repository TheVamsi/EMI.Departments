using EMI.Departments.Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace EMI.Departments.IntegrationTests
{
    public class DepartmentIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        public DepartmentIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            Client = _factory.CreateClient();
        }


        [Fact]
        public async Task Test_GetDepartments()
        {

            var url = "https://localhost:5001/api/DepartmentDetails";
            var response = await Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Test_DeleteDepartment_WithId()
        {
            
            var someurl = "https://localhost:5001/api/DepartmentDetails?idToRemove=4";
            var response = await Client.DeleteAsync(someurl );
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task<Uri> Test_AddDepartment()
        {
            var department = new DepartmentDetails
            {
               
                DepartmentName = "something"
            };
            Client.BaseAddress = new Uri("https://localhost:5001/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await Client.PostAsJsonAsync(
        "api/DepartmentDetails", department);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // return URI of the created resource.
            return response.Headers.Location;

        }
    }
}

