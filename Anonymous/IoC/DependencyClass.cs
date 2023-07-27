using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous.IoC
{
    interface IClassB
    {
        public void ActionB();
    }
    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public ClassC() => Console.WriteLine("ClassC is created");
        public void ActionC() => Console.WriteLine("Action in classC");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;

        public ClassB(IClassC classC)
        {
            c_dependency = classC;
            Console.WriteLine("ClassB is created");
        }

        public void ActionB()
        {
            Console.WriteLine("Action in classB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        IClassB b_dependency;

        public ClassA(IClassB b_dependency)
        {
            this.b_dependency = b_dependency;
            Console.WriteLine("ClassA is created");
        }

        public void Action()
        {
            Console.WriteLine("Action in classA");
            b_dependency.ActionB();
        }
    }

    class ClassC1 : IClassC
    {
        public ClassC1() => Console.WriteLine("ClassC1 is created");
        public void ActionC()
        {
            Console.WriteLine("Action in C1");
        }
    }

    class ClassB1 : IClassB
    {
        IClassC c_dependency;
        public ClassB1(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB1 is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in B1");
            c_dependency.ActionC();
        }
    }

    public class DependencyClass
    {
        public static void test()
        {
            //ClassC objectC = new ClassC();
            //ClassB objectB = new ClassB(objectC);
            //ClassA objectA = new ClassA(objectB);

            IClassC objectC = new ClassC1();
            IClassB objectB = new ClassB1(objectC);
            ClassA objectA = new ClassA(objectB);

            objectA.Action();
        }

    }
}
