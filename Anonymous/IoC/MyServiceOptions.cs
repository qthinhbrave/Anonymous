using Microsoft.Extensions.Options;
using System;

namespace Anonymous.IoC
{
    public class MyServiceOptions
    {
        public string data1 { get; set; }
        public int data2 { get; set; }

    }

    public class MyService
    {
        public string data1 { get; set; }
        public int data2 { get; set; }

        public MyService(IOptions<MyServiceOptions> options)
        {
            // Đọc được MyServiceOptions từ IOptions
            MyServiceOptions opts = options.Value;
            data1 = opts.data1;
            data2 = opts.data2;
        }
        public void PrintData() => Console.WriteLine($"{data1} / {data2}");
    }
}
