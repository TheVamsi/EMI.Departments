using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using Xunit;

namespace EMI.Departments.IntegrationTests
{
    public class TestClientProvider :IClassFixture<WebApplicationFactory<Startup>>
    {

        private readonly WebApplicationFactory<Startup> _startup;
        public  HttpClient Client { get; private set; }
        public TestClientProvider(WebApplicationFactory<Startup> startup)
        {
            //var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            //Client = server.CreateClient();
            _startup = startup;
        }  
    }
}
