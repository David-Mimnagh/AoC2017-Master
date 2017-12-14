using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Levels
{
    public class Level5
    {
        static int StepsTaken { get; set; }
        static string Part1(string puzzleInput)
        {
            puzzleInput = puzzleInput.Replace("\r\n", "=");
            List<string> numberStrings = puzzleInput.Split('=').ToList();
            List<int> numbers = new List<int>();
            foreach (var nS in numberStrings)
	        {
                numbers.Add(Convert.ToInt32(nS));
            }

            int currentIndex = 0;
            while (currentIndex < numbers.Count)
            {
                int currentNumber = numbers[currentIndex];

                numbers[currentIndex] += 1;
                currentIndex += currentNumber;
                StepsTaken += 1;

            }


            return StepsTaken.ToString();
        }
        static string Part2(string puzzleInput)
        {
            puzzleInput = puzzleInput.Replace("\r\n", "=");
            List<string> numberStrings = puzzleInput.Split('=').ToList();
            List<int> numbers = new List<int>();
            foreach (var nS in numberStrings)
            {
                numbers.Add(Convert.ToInt32(nS));
            }

            int currentIndex = 0;
            while (currentIndex < numbers.Count)
            {
                int currentNumber = numbers[currentIndex];

                if (currentNumber >= 3)
                    numbers[currentIndex] -= 1;
                else
                numbers[currentIndex] += 1;

                currentIndex += currentNumber;
                StepsTaken += 1;

            }


            return StepsTaken.ToString();
        }
        public string MainMethod(string inputString)
        {
            StepsTaken = 0;
            //return "The answer to this level is: " + Part1(inputString);
            return "The answer to this level is: " + Part2(inputString);
        }
    }
}
