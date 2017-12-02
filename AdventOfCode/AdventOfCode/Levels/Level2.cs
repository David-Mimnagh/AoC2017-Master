using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Levels
{
    public class Level2
    {
        public int Highest { get; set; }
        public int Lowest { get; set; }
        public int DiffTotal { get; set; }

        public string Part1(string input)
        {
            input = input.Replace("\r\n", "-");
            List<string> rows = input.Split('-').ToList(); // get rows

            foreach (var row in rows)//each row
            {
                var columns = row.Split('\t'); // split to columns

                var numbers = columns.Select(col => int.Parse(col)); // get all numbers from rows columns

                DiffTotal += numbers.Max() - numbers.Min(); // get the max min diff from it
            }
            return DiffTotal.ToString();
        }

        public string Part2(string input)
        {
            input = input.Replace("\r\n", "-");
            List<string> rows = input.Split('-').ToList(); // get rows


            List<Tuple<int, int>> DivNums = new List<Tuple<int, int>>();
            bool Found = false;
            foreach (var row in rows)//each row
            {
                Found = false;
                var columns = row.Split('\t'); // split to columns

                var numbers = columns.Select(col => int.Parse(col)); // get all numbers from rows columns

                if (!Found)
                {
                    foreach (var n in numbers)
                    {
                        var nums = numbers.ToArray();
                        for (int i = 0; i < nums.Count(); i++)
                        {
                            if (n != nums[i])
                            {
                                if (n % nums[i] == 0 || nums[i] % n == 0)
                                {
                                    DivNums.Add(new Tuple<int, int>(n, nums[i]));
                                    Found = true;
                                    break;
                                }
                            }
                        }
                        if (Found) break;
                    }
                }
            }

            foreach (var dN in DivNums)
            {
                if (dN.Item1 > dN.Item2)
                    DiffTotal += dN.Item1 / dN.Item2;
                else
                    DiffTotal += dN.Item2 / dN.Item1;

            }
            return DiffTotal.ToString();
        }

        public string MainMethod(string inputString)
        {
            Highest = 0;
            Lowest = 10;
            DiffTotal = 0;

            //return "The answer to this level is: " + Part1(inputString);
            return "The answer to this level is: " + Part2(inputString);
        }
    }
}
