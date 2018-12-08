using System;
using System.Collections.Generic;
using System.IO;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Path.GetFullPath("C:\\code\\priv\\AoC18\\AoC18_NetCore\\Day03\\Input.txt"));
            // var input = File.ReadAllLines(Path.GetFullPath("C:\\code\\priv\\AoC18\\AoC18_NetCore\\Day03\\TestInput.txt"));

            var occupiedFields = new HashSet<string>();
            var overlappingFields = new HashSet<string>();

            foreach (var s in input)
            {
                var offsetX = int.Parse(s.Split(" ")[2].Split(",")[0]);
                var offsetY = int.Parse(s.Split(" ")[2].Split(",")[1].Split(":")[0]);
                var width  =  int.Parse(s.Split(" ")[3].Split("x")[0]);
                var height =  int.Parse(s.Split(" ")[3].Split("x")[1]);

                for (var i = 0; i < width; i++)
                {
                    for (var i1 = 0; i1 < height; i1++)
                    {
                        var pos = $"{offsetX + i},{offsetY+i1}";
                        if (!occupiedFields.Add(pos))
                        {
                            overlappingFields.Add(pos);
                        }
                    }
                }
            }

            Console.WriteLine(overlappingFields.Count);
            Console.ReadLine();
        }
    }
}
