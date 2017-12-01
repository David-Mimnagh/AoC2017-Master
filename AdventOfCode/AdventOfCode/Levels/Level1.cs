using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Levels
{
    public class Level1
    {
        int total { get; set; }
        int nextNum { get; set; }
        int currNum { get; set; }

        string Part1(string input)
        {
             for ( int i = 0; i < input.Length; i++ )
             {
                 currNum = Convert.ToInt32(input[i].ToString());
                 if ( ( i + 1 ) <= input.Length - 1 )
                     nextNum = Convert.ToInt32(input[i + 1].ToString());
                 else
                     nextNum = Convert.ToInt32(input[0].ToString());

                 if ( currNum == nextNum )
                     total += currNum;
             }
             return total.ToString();
        }

        string Part2(string input)
        {
            int halfLength = input.Length / 2;
            for ( int i = 0; i < input.Length; i++ )
            {
                currNum = Convert.ToInt32(input[i].ToString());
                int diff = ( input.Length ) - i;
                int toAdd = halfLength - diff;

                if ( ( i + halfLength ) <= input.Length - 1 )
                    nextNum = Convert.ToInt32(input[i + halfLength].ToString());
                else
                    nextNum = Convert.ToInt32(input[toAdd].ToString());

                if ( currNum == nextNum )
                    total += currNum;
            }
            return total.ToString();
        }

        public string MainMethod(string inputString)
        {

            total = 0;
            nextNum = -1;
            return "The answer to this level is: " + Part1(inputString);
            //return "The answer to this level is: " + Part2(inputString);
        }
    }
}
