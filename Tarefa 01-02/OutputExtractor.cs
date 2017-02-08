using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class OutputExtractor
    {
        LinkedList<AlgorithmResults> results;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        public OutputExtractor(String args)
        {
            results = new LinkedList<AlgorithmResults>();

            try
            {
                string lineVal;
                System.IO.StreamReader reader = new System.IO.StreamReader(new System.IO.FileStream(args, System.IO.FileMode.Open, System.IO.FileAccess.Read));

                while((lineVal = reader.ReadLine()) != null)
                {
                    AlgorithmResults algoresults = new AlgorithmResults();

                    if(lineVal.StartsWith("10."))
                    {
                        algoresults.percentage = 10;
                    }

                    if (lineVal.StartsWith("50."))
                    {
                        algoresults.percentage = 50;
                    }

                    if(lineVal.StartsWith("90."))
                    {
                        algoresults.percentage = 90;
                    }

                    if (lineVal.Contains(".100000."))
                    {
                        algoresults.size = 100000;
                    }

                    if (lineVal.Contains(".1000000."))
                    {
                        algoresults.size = 1000000;
                    }

                    if (lineVal.Contains(".500000."))
                    {
                        algoresults.size = 500000;
                    }

                    algoresults.algorithm = reader.ReadLine();
                    long initTime = long.Parse(reader.ReadLine().Replace("begin ", ""));
                    long endTime = long.Parse(reader.ReadLine().Replace("end   ", ""));

                    algoresults.time = endTime - initTime;

                    reader.ReadLine();

                    results.AddLast(algoresults);
                    
                }
            } catch (Exception e)
            {
                e.GetBaseException();
            }

            saveToFile();
        }

        /// <summary>
        /// Saves data to file
        /// </summary>
        public void saveToFile()
        {
            string text = "";
            foreach(AlgorithmResults algorithmResults in results)
            {
                text += algorithmResults.toString();
            }

            System.IO.FileStream file = new System.IO.FileStream("excelOutput.out", System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
            try
            {
                BufferedStream txt = new BufferedStream(file);
                byte[] toBytes = Encoding.ASCII.GetBytes(text);
                txt.Close();
            } catch (IOException e)
            {
                e.GetBaseException();
            }
        }

        public static void main(string[] args)
        {
            OutputExtractor o = new OutputExtractor(args[0]);
        }

    }

    
    /// <summary>
    /// Class AlgorithmResults
    /// </summary>
    class AlgorithmResults
    {
        public string algorithm;
        public int size;
        public int percentage;
        public long time;

        /// <summary>
        /// Overriding method toString
        /// </summary>
        /// <returns></returns>
        public string toString()
        {
            return algorithm + "\t" + size.ToString() + "\t" + percentage.ToString() + "%\t" + time.ToString() + "\n";
        }
    }
}
