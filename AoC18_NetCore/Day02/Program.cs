using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;

namespace Day02
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var input = InputFileReader.ReadAllLines("Input.txt");
            var inputList = input.ToList();

            var pairNotFound = true;
            var res1 = "";
            var res2 = "";
            while (pairNotFound)
            {
                var s1 = inputList[0];
                foreach (var s in inputList)
                {
                    if (s.Equals(s1)) continue;
                    if (hasOneDifference(s1, s))
                    {
                        res1 = s1;
                        res2 = s;
                        pairNotFound = false;
                        break;
                    }
                }

                inputList.Remove(s1);
            }

            var res = returnResult(res1, res2);

            /*
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
            */

            Console.WriteLine(res);
            Console.ReadLine();
        }

        private static bool hasOneDifference(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            var differences = 0;
            for (var i = 0; i < s1.Length; i++)
            {
                if (!(s1[i] == s2[i]))
                {
                    differences++;
                }
            }

            if (differences == 1) return true;
            return false;
        }

        private static string returnResult(string s1, string s2)
        {
            var builder = new StringBuilder();
            for (var i = 0; i < s1.Length; i++)
            {
                if ((s1[i] == s2[i]))
                {
                    builder.Append(s1[i]);
                }
            }

            return builder.ToString();
        }
    }
}