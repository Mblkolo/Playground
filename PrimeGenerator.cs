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
            return new PrimeGenerator(maxValue).generate();
        }

        private readonly int maxValue;
        private readonly bool[] crossedOut;

        public PrimeGenerator(int maxValue)
        {
            this.maxValue = maxValue;
            this.crossedOut = new bool[maxValue + 1];
        }

        private int[] generate()
        {
            if (maxValue < 2)
                return new int[0];

            crossOutNotPrime();
            int[] primes = getNotCrossedValues();
            return primes;
        }

        private void crossOutNotPrime()
        {
            crossedOut[0] = crossedOut[1] = true;

            //Достаточно перебирать только корня maxValue
            for (int i = 2; i * i <= maxValue; ++i)
            {
                if (!crossedOut[i])
                    crossOutMultiplesOf(i);
            }
        }

        private void crossOutMultiplesOf(int primeValue)
        {
            var step = primeValue;
            var prime = primeValue;
            for (int notPrime = prime + step; notPrime <= maxValue; notPrime += step)
                crossedOut[notPrime] = true;
        }

        private int[] getNotCrossedValues()
        {
            int countPrimes = getNumberOfUncrossedIntegers();

            var primes = new int[countPrimes];
            var freePosition = 0;
            for (int i = 0; i < crossedOut.Length; ++i)
            {
                if (!crossedOut[i])
                {
                    primes[freePosition] = i;
                    freePosition++;
                }
            }

            return primes;
        }

        private int getNumberOfUncrossedIntegers()
        {
            int countPrimes = 0;
            for (int i = 0; i < crossedOut.Length; ++i)
                if (!crossedOut[i])
                    countPrimes++;

            return countPrimes;
        }

    }
}
