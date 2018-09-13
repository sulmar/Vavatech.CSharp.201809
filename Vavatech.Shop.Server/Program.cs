using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Vavatech.Shop.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

         //   CreateWebHostBuilder(args).Build().RunAsService();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            //var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            //var pathToContentRoot = Path.GetDirectoryName(pathToExe);

            return WebHost.CreateDefaultBuilder(args)
                // .UseContentRoot(pathToContentRoot)
                .UseStartup<Startup>();
        }
    }
}
