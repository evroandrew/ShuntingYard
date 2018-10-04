using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shunting_Yard.lib;

namespace SYard
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "( 2 + 2 ) * ( 2 - 6 )";
            double output = 0;
            Console.WriteLine($"input: {input}\n");
            ShuntingYard s = new ShuntingYard(input, ref output);
            Console.WriteLine($"output: {output}\n");
            Console.ReadKey();
        }
    }
}
