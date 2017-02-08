using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class FileIO
    {

        /// <summary>
        /// Reads each number from a specific file address
        /// </summary>
        /// <param name="args"></param>
        /// <param name="fileIndex"></param>
        /// <returns></returns>
        public static int[] Input(String[] args, int fileIndex)
        {
            try
            {
                int[] values;

                if(args == null || args.Length == 0)
                {
                    Console.Error.WriteLine("Parâmetro vazio! A localização do arquivo deve ser inserida!");
                    Environment.Exit(1);
                }

                String numLine;
                int line = 0;
                System.IO.StreamReader fileReader = new System.IO.StreamReader(args[fileIndex]);
                values = new int[int.Parse(fileReader.ReadLine())];

                while((numLine = fileReader.ReadLine()) != null)
                {
                    values[line++] = int.Parse(numLine);
                }

                return values;
                
            } catch(Exception e)
            {
                e.GetBaseException();
            }

            return null;
        }

        /// <summary>
        /// Overriden method. Reads number data from a file
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static int[] Input(String[] args)
        {
            int[] values;
            string line;

            System.IO.TextReader scanner = System.Console.In;
            if((line = scanner.ReadLine()) != null) //if scanner.hasNext()
            {
                values = new int[int.Parse(line)];

                for (int i = 0; (line = scanner.ReadLine()) != null; i++)
                {
                    values[i] = int.Parse(line);
                }

                scanner.Close();
                return values;
            } else
            {
                try
                {
                    if (args == null || args.Length == 0)
                    {
                        Console.Error.WriteLine("Parâmetro vazio! A localização do arquivo deve ser inserida!");
                        Environment.Exit(1);
                    }

                    int fileIndex = 0;
                    string lineVal;
                    int line = 0;
                    System.IO.StreamReader fileReader = new System.IO.StreamReader(args[fileIndex]);
                    values = new int[int.Parse(fileReader.ReadLine())];

                    while ((numLine = fileReader.ReadLine()) != null)
                    {
                        values[line++] = int.Parse(numLine);
                    }

                    return values;

                } catch (Exception e)
                {
                    e.GetBaseException();
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the ordered list of numbers
        /// </summary>
        /// <param name="sortedNumbers"></param>
        static void fileOutput(int[] sortedNumbers)
        {
            Console.WriteLine(string.Join(" ", sortedNumbers));
        }

        /// <summary>
        /// Saves the output in a text file.
        /// </summary>
        /// <param name="log"></param>
        public static void saveOutput(String log)
        {
            System.IO.FileStream file = new System.IO.FileStream("output.out", System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);

            try
            {
                System.IO.BufferedStream txt = new System.IO.BufferedStream(file);

                byte[] toBytes = Encoding.ASCII.GetBytes(log);
                txt.Write(toBytes, 0, toBytes.Length);

                txt.Close();
            } catch(Exception e)
            {
                Console.Error.WriteLine("Invalid file or place: " + e.GetBaseException());
            }
        }
    }
}
