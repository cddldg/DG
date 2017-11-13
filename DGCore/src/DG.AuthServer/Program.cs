﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DG.AuthServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "认证服务";
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.UseUrls("http://")
                .UseStartup<Startup>()
                .Build();
    }
}
