
namespace Anonymous.Delegate
{
    public class TestShowLogMulti : TestDelegate
    {
        public static void TestShowLog(string message)
        {
            ShowLog multiLog;

            multiLog = null;
            multiLog += Info;
            multiLog += Error;
            multiLog += Warning;

            multiLog(message);
        }
    }
}
