using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous.IoC
{
    public interface IHorn
    {
        void Beep();
    }
    public class HornLevel1 : IHorn
    {
        int level; // độ lớn của còi xe

        public HornLevel1(int level) => this.level = level;

        public void Beep() => Console.WriteLine($"(level {level}) Beep - beep - beep ...");
    }
    public class HeavyHorn : IHorn
    {
        public void Beep() => Console.WriteLine("(kêu to lắm) BEEP BEEP BEEP ...");
    }

    public class Car
    {
        // horn là một Dependecy của Car
        IHorn horn;

        public Car(IHorn horn) => this.horn = horn;

        public void Beep()
        {
            // Sử dụng Dependecy đã được Inject
            horn.Beep();
        }
    }

    public class DependencyInjCreate
    {
        public static void test()
        {
            //HornLevel1 horn = new HornLevel1(1);
            HeavyHorn horn2 = new HeavyHorn();
            var car = new Car(horn2);

            car.Beep();
        }
    }
}
