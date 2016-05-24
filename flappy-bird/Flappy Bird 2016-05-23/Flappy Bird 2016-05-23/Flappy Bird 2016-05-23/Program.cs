using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flappy_Bird_2016_05_23
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen(30, 10);
            while (!screen.IsGG())
            {
                screen.Tick();
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    screen.BeamMeUp();
                }
                Thread.Sleep(100);
            }
            Console.WriteLine("gg :(");
            Console.ReadLine();
        }
    }
}
