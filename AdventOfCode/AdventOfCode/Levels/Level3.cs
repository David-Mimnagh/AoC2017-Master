using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Levels
{
    public class Level3
    {

        /*   
         * 
         * 
         * 
         *   258 257 256 255 254 253 252 251 250 249 248 247 246 245 244 243 242        
         *   259 198 197 196 195 194 193 192 191 190 189 188 187 186 185 184 241
         *   260 199 146 145 144 143 142 141 140 139 138 137 136 135 134 183 240
         *   261 200 147 101 100 99  98  97  96  95  94  93  92  91  133 182 239 
         *   262 201 148 102 65  64  63  62  61  60  59  58  57  90  132 181 238
         *   263 202 149 103 66  37  36  35  34  33  32  31  56  89  131 180 237
             264 203 150 104 67  38  17  16  15  14  13  30  55  88  130 179 236
             265 204 151 105 68  39  18  5   4   3   12  29  54  87  129 178 235
             266 205 152 106 69  40  19  6   1   2   11  28  53  86  128 177 234
             267 206 153 107 70  41  20  7   8   9   10  27  52  85  127 176 233
             268 207 154 108 71  42  21  22  23  24  25  26  51  84  126 175 232
             269 208 155 109 72  43  44  45  46  47  48  49  50  83  125 174 231
             270 209 156 110 73  74  75  76  77  78  79  80  81  82  124 173 230
         *   271 210 157 111 112 113 114 115 116 117 118 119 120 121 123 172 229
         *   272 211 158 159 160 161 162 163 164 165 166 167 168 169 170 171 228    
         *   273 212 213 214 215 216 217 218 219 220 221 222 223 224 225 226 227
         *   274 275 276 277 278 279 280 281 282 283 284 285 286 287 288 289 290 291     
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * WAS STRUGGLING WITH THIS ONE, TO CATCH UP - I GOT PERMISSION TO USE A FRIENDS CODE:
         * https://github.com/Bigbudddo/advent-of-code-2017/blob/master/AdventOfCode2017/Puzzles/Day3.cs
         * 
         */

        private enum Direction
        {
            Right,
            Up,
            Left,
            Down
        }

        private Direction GetDirection(Direction currentDirection)
        {
            int currentDirectionInt = this.GetDirectionInt(currentDirection);
            currentDirectionInt = (currentDirectionInt + 1) % 4;

            switch (currentDirectionInt)
            {
                case 0:
                    return Direction.Right;
                case 1:
                    return Direction.Up;
                case 2:
                    return Direction.Left;
                case 3:
                    return Direction.Down;
                default:
                    return Direction.Right;
            }
        }

        private int GetDirectionInt(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    return 0;
                case Direction.Up:
                    return 1;
                case Direction.Left:
                    return 2;
                case Direction.Down:
                    return 3;
                default:
                    return 0;
            }
        }

        private string GenerateCoordKey(int x, int y)
        {
            return string.Format("{0},{1}", x, y);
        }

        public string Part1(int getTo)
        {
            int result = 0;
            // handle the event we have a 1 input?? That way we take 0 steps!
            if (getTo > 1)
            {
                int x = 0, y = 0;
                int stepCounter = 1;
                int whileCounter = 1;
                bool stop = false;
                bool changeDirection = true;

                Direction direction = Direction.Right; // default-start
                Dictionary<string, int> coordValues = new Dictionary<string, int>();

                do
                {
                    for (int i = 0; i < stepCounter; i++)
                    {
                        switch (direction)
                        {
                            case Direction.Right:
                                x += 1;
                                break;
                            case Direction.Up:
                                y += 1;
                                break;
                            case Direction.Left:
                                x -= 1;
                                break;
                            case Direction.Down:
                                y -= 1;
                                break;
                        }

                        coordValues[this.GenerateCoordKey(x, y)] = whileCounter;
                        whileCounter++;

                        if (whileCounter == getTo)
                        {
                            stop = true;
                            break;
                        }
                    }

                    direction = this.GetDirection(direction);
                    changeDirection = !changeDirection;

                    if (changeDirection)
                    {
                        stepCounter++;
                    }
                } while (!stop);

                result = Math.Abs(x) + Math.Abs(y);
            }

            return "Part 1: " + result.ToString();
        }

        public string Part2(int getTo)
        {
            int result = 1; // since the first store will be 1!
            if (getTo > 1)
            {
                int x = 0, y = 0;
                int stepCounter = 1;
                bool stop = false;
                bool changeDirection = true;
                Direction direction = Direction.Right;

                var sumCollection = new Dictionary<string, int>() {
                    { "0,0", 1 }
                };

                do
                {
                    for (var i = 0; i < stepCounter; i++)
                    {
                        switch (direction)
                        {
                            case Direction.Right:
                                x += 1;
                                break;
                            case Direction.Up:
                                y += 1;
                                break;
                            case Direction.Left:
                                x -= 1;
                                break;
                            case Direction.Down:
                                y -= 1;
                                break;
                        }

                        // sum the neighbours?
                        int sum = 0;
                        int neighbourValue = 0;

                        // right
                        if (sumCollection.TryGetValue(GenerateCoordKey(x + 1, y), out neighbourValue))
                        {
                            sum += neighbourValue;
                        }
                        // right up
                        if (sumCollection.TryGetValue(GenerateCoordKey(x + 1, y + 1), out neighbourValue))
                        {
                            sum += neighbourValue;
                        }
                        // up
                        if (sumCollection.TryGetValue(GenerateCoordKey(x, y + 1), out neighbourValue))
                        {
                            sum += neighbourValue;
                        }
                        // up left
                        if (sumCollection.TryGetValue(GenerateCoordKey(x - 1, y + 1), out neighbourValue))
                        {
                            sum += neighbourValue;
                        }
                        // left
                        if (sumCollection.TryGetValue(GenerateCoordKey(x - 1, y), out neighbourValue))
                        {
                            sum += neighbourValue;
                        }
                        // left down
                        if (sumCollection.TryGetValue(GenerateCoordKey(x - 1, y - 1), out neighbourValue))
                        {
                            sum += neighbourValue;
                        }
                        // down
                        if (sumCollection.TryGetValue(GenerateCoordKey(x, y - 1), out neighbourValue))
                        {
                            sum += neighbourValue;
                        }
                        // down right
                        if (sumCollection.TryGetValue(GenerateCoordKey(x + 1, y - 1), out neighbourValue))
                        {
                            sum += neighbourValue;
                        }

                        sumCollection[GenerateCoordKey(x, y)] = sum;
                        if (sum > getTo)
                        {
                            result = sum;

                            stop = true;
                            break;
                        }
                    }

                    direction = this.GetDirection(direction);
                    changeDirection = !changeDirection;

                    if (changeDirection)
                    {
                        stepCounter++;
                    }
                } while (!stop);
            }

            return "Part 2: " + result.ToString();
        }
      
        public string MainMethod(int startFrom)
        {

            //return "The answer to this level is: " + Part1(startFrom);
            return "The answer to this level is: " + Part2(startFrom);
        }
    }
}
