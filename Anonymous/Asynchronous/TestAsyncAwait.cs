using System;
using System.Threading;
using System.Threading.Tasks;

namespace Anonymous.Asynchronous
{
    public static class TestAsyncAwait
    {
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        public static async Task<string> Async1 (string text1, string text2)
        {
            Func<object, string> myfunc = (object thamso) => {
                // Đọc tham số (dùng kiểu động - xem kiểu động để biết chi tiết)
                dynamic ts = thamso;
                for (int i = 1; i <= 10; i++)
                {
                    //  Thread.CurrentThread.ManagedThreadId  trả về ID của thread đạng chạy
                    WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3} Tham số {ts.x} {ts.y}",
                        ConsoleColor.Green);
                    Thread.Sleep(500);
                }
                return $"Kết thúc Async1! {ts.x}";
            };

            Task<string> task = new Task<string>(myfunc, new { x = text1, y = text2 });
            task.Start();

            await task;

            TestAsync01.WriteLine("Async1 - làm gì đó khi task chạy xong", ConsoleColor.Red);
            string ketqua = task.Result;
            Console.WriteLine(ketqua);

            return ketqua;
        }

        public static async Task Async2()
        {
            Action myaction = () => {
                for (int i = 1; i <= 10; i++)
                {
                    WriteLine($"{i,5} {Thread.CurrentThread.ManagedThreadId,3}", ConsoleColor.Yellow);
                    Thread.Sleep(2000);
                }
            };
            Task task = new Task(myaction);
            task.Start();

            await task;

            // Làm gì đó sau khi chạy Task ở đây
            Console.WriteLine("Async2: Làm gì đó sau khi task kết thúc");

            // Không cần trả về vì gốc đồng bộ trả về void, đồng bộ sẽ trả về Task
        }

        [Obsolete("Phương thức này lỗi thời, hãy  dùng phương thức Abc")]
        public static async Task test()
        {
            var t1 = TestAsyncAwait.Async1("x", "y");
            var t2 = TestAsyncAwait.Async2();

            // Làm gì đó khi t1, t2 đang chạy
            Console.WriteLine("Task1, Task2 đang chạy");


            await t1; // chờ t1 kết thúc
            Console.WriteLine("Làm gì đó khi t1 kết thúc");

            await t2; // chờ t2 kết thúc

            Console.ReadKey();
        }
    }
}
