using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class PrimeNumber
    {
        public List<int> FindAll(int value)
        {
            List<int> list = new List<int>();
            if (value >= 2)
            {
                list.Add(2);
            }
            for (int i = 3; i <= value; i += 2)
            {
                bool isPrime = true;
                for (int j = 0; j < list.Count; j++)
                {
                    if (i % list[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    list.Add(i);
                }
            }

            return list;
        }

        // Given integer X, find if P^Q=X
        public bool TryFindPrimeFactors(int x, out int p, out int q)
        {
            List<int> primes = this.FindAll(x);
            for (int i = 0; i < primes.Count; i++)
            {
                p = primes[i];
                for (int j = 0; j < primes.Count; j++)
                {
                    q = primes[j];
                    int result = (int)Math.Pow(p, q);
                    if (result == x)
                    {
                        return true;
                    }
                    else if (result > x)
                    {
                        break;
                    }
                }
            }

            p = default(int);
            q = default(int);
            return false;
        }
    }
}
