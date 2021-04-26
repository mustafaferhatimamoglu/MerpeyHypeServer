using Grapevine;
using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MerpeyHypeServer
{
    class Program
    {
        #region disableExitButton
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        
        static void Main(string[] args)
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_BYCOMMAND);
            #endregion disableExitButton


            Console.WriteLine("Hello World!");
            using (var server = RestServerBuilder.UseDefaults().Build())
            {
                server.Prefixes.Add($"http://192.168.1.102:1235/");
                server.Prefixes.Remove($"http://localhost:1234/");
                server.Start();

                Console.WriteLine("Press enter to stop the server");
                Console.Clear();
                Console.WindowWidth = 150;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
==========================================================================================================================================
=========================================  ====  =======  =====  ==========================      =========================================
=========================================   ==   =======   ===   =========================  ====  ========================================
==========================================  ==  ========  =   =  =========================  ====  ========================================
=  =  = ====   ===  =   ===    ====   ====  ==  ========  == ==  ===   ===  ==  = =========  ========   ===  =   ===  =  ===   ===  =   ==
=        ==  =  ==    =  ==  =  ==  =  ====    =========  =====  ==  =  ======     ==========  =====  =  ==    =  ==  =  ==  =  ==    =  =
=  =  =  ==     ==  =======  =  ==     =====  ==========  =====  =====  ==  ==  =  ============  ===     ==  ========   ===     ==  ======
=  =  =  ==  =====  =======    ===  ========  ==========  =====  ===    ==  ==  =  =======  ====  ==  =====  ========   ===  =====  ======
=  =  =  ==  =  ==  =======  =====  =  =====  ==========  =====  ==  =  ==  ==  =  =======  ====  ==  =  ==  ========= ====  =  ==  ======
=  =  =  ===   ===  =======  ======   ======  ==========  =====  ===    ==  ==  =  ========      ====   ===  ========= =====   ===  ======
==========================================================================================================================================");
                Console.WriteLine("YMS Started");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                string enteredText = "";
                while (enteredText != "stop")
                {
                    enteredText = Console.ReadLine();
                }
            }
            
        }
    }


    [RestResource]
    public class MyResource
    {

        [RestRoute("Get", "isitUP")]
        public async Task isitUP(IHttpContext context)
        {
            await context.Response.SendResponseAsync("YES!");
        }
        [RestRoute("Get", "/api/test")]
        public async Task Test(IHttpContext context)
        {
            await context.Response.SendResponseAsync("Successfully hit the test route!");
        }
        [RestRoute("Get", "/api/v0/Login")]
        public async Task Loginv0(IHttpContext context)
        {
            //login işlemleri
            string MainUser = context.Request.Headers["MainUser"];
            string UserName = context.Request.Headers["UserName"];
            string Password = context.Request.Headers["Password"];
            //string DT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            await context.Response.SendResponseAsync("Success Login Route!");

        }
    }
}
