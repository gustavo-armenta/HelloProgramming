﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public class DynamicProgramming
    {
        public int Fibonacci(int n)
        {
            if (n < 2)
            {
                return n;
            }
            var f = new int[n + 1];
            f[1] = 1;
            for (int i = 2; i < f.Length; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[n];
        }

        public List<int> LongestIncreasingSubsequence(List<int> values)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < values.Count; i++)
            {
                list.Add(1);
            }

            for (int i = 1; i < values.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (values[i] > values[j] && list[i] < list[j] + 1)
                    {
                        list[i] = list[j] + 1;
                    }
                }
            }

            return list;
        }

        public string LongestCommonSubsequence(string sm, string sn)
        {
            int m = sm.Length;
            int n = sn.Length;
            List<char> c = new List<char>();
            int[,] L = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        L[i, j] = 0;
                    }
                    else if (sm[i - 1] == sn[j - 1])
                    {
                        L[i, j] = L[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
                    }
                }
            }

            for (int i = m; i > 0; i--)
            {
                for (int j = n; j > 0; j--)
                {
                    if (L[i, j] > Math.Max(L[i - 1, j], L[i, j - 1]))
                    {
                        c.Add(sm[i - 1]);
                        i--;
                        j--;
                    }
                    else if (L[i, j] == L[i - 1, j])
                    {
                        if (i > 1)
                        {
                            i--;
                            j++;
                        }
                    }
                }
            }

            c.Reverse();
            return new string(c.ToArray());
        }

        public int[] MinCoinChange(int[] coins, int value)
        {
            int[] results = new int[value + 1];
            results[0] = 0;
            for (int i = 1; i < results.Length; i++)
            {
                results[i] = int.MaxValue - 1;
            }

            for (int i = 1; i <= value; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        int option = results[i - coins[j]] + 1;
                        if (results[i] > option)
                        {
                            results[i] = option;
                        }
                    }
                }
            }

            return results;
        }

        public int MinEditDistance(string s1, string s2)
        {
            int rows = s1.Length + 1;
            int columns = s2.Length + 1;
            int[,] dp = new int[rows, columns];
            for (int r = 0; r < rows; r++)
            {
                dp[r, 0] = r;
            }
            for (int c = 0; c < columns; c++)
            {
                dp[0, c] = c;
            }
            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < columns; c++)
                {
                    if (s1[r - 1] == s2[c - 1])
                    {
                        dp[r, c] = dp[r - 1, c - 1];
                    }
                    else
                    {
                        dp[r, c] = Math.Min(dp[r - 1, c], dp[r, c - 1]);
                        dp[r, c] = Math.Min(dp[r - 1, c - 1], dp[r, c]);
                        dp[r, c] = dp[r, c] + 1;
                    }
                }
            }

            return dp[rows - 1, columns - 1];
        }

        public int Knapsack(int maxWeight, (int Weight, int Value)[] items)
        {
            int n = items.Length;
            int[,] dp = new int[n + 1, maxWeight + 1];
            for (int i = 1; i <= n; i++)
            {
                var item = items[i - 1];
                for (int j = 1; j <= maxWeight; j++)
                {
                    if (item.Weight <= j)
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - item.Weight] + item.Value);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }

            return dp[n, maxWeight];
        }
    }
}
