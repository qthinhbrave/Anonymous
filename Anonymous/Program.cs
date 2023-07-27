using Anonymous.Asynchronous;
using Anonymous.Attributes;
using Anonymous.Collection;
using Anonymous.Delegate;
using Anonymous.IoC;
using System;
using System.Threading.Tasks;

namespace Anonymous
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Console.WriteLine("Hello World!");
            //TestDelegate.testShowLog();

            //TestShowLogMulti.TestShowLog("TestLog");

            //TestFunc.PrintFunc();

            //TestAction.PrintAction();

            //TestAction.PrintAction(2, 4);

            //TestCollection.test();

            //TestSortedList.Test();

            //TestLinkedList.Test();

            //TestObserableCollection.test();

            //Products.ProductPrice(500);
            //Products.TestJoin();

            //TestAsync01.test();
            //TestAsyncAwait.test();
            //Console.ReadKey();

            //TestAttribute.test();
            //TestAttribute.checkValidationContext();

            //DependencyClass.test();
            //DependencyInjCreate.test();
            //DependencyInjection.test();
            //DependencyInjection.test3();
            //TestIoC.test1();
            //TestIoC.test2();
            //Console.WriteLine("!!!");
            //TestIoC.test3();
            //DependencyInjection.test4();
            TestIoC.test4();
        }

    }

}
