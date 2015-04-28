using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {



            var d = new Random();

           
            for (int i = 0; i < 100; i++)
            {
                var d1 = d.Next(28);
                var m1 = d.Next(11);
                var y1 = d.Next(10 );

                var d2 = new DateTime(month:m1+1,
                    day: d1+1,
                    year: (1990+y1));

                var c = i % 12;
                    Console.WriteLine(c);
                    Console.WriteLine(d2);
                
            }
             
        }
    }
}
