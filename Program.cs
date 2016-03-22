using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    class Program
    {
        static int Main(string[] args)
        {
            if(PrimeGenerator.Generate(10).Length != 4)
                return -1;

            if(PrimeGenerator.Generate(100).Length != 25)
                return -1;

            return 0;
        }
    }
}
