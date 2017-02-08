using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class BucketSort
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
                Console.WriteLine("Bucket Sort executado...");
                Console.WriteLine(string.Join(",", bucketSort(numList2, 40)));
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                Console.ReadKey();
            }


        }

        /// <summary>
        /// Bucket Sort algorithm adaptation to C# language
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="numBuckets"></param>
        /// <returns></returns>
        static int[] bucketSort(int[] arr, int numBuckets)
        {
            if (numBuckets <= 0) throw new Exception("Numero de buckets deve ser maior que zero.");
            if (arr.Length <= 1) return arr;

            int highest = arr[0];
            int lowest = arr[0];

            //This for loop will find the highest and lowest number in the list (values range)
            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] > highest)
                {
                    highest = arr[i];
                }

                if(arr[i] < lowest)
                {
                    lowest = arr[i];
                }
            }

            int range = (int)(highest - lowest + 1) / numBuckets;    //interval of a list

            List<int>[] buckets = new List<int>[numBuckets];        //this will create an array of lists representing each bucket in the program.

            //Initialize buckets
            for(int i = 0; i < numBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            //Adding each array element into the bucket list, partitioning the array
            for(int j = 0; j < arr.Length; j++)
            {
                buckets[(int)((arr[j] - lowest) / range)/numBuckets].Add(arr[j]);
            }

            int pt = 0;

            //order each bucket into an ascending order and puts each element from each bucket into the array again
            for(int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = buckets[i].OrderBy(p => p).ToList();

                for(int k = 0; k < buckets[i].Count(); k++)
                {
                    arr[pt] = buckets[i].ElementAt(k);
                    pt++;
                }
            }

            return arr;
        }
    }
}
