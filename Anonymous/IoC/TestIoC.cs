using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous.IoC
{
    public class TestIoC
    {
        public static void test1()
        {
            var services = new ServiceCollection();

            // Đăng ký dịch vụ IClassC tương ứng với đối tượng ClassC
            //services.AddSingleton<IClassC, ClassC1>();
            //services.AddTransient<IClassC, ClassC>();
            services.AddScoped<IClassC, ClassC>();

            var provider = services.BuildServiceProvider();

            for (int i = 0; i < 5; i++)
            {
                var service = provider.GetService<IClassC>();
                Console.WriteLine(service.GetHashCode());
            }

            using (var scope = provider.CreateScope())
            {
                //  Lấy Service trong một pham vi
                for (int i = 0; i < 2; i++)
                {
                    var myservice = scope.ServiceProvider.GetService<IClassC>();
                    Console.WriteLine(myservice.GetHashCode());
                }
            }

        }

        public static void test2()
        {
            var services = new ServiceCollection();

            services.Configure<MyServiceOptions>(
                options =>
                {
                    options.data1 = "Xin chao cac ban";
                    options.data2 = 2021;
                }
            );

            // Đăng ký dịch vụ 
            services.AddSingleton<MyService>();

            var provider = services.BuildServiceProvider();

            var myservice = provider.GetService<MyService>();
            myservice.PrintData();
        }

        public static void test3()
        {
            var services = new ServiceCollection();

            // Đăng ký dịch vụ 
            services.AddSingleton<MyService>((IServiceProvider serviceprovider) =>
            {
                var options = Options.Create(new MyServiceOptions()
                {
                    data1 = "Xin chao cac ban",
                    data2 = 2022
                });

                var sv = new MyService(options);
                return sv;
            });

            var provider = services.BuildServiceProvider();

            var myservice = provider.GetService<MyService>();
            myservice.PrintData();
        }

        public static void test4()
        {
            var configBuilder = new ConfigurationBuilder()
                                       .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
                                       .AddJsonFile("appsettings.json");                  // nạp config định dạng JSON
            var configurationroot = configBuilder.Build();                // Tạo configurationroot

            ServiceCollection services = new ServiceCollection();

            services.AddOptions();
            services.Configure<MyServiceOptions>(configurationroot.GetSection("MyServiceOptions"));

            services.AddSingleton<MyService>();

            var provider = services.BuildServiceProvider();

            var myservice = provider.GetService<MyService>();
            myservice.PrintData();

            var config = provider.GetService<IOptions<MyServiceOptions>>();
            MyServiceOptions myServiceOptions = config.Value;
        }
    }
}
