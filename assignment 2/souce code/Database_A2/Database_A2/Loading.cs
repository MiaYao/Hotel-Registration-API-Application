using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database_A2
{using System.IO;
    class Loading
    {
        public static void Searching_Loading()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Searching:");
            System.Console.Write(".."); Thread.Sleep(1000);
            System.Console.Write("..."); Thread.Sleep(1000);
            System.Console.Write("....."); Thread.Sleep(1000);
            System.Console.WriteLine("........"); Thread.Sleep(1000);
        }

        public static void Inserting_Loading()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Inserting:");
            System.Console.Write(".."); Thread.Sleep(1000);
            System.Console.Write("..."); Thread.Sleep(1000);
            System.Console.Write("....."); Thread.Sleep(1000);
            System.Console.WriteLine("........"); Thread.Sleep(1000);
        }
    }
}
