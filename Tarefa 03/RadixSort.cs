using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class RadixSort
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

            try
            {
                int[] numList2;
                StreamReader file = new StreamReader(fileName);
                numList2 = new int[int.Parse(file.ReadLine())];

                while ((line = file.ReadLine()) != null)
                {
                    numList2[count] = int.Parse(line);
                    count++;
                }

                Console.WriteLine("input: " + string.Join(",", numList2) + "\n\n\n");
                Console.WriteLine("Radix Sort executado...");
                Console.WriteLine(string.Join(",", radixSort(numList2)));
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                Console.ReadKey();
            }


        }

        /// <summary>
        /// Gets the maximum number of the array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static int getMaxNumber(int[] arr)
        {
            int max = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static int[] radixSort(int[] arr)
        {
            int max = getMaxNumber(arr);
            for(int i = 1; (max/i) > 0; i *= 10)
            {
                //do counting sort, taking each number from their least significant
                //digit to the most significant digit in each for loop iteration
                countRad(arr, arr.Length, i);
            }
            return arr;
        }

        /// <summary>
        /// Counting sort for Radix Sort algorithm
        /// Code adaptation to C# language
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <param name="exp"></param>
        static void countRad(int[] arr, int n, int exp)
        {
            int[] output = new int[n];
            int i;
            int[] count = Enumerable.Repeat(0, 10).ToArray();

            //store count of each number
            for (i = 0; i < n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            //change count[i] so that count[i] contains actual pos of integer in output array
            for (i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            //build output array
            for (i = n-1; i >=0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }
            //assign each index of the array to each index of the output
            for (i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }


    }
}
