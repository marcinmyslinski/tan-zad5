using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PrzykładApiWyklad.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykładApiWyklad
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentsList sl1 = new StudentsList();
            // Builder - strukturalny
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).Build().Run();
            
        }

        
    }
}
