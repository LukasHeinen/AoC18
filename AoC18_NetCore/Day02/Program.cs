using System;
using System.Collections.Generic;
using Core;

namespace Day02
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = InputFileReader.ReadAllLines("Input.txt");
            var inputAnalytics = new List<Dictionary<char, int>>();

            foreach (var s in input)
            {
                var dict = new Dictionary<char,int>();
                foreach (var c in s)
                {
                    if(dict.TryGetValue(c, out var k))
                    {
                        dict.Remove(c);
                        var count = k + 1;
                        dict.Add(c,count);
                    }
                    else
                    {
                        dict.Add(c, 1);
                    }
                }
                inputAnalytics.Add(dict);
            }

            var count2 = 0;
            var count3 = 0;

            foreach (var inputAnalytic in inputAnalytics)
            {
                var keys = inputAnalytic.Keys;
                var has3 = false;
                var has2 = false;
                foreach (var key in keys)
                {
                    
                    if (inputAnalytic.TryGetValue(key, out var count))
                    {
                        if (count == 2 && !has2)
                        {
                            count2++;
                            has2 = true;
                        }

                        if (count == 3 && !has3)
                        {
                            count3++;
                            has3 = true;
                        }
                    }
                }
            }
            var res = count2*count3;

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
