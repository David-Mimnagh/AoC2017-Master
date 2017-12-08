using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Levels
{
    public class Level4
    {

        static List<string> passwordPhrases{ get; set; }
        static List<string> words { get; set; }
        static List<string> currentPassList { get; set; }
        static int matchCount { get; set; }




       // https://www.daniweb.com/programming/software-development/threads/349926/c-string-permutation
        static List<string> Permutations<T>(IList<T> list)
        {
            List<IList<T>> permChars = new List<IList<T>>();
            if (list.Count == 0)
                return new List<string>(); // Empty list.
            int factorial = 1;
            for (int i = 2; i <= list.Count; i++)
                factorial *= i;
            for (int v = 0; v < factorial; v++)
            {
                List<T> s = new List<T>(list);
                int k = v;
                for (int j = 2; j <= list.Count; j++)
                {
                    int other = (k % j);
                    T temp = s[j - 1];
                    s[j - 1] = s[other];
                    s[other] = temp;
                    k = k / j;
                }
                permChars.Add(s);
            }

            List<string> perms = new List<string>();

            for (int i = 0; i < permChars.Count; i++)
            {
                string adding = "";
                foreach (var pC in permChars[i])
                {
                    adding += pC;
                }
                perms.Add(adding);
            }

            return perms;
        }

        static string Part1(List<string> passwordPhrases)
        {
           
            foreach (var p in passwordPhrases)
            {
                words = p.Split(' ').ToList();
                currentPassList = new List<string>();
                foreach (var w in words)
                {
                    if(!currentPassList.Contains(w))
                    {
                        currentPassList.Add(w);
                    }
                }

                if (currentPassList.Count == words.Count)
                    matchCount += 1;
            }

            return matchCount.ToString();
        }

        static string Part2(List<string> passwordPhrases)
        {
           
            List<string> passPassList = new List<string>();
            bool breakIt = false;
            foreach (var p in passwordPhrases)
            {
                words = p.Split(' ').ToList();
                breakIt = false;
                currentPassList = new List<string>();

                foreach (var w in words)
                {
                    var charLetters = w.ToCharArray().ToList();

                    List<string> letters = new List<string>();

                    foreach (var cl in charLetters)
                    {
                        letters.Add(cl.ToString());
                    }


                    List<string> perms = Permutations(letters);

                    if (!currentPassList.Contains(w))
                    {
                        currentPassList.Add(w);
                    }

                    foreach (var perm in perms)
                    {
                        if (perm != w)
                        {
                            if (words.Contains(perm))
                            {
                                breakIt = true;
                                break;
                            }
                        }
                    }


                    if (breakIt) break;


                }
                if (currentPassList.Count == words.Count )
                { 
                    if(!breakIt)
                    matchCount += 1; 
                }

                 
                

            }
            return matchCount.ToString();
        }


        public string MainMethod(string inputString)
        {
            inputString = inputString.Replace("\r\n", "-");

            passwordPhrases = inputString.Split('-').ToList();
            words = new List<string>();

            currentPassList = new List<string>();

            matchCount = 0;
           //return "The answer to this level is: " + Part1(passwordPhrases);
            return "The answer to this level is: " + Part2(passwordPhrases);
        }
    }
}
