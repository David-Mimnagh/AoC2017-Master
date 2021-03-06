﻿using System;
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
        public static Level3 l3;
        public static Level4 l4;
        public static Level5 l5;
        public static Level6 l6;

        static string GetPuzzleInput()
        {
            return File.ReadAllText("..\\..\\Files\\level_"+LEVELNUMBER.ToString() +".txt");
        }

        static void Main(string[] args)
        {
            l1 = new Level1();
            l2 = new Level2();
            l3 = new Level3();
            l4 = new Level4();
            l5 = new Level5();
            l6 = new Level6();

            LEVELNUMBER = 6;
            switch(LEVELNUMBER)
            {
                case 1:
                    Console.WriteLine(l1.MainMethod(GetPuzzleInput()));
                    break;
                case 2:
                    Console.WriteLine(l2.MainMethod(GetPuzzleInput()));
                    break;
                case 3:
                    Console.WriteLine(l3.MainMethod(368078));
                    break;
                case 4:
                    Console.WriteLine(l4.MainMethod(GetPuzzleInput()));
                    break;
                case 5:
                    Console.WriteLine(l5.MainMethod(GetPuzzleInput()));
                    break;
                case 6:
                    Console.WriteLine(l6.MainMethod(GetPuzzleInput()));
                    break;
            }
            Console.ReadLine();
        }
    }
}
