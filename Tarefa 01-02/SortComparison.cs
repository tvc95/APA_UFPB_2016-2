using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SortComparison
    {
        private static string log;

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        public static void main(string[] args)
        {
            System.DateTime cal = DateTime.Now;
            Console.WriteLine("Init time: " + cal.Hour + ":" + cal.Minute + ":" + cal.Second);

            log = "";

            for(int index = 0; index < args.Length; index++)
            {
                int[] unsortedNumbers = FileIO.Input(args, index);

                prepare(args, index, "QuickSort");
                Program.quickSort(new LinkedList<int>(unsortedNumbers), 0, unsortedNumbers.Length - 1);
                log += "end   " + System.Diagnostics.Stopwatch.GetTimestamp() + "\n\n";
            }

            for (int index = 0; index < args.Length; index++)
            {
                int[] unsortedNumbers = FileIO.Input(args, index);

                prepare(args, index, "InsertionSort");

                Program.insertionSort(new LinkedList<int>(unsortedNumbers));
                log += "end   " + System.Diagnostics.Stopwatch.GetTimestamp() + "\n\n";

            }

            for (int index = 0; index < args.Length; index++)
            {
                int[] unsortedNumbers = FileIO.Input(args, index);

                prepare(args, index, "HeapSort");

                Program.heapSort(new LinkedList<int>(unsortedNumbers));
                log += "end   " + System.Diagnostics.Stopwatch.GetTimestamp() + "\n\n";

            }

            for (int index = 0; index < args.Length; index++)
            {
                int[] unsortedNumbers = FileIO.Input(args, index);

                prepare(args, index, "SelectionSort");

                Program.SelectionSort(new LinkedList<int>(unsortedNumbers));
                log += "end   " + System.Diagnostics.Stopwatch.GetTimestamp() + "\n\n";

            }

            for (int index = 0; index < args.Length; index++)
            {
                int[] unsortedNumbers = FileIO.Input(args, index);

                prepare(args, index, "MergeSort");

                Program.mergeSort(unsortedNumbers);
                log += "end   " + System.Diagnostics.Stopwatch.GetTimestamp() + "\n\n";

            }

            Console.WriteLine(log);
            FileIO.saveOutput(log);

            System.DateTime calf = DateTime.Now;
            Console.WriteLine("End time: " + calf.Hour + ":" + calf.Minute + ":" + calf.Second);

        }

        /// <summary>
        /// Prepare method
        /// </summary>
        /// <param name="args"></param>
        /// <param name="index"></param>
        /// <param name="algorithm"></param>
        public static void prepare(string[] args, int index, string algorithm)
        {
            string file = System.IO.Path.GetFileName(args[index]);
            Console.Write(file + " " + algorithm + "\n");
            log += file + "\n";
            log += algorithm + "\n";
            log += "begin " + System.Diagnostics.Stopwatch.GetTimestamp() + "\n";



        }
    }
}
