using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsterisksSharpCount
{
    class Program
    {
        static object locker = new object();
        static int count;

        static void PrintChar()
        {
            while (true)
            {
                string threadName = Thread.CurrentThread.Name;
                string stringToPrint = "";

                Monitor.Enter(locker);

                for(int i = 0; i < 60; i++)
                {
                    stringToPrint += threadName;
                    count++;
                }

                Console.WriteLine("{0} {1}", stringToPrint, count);

                Thread.Sleep(500);
                Monitor.Exit(locker);
            }
        }
        static void Main(string[] args)
        {
            Thread asteriskThread = new Thread(PrintChar);
            Thread sharpThread = new Thread(PrintChar);

            asteriskThread.Name = "*";
            sharpThread.Name = "#";

            asteriskThread.Start();
            sharpThread.Start();

            Console.Read();
        }
    }
}
