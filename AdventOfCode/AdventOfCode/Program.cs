using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AdventOfCode.Levels;

namespace AdventOfCode
{
    class Program
    {

        public static int LEVELNUMBER { get; set; }
        public static Level1 l1;
        static string GetPuzzleInput()
        {
            return File.ReadAllText("..\\..\\Files\\level_"+LEVELNUMBER.ToString() +".txt");
        }

        static void Main(string[] args)
        {
            l1 = new Level1();
            LEVELNUMBER = 1;
            switch(LEVELNUMBER)
            {
                case 1:
                    Console.WriteLine(l1.MainMethod(GetPuzzleInput()));
                    break;
                case 2:
                    break;
            }
            Console.ReadLine();
        }
    }
}
