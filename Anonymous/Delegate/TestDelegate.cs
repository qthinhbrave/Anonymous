using System;

namespace Anonymous.Delegate
{
    public class TestDelegate
    {
        public delegate void ShowLog(string message);
        public static void testShowLog()
        {
            ShowLog showLog;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            showLog = Info;
            showLog("Thông báo");

            showLog = Error;
            showLog("Lô~i");

            showLog = Warning;
            showLog("Ca?nh báo");
        }

        static public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(string.Format("Info: {0}", message));
            Console.ResetColor();
        }

        static public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format("Error: {0}", message));
            Console.ResetColor();
        }

        static public void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format("Alert: {0}", message));
            Console.ResetColor();
        }
    }
}
