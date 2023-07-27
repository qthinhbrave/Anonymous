using System;

namespace Anonymous.Delegate
{
    public class TestFunc
    {
        delegate void ShowResult(object x, object y, object z);
        static int Sum(int x, int y)
        { return x + y; }

        public static void PrintFunc()
        {
            Func<int, int, int> tinhTong;
            tinhTong = Sum;

            var ketqua = tinhTong(1, 2);

            ShowResult showResult;
            showResult = (x, y, z) => { Console.WriteLine(string.Format("Tô?ng: {0} + {1} = {2}", x, y, z)); };

            showResult(1, 2, tinhTong(1, 2));
        }
    }
}
