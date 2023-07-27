using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anonymous.Asynchronous
{
    public class TestAsync01
    {
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        public static Task<string> Async1 (string text1, string text2)
        {
            Func<object, string> myfunc = (object text) =>
            {
                dynamic ts = text;
                for (int i = 1; i <= 10; i++)
                {
                    WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3} Tham số {ts.x} {ts.y}",
                        ConsoleColor.Green);
                    Thread.Sleep(1000);
                }
                return $"Kết thúc Async1! {ts.x}";
            };

            Task<string> task = new Task<string>(myfunc, new { x = text1, y = text2 });
            task.Start();

            Console.WriteLine("Async1: Làm gì đó sau khi task chạy");

            return task;
        }

        public static Task Async2()
        {

            Action myaction = () => {
                for (int i = 1; i <= 10; i++)
                {
                    WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3}",
                        ConsoleColor.Yellow);
                    Thread.Sleep(2000);
                }
            };
            Task task = new Task(myaction);
            task.Start();

            // Làm gì đó sau khi chạy Task ở đây
            Console.WriteLine("Async2: Làm gì đó sau khi task chạy");

            return task;
        }

        public static void test()
        {
            Console.WriteLine($"{' ',5} {Thread.CurrentThread.ManagedThreadId,3} MainThread");
            Task<string> t1 = TestAsync01.Async1("A", "B");
            Task t2 = TestAsync01.Async2();

            Console.WriteLine("Làm gì đó ở thread chính sau khi 2 task chạy");

            // Chờ t1 kết thúc và đọc kết quả trả về
            t1.Wait();
            String s = t1.Result;
            TestAsync01.WriteLine(s, ConsoleColor.Red);

            // Ngăn không cho thread chính kết thúc
            // Nếu thread chính kết thúc mà t2 đang chạy nó sẽ bị ngắt
            //Console.ReadKey();
        }
    }
}
