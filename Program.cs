using Grapevine;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MerpeyHypeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var server = RestServerBuilder.UseDefaults().Build())
            {
                server.Prefixes.Add($"http://192.168.1.102:1235/");
                server.Prefixes.Remove($"http://localhost:1234/");
                server.Start();

                Console.WriteLine("Press enter to stop the server");
                Console.ReadLine();
            }
        }
    }
    [RestResource]
    public class MyResource
    {
        [RestRoute("Get", "/api/test")]
        public async Task Test(IHttpContext context)
        {
            await context.Response.SendResponseAsync("Successfully hit the test route!");
        }
        [RestRoute("Get","/api/v0/Login")]
        public async Task Loginv0(IHttpContext context)
        {
            //login işlemleri
            await context.Response.SendResponseAsync("Success Login Route!");
        }
    }
}
