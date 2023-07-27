using System;

namespace Anonymous.Delegate
{
    public class TestAction : TestDelegate
    {
        public static void PrintAction() 
        { 
            Action<string> showLog = null;

            showLog += TestDelegate.Info;
            showLog += TestDelegate.Warning;
            showLog += TestDelegate.Error;

            showLog("Action test");
        }

        public static void Tong(int x, int y, Action<string> callback)
        {
            var z = x + y;
            callback(string.Format("Tô?ng: {0} + {1} = {2}", x, y, z));
        }

        public static void PrintAction(int x, int y)
        {
            Tong(x, y, (z) => Console.WriteLine($"Anonymou: {z}"));
            Tong(1, 3, TestDelegate.Info);
        }
    }
}
