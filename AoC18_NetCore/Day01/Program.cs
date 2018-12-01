using System;
using System.Collections.Generic;
using Core;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = InputFileReader.ReadAllLines("Input.txt");

            var actions = new List<int>();

            foreach (var s in input)
            {
                actions.Add(int.Parse(s));
            }

            // Task 1: 
            var res0 = 0;
            foreach (var action in actions)
            {
                res0 += action;
            }


            // Task 2:
            var freq = 0;
            var res = 0;

            var allFreqs = new HashSet<int>();
            allFreqs.Add(freq);
            var notFound = true;
            while (notFound)
            {
                foreach (var action in actions)
                {
                    freq += action;
                    if (!allFreqs.Add(freq))
                    {
                        notFound = false;
                        res = freq;
                        break;
                    }
                }
            }

            // Output:
            Console.WriteLine(res0);
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
