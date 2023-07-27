using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Anonymous.IoC
{
    public class DependencyInjection
    {
        class ClassBServiceOptions
        {
            IClassC c_dependency { get; set; }
            public string message { get; set; }
        }

        class ClassB2 : IClassB
        {
            IClassC c_dependency;
            string message;
            public ClassB2(IClassC classc, string mgs)
            {
                c_dependency = classc;
                message = mgs;
                Console.WriteLine("ClassB2 is created");
            }
            public void ActionB()
            {
                Console.WriteLine(c_dependency.GetHashCode());
                Console.WriteLine(message);
                //if (c_dependency is null)
                //{
                //    c_dependency = new ClassC();
                //}
                c_dependency.ActionC();
            }

            // Factory nhận tham số là IServiceProvider và trả về đối tượng địch vụ cần tạo
            public static IClassB CreateB2Factory(IServiceProvider serviceprovider)
            {
                var service_c = serviceprovider.GetService<IClassC>();
                //var service_c = new ClassC();
                var sv = new ClassB2(service_c, "Thực hiện trong ClassB2");

                return sv;
            }

            // use IOptions
            public ClassB2(IOptions<ClassBServiceOptions> options)
            {
                // Đọc từ IOptions
                ClassBServiceOptions opts = options.Value;
                //c_dependency = opts.c_dependency;
                message = opts.message;
            }
            public void SetDependency(IClassC classc)
            {
                this.c_dependency = classc;
            }
        }

        public static void test()
        {
            var services = new ServiceCollection();

            // Đăng ký dịch vụ
            services.AddSingleton<IClassB>((IServiceProvider serviceprovider) =>
            {
                var service_c = serviceprovider.GetService<IClassC>();
                var sv = new ClassB2(service_c, "Thực hiện trong ClassB2");
                return sv;
            });

            //services.AddSingleton<IClassB>(ClassB2.CreateB2Factory);

            var provider = services.BuildServiceProvider();
            var service = provider.GetService<IClassB>();
            //Console.WriteLine(service.GetHashCode());
            service.ActionB();

        }

        public static void test2()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ClassC1>();
            var providerC = services.BuildServiceProvider();
            var myserviceC = providerC.GetService<ClassC1>();

            // Đăng ký dịch vụ
            services.AddSingleton<IClassB>((IServiceProvider serviceprovider) =>
            {
                var sv = new ClassB2(myserviceC, "Thực hiện trong ClassB2");
                return sv;
            });

            //services.AddSingleton<IClassB>(ClassB2.CreateB2Factory);

            var provider = services.BuildServiceProvider();
            var service = provider.GetService<IClassB>();
            //Console.WriteLine(service.GetHashCode());
            service.ActionB();
        }

        public static void test3()
        {
            var services = new ServiceCollection();

            // Đăng ký dịch vụ
            services.AddSingleton<IClassC, ClassC1>();
            services.AddSingleton<IClassB>((IServiceProvider serviceprovider) =>
            {
                var service_c = serviceprovider.GetService<IClassC>();
                Console.WriteLine(service_c.GetHashCode());
                var sv = new ClassB2(service_c, "Thực hiện trong ClassB2");
                return sv;
            });

            var provider = services.BuildServiceProvider();

            var myserviceC = provider.GetService<IClassC>();
            Console.WriteLine(myserviceC.GetHashCode());

            var service = provider.GetService<IClassB>();
            service.ActionB();

            ClassB2 service_b2 = provider.GetService<ClassB2>();
            if (service_b2 is not null)
                service_b2.ActionB();
        }

        
        public static void test4()
        {
            var services = new ServiceCollection();

            //services.Configure<ClassBServiceOptions>(
            //    options =>
            //    {
            //        options.message = "Thực hiện trong ClassB2";
            //    });

            // Đăng ký dịch vụ 
            services.AddSingleton<IClassC, ClassC1>();
            //services.AddSingleton<ClassB2>();

            services.AddSingleton<ClassB2>((IServiceProvider serviceprovider) =>
            {
                var options = Options.Create<ClassBServiceOptions>(new ClassBServiceOptions()
                {
                    message = "Thực hiện trong ClassB2",
                    //c_dependency = serviceprovider.GetService<IClassC>()
                });

                var sv = new ClassB2(options);
                sv.SetDependency(serviceprovider.GetService<IClassC>());
                return sv;
            });

            var provider = services.BuildServiceProvider();

            var myservice = provider.GetService<ClassB2>();
            myservice.SetDependency(provider.GetService<IClassC>());
            myservice.ActionB();
        }
        
    }
}
