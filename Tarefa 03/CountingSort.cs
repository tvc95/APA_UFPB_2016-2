using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingRadixBucket
{
    class CountingSort
    {
        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int count = 0;
            string fileName = "lol.txt";
            string line;
            int[] numList;

            try
            {
                StreamReader file = new StreamReader(fileName);
                numList = new int[int.Parse(file.ReadLine())];

                while ((line = file.ReadLine()) != null)
                {
                    numList[count] = int.Parse(line);
                    count++;
                }

                Console.WriteLine("input: " + string.Join(",", numList) + "\n\n\n");
                Console.WriteLine("Counting Sort executado...");
                Console.WriteLine(string.Join(",", countSort(numList)));
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                Console.ReadKey();
            }


        }


        /// <summary>
        /// Adaptation of countingSort algorithm to C# language.
        /// </summary>
        /// <param name="arr"></param>
        public static int[] countSort(int[] arr)
        {

            try
            {
                int n = arr.Length;
                int k = 1000000;
                int[] output = new int[n];
                int[] count = Enumerable.Repeat(0, k).ToArray(); //initialize array as 0

                //store count of each number
                for (int j = 0; j < n; ++j)
                {
                    ++count[arr[j]];
                }

                //change count[i] so that count[i] contains actual pos of integer in output array
                for (int i = 1; i < k; ++i)
                {
                    count[i] += count[i - 1];
                }

                //build output array
                for (int i = 0; i < n; ++i)
                {
                    output[count[arr[i]] - 1] = arr[i];
                    //Console.WriteLine(output[count[arr[i]] - 1]);
                    --count[arr[i]];
                }

                return output;
            } catch(Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                Console.ReadKey();
            }

            return null;
            
        }
    }
}
