using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;

namespace Day04
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(Path.GetFullPath("C:\\code\\priv\\AoC18\\AoC18_NetCore\\Day04\\Input.txt"));

            var logs = new List<Tuple<int, int, int, int, int, string>>();
            foreach (var s in input)
            {
                var split = s.Split("]")[0].Split(" ");
                var year = int.Parse(split[0].Split("-")[0].Substring(1));
                var month = int.Parse(split[0].Split("-")[1]);
                var day = int.Parse(split[0].Split("-")[2]);
                var hour = int.Parse(split[1].Split(":")[0]);
                var minute = int.Parse(split[1].Split(":")[1]);
                var command = s.Split("]")[1].Substring(1);
                logs.Add(new Tuple<int, int, int, int, int, string>(
                    year,
                    month,
                    day,
                    hour,
                    minute,
                    command));
            }

            var sortedLogs = logs
                .OrderBy(t => t.Item1)
                .ThenBy(t => t.Item2)
                .ThenBy(t => t.Item3)
                .ThenBy(t => t.Item4)
                .ThenBy(t => t.Item5).ToList();
            
            /*
            foreach (var tuple in sortedLogs)
            {
                Console.WriteLine($"{tuple.Item2} \t {tuple.Item3} \t {tuple.Item4} \t {tuple.Item5} \t {tuple.Item6}");
            }
            */

            var guardsSleepingDuration = new Dictionary<string,int>();

            for (var i = 0; i < sortedLogs.Count; i++)
            {
                if (sortedLogs[i].Item6.Split(" ")[0].Equals("Guard"))
                {
                    var guardId = sortedLogs[i].Item6.Split(" ")[1];
                    var shiftsSleepingDuration = 0;
                    var sleeping = false;
                    var sleepStart = 0;
                    i++;
                    while (!sortedLogs[i].Item6.Split(" ")[0].Equals("Guard"))
                    {
                        if (sleeping)
                        {
                            var napDuration = 0;
                            var next = GetTime(sortedLogs[i]);
                            if (next < sleepStart)
                            {
                                napDuration = 2400 - sleepStart + next;
                            }
                            else
                            {
                                napDuration = next - sleepStart;
                            }
                            shiftsSleepingDuration += napDuration;
                            sleeping = false;
                        }
                        else
                        {
                            sleepStart = GetTime(sortedLogs[i]);
                            sleeping = true;
                        }
                        i++;
                    }

                    if (sleeping)
                    {
                        // Add duration before shift
                    }
                    if (guardsSleepingDuration.TryGetValue(guardId, out var currentDuration))
                    {
                        currentDuration += shiftsSleepingDuration;
                        guardsSleepingDuration.Remove(guardId);
                        guardsSleepingDuration.Add(guardId, currentDuration);
                    }
                    else
                    {
                        guardsSleepingDuration.Add(guardId, shiftsSleepingDuration);
                    }
                }
            }

            var guardWithLongestSleep = "";
            var maxDuration = int.MinValue;
            foreach (var keyValuePair in guardsSleepingDuration)
            {
                if (keyValuePair.Value > maxDuration)
                {
                    maxDuration = keyValuePair.Value;
                    guardWithLongestSleep = keyValuePair.Key;
                }
            }
            // Output puzzle result
            foreach (var tuple in sortedLogs)
            {
                Console.WriteLine($"{tuple.Item2},{tuple.Item3},{tuple.Item4},{tuple.Item5},{tuple.Item6}");
            }

            Console.ReadLine();
        }

        private static int GetTime(Tuple<int, int, int, int, int, string> t)
        {
            return int.Parse($"{t.Item4}{t.Item5}");
        }
    }
}
