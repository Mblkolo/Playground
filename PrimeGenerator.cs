using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    class PrimeGenerator
    {
        public static int[] Generate(int maxValue)
        {
            if (maxValue < 2)
                return new int[0];

            var f = new bool[maxValue + 1];
            f[0] = f[1] = true;
            //0 - значит простое

            for (int i = 2; i * i < f.Length; ++i)
            {
                if (!f[i])
                {
                    for (int t = 2 * i; t < f.Length; t += i)
                        f[i] = true;
                }
            }

            int count = 0;
            for (int i = 0; i < f.Length; ++i)
                if (!f[i])
                    count++;

            var res = new int[count];
            var resCounter = 0;
            for (int i = 0; i < f.Length; ++i)
                if(!f[i])
                {
                    res[resCounter] = i;
                    resCounter ++;
                }

            return res;
        }
    }
}
