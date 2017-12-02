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
        public static Level2 l2;
        static string GetPuzzleInput()
        {
            return File.ReadAllText("..\\..\\Files\\level_"+LEVELNUMBER.ToString() +".txt");
        }

        static void Main(string[] args)
        {
            l1 = new Level1();
            l2 = new Level2();
            LEVELNUMBER = 2;
            switch(LEVELNUMBER)
            {
                case 1:
                    Console.WriteLine(l1.MainMethod(GetPuzzleInput()));
                    break;
                case 2:
                    Console.WriteLine(l2.MainMethod(GetPuzzleInput()));
                    break;
            }
            Console.ReadLine();
        }
    }
}
