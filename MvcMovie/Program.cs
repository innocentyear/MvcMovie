using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();
            var host = CreateWebHostBuilder(args).Build();  //创建并生成一个Web服务器。
            using (var scope = host.Services.CreateScope()) //创建一个作用域。
            {
                var services = scope.ServiceProvider; //取得服务提供器。
                try
                {
                    //
                    var context = services.GetRequiredService<MvcMovieContext>();//从依赖注入容器获得数据库上下文学；
                    //如果数据库不存在将会创建数据库；对于指定的数据库上下文使用和加载迁移。
                    context.Database.Migrate(); //需要使用Microsfot.EntityFrameworkCore命名空间。
                    SeedData.Initialize(services);

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }

                host.Run();
            }



        }

        //创建Web服务器。
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
