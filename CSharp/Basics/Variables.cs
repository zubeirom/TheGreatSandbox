using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Basics
{
    public class Variables
    {
        double a, b = 2.5, c = 3;

        public void Execute()
        {
            a = b + c;
            Console.WriteLine(a);
        }
    }
}
