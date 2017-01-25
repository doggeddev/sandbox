using System;
using System.Collections.Generic;


//Created by Richard Drexel 1/25/17.
//Locate pairs off integers in an array equal to target sum.


namespace sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //find a pair on integers that equal a sum

            int[] input = { 1, 2, 5, 10, 12, 21 };
            int sum = 22;

            int[] pairs = findPair(input, sum);

            Console.WriteLine(pairs[0] + " " + pairs[1]);
            Console.ReadLine();

        }

        static int[] findPair(int[] input, int sum)
        {
            //I could go through and count each pair, sum them up, and return the pair...
            //but that would be an O(n^2) solution. Not a big deal on a small input.

            //Can I make it better, say O(n) or O(logn), or O(1)... 
            //each pair is unique to the sum... uniques belong in a set...
            // a hashset would allow me to store values with a O(1) search time.
            //instead of looking for a sum, maybe identify  a difference?
            //So -- take sum minus input[i] (ex. 15 - 1 = 14). 
            //Look and see if 14 exists in the hashset. If so, then return input[i], 14 as the pair.

            HashSet<int> valuesToSearchThrough = new HashSet<int>();
            
            //load up the set
            foreach (int i in input)
            {
                valuesToSearchThrough.Add(i);
            }

            int[] differences = new int[input.Length];
            int index = 0;
            
            //determine the difference
            foreach(int i in input)
            {
                differences[index] = sum - i;
                index++;
            }

            int[] pair = new int[2];
            foreach(int i in differences)
            {
                if (valuesToSearchThrough.Contains(i))
                {
                    pair[0] = sum - i;
                    pair[1] = i;
                    return pair; 
                }
                else
                {
                    pair[0] = -9999;
                    pair[1] = -9999;

                }
            }
            return pair;
        }
    }
}
