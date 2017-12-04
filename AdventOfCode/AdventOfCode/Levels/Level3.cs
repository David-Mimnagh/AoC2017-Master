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
            263 202 149 103 66  37  36  35  34  33  32  31  56  89  131 180 237
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
         * 8 * 1 = 8 + 1 -- ___
         * * 
         * 
         * 
         * 
         * 
         * 
         * 
         */
        
        public List<int> GetAllBottomRight(int yourNumber)
        {
            List<int> bottomRights = new List<int>();

            int counter = 1;
            int toGo = 1;
            for (int i = 1; i < (yourNumber * 2); i++)
            {
                if (toGo == counter)
                {
                    bottomRights.Add((8 * i) + 1);
                    toGo = 0;
                    counter += 1;
                }
                toGo += 1;
            }

            return bottomRights;
        }


        int GetManhattanDist(int x1,int y1, int x2,int y2)
        {
            return Math.Abs(x1 - y1) + Math.Abs(x2 - y2);
        }

        public string Part1(int from)
        {
           List<int> bRights =  GetAllBottomRight(from);
            int currentLowest = from;

           foreach (var bR in bRights)
           {
               if (bR > 360000)
                   currentLowest = currentLowest;
               if(bR < from)
               {
                 if( (from - bR) < currentLowest)
                     currentLowest = from - bR;
               }
               else
               {
                   if ((bR - from) < currentLowest)
                       currentLowest = bR - from;
               }
           }

           return currentLowest.ToString();
        }

        public string MainMethod(int startFrom)
        {

            return "The answer to this level is: " + Part1(startFrom);
            //return "The answer to this level is: " + Part2(inputString);
        }
    }
}
