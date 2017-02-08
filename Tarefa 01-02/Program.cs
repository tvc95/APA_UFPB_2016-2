using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            System.IO.TextReader leOp = System.Console.In;
            int count = 0;
            LinkedList<int> numbersList = new LinkedList<int>();
            string filename = "lol.txt";
            string line;

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    if (count != 0)
                    {
                        numbersList.AddLast(int.Parse(line));
                    }
                    count++;
                }
                file.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }
            

            while (true)
            {
                Console.WriteLine("Selecione método de ordenação:\n"
                         + "1 - Selection Sort \n2 - Insertion Sort \n3 - Merge Sort \n4 - Quicksort \n5 - Heapsort");
                int opcao = int.Parse(leOp.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Selection sort executado...\n==================================================================");
                        Console.WriteLine(string.Join(",", SelectionSort(numbersList).Select(p => p.ToString()).ToArray()));
                        break;
                    case 2:
                        Console.WriteLine("Insertion sort executado...\n==================================================================");
                        Console.WriteLine(string.Join(",", insertionSort(numbersList).Select(p => p.ToString()).ToArray()));
                        break;
                    case 3:
                        Console.WriteLine("Merge Sort executado...\n======================================================================");
                        int[] orderedList = new int[numbersList.Count];
                        for (int i = 0; i < numbersList.Count; i++)
                        {
                            orderedList[i] = (int)numbersList.ElementAt(i);
                        }
                        Console.WriteLine(string.Join(",", mergeSort(orderedList).Select(p => p.ToString()).ToArray()));
                        break;
                    case 4:
                        Console.WriteLine("Quick Sort executado...\n======================================================================");
                        Console.WriteLine(string.Join(",", quickSort(numbersList, 0, numbersList.Count - 1).Select(p => p.ToString()).ToArray()));
                        break;
                    case 5:
                        Console.WriteLine("Heap Sort executado...\n======================================================================");
                        Console.WriteLine(string.Join(",", heapSort(numbersList).Select(p => p.ToString()).ToArray()));
                        break;
                    default:
                        Console.WriteLine("Saindo...");
                        Environment.Exit(0);
                        break;

                }
            }
        }

        /// <summary>
        /// Selection Sort implementation
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static LinkedList<int> SelectionSort(LinkedList<int> list)
        {
            LinkedList<int> orderedList = list;
            int minNumber, minIndex;

            for (int i = 0; i < orderedList.Count - 1; i++)
            {
                minNumber = orderedList.ElementAt(i);
                minIndex = i;

                //Compares the integer value to be evaluated with other values of the list
                for (int j = i + 1; j < orderedList.Count; j++)
                {
                    if (orderedList.ElementAt(j) < minNumber)
                    {
                        minNumber = orderedList.ElementAt(j);
                        minIndex = j;
                    }
                }

                //trade integers position
                orderedList.Find(orderedList.ElementAt(minIndex)).Value = orderedList.ElementAt(i);
                orderedList.Find(orderedList.ElementAt(i)).Value = minNumber;
            }

            return orderedList;
        }

        /// <summary>
        /// Insertion Sort implementation
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static LinkedList<int> insertionSort(LinkedList<int> list)
        {
            LinkedList<int> orderedList = list;
            for (int i = 1; i < list.Count; i++)
            {
                int key = list.ElementAt(i);
                int j = i;

                while ((j > 0) && (list.ElementAt(j - 1) > key))
                {
                    list.Find(list.ElementAt(j)).Value = list.ElementAt(j - 1);
                    j -= 1;
                }

                list.Find(list.ElementAt(j)).Value = key;
            }

            return list;
        }

        /// <summary>
        /// Merge Sort implementation
        /// </summary>
        /// <param name="orderedList"></param>
        /// <returns></returns>
        public static int[] mergeSort(int[] orderedList)
        {
            if (orderedList.Length > 1)
            {
                int elemArray1 = orderedList.Length / 2;
                int elemArray2 = orderedList.Length - elemArray1;

                //splits the orderedList into two sub arrays
                int[] subArray1 = new int[elemArray1];
                int[] subArray2 = new int[elemArray2];

                for (int ai = 0; ai < elemArray1; ai++)
                {
                    subArray1[ai] = orderedList[ai];
                }

                for (int aj = elemArray1; aj < elemArray1 + elemArray2; aj++)
                {
                    subArray2[aj - elemArray1] = orderedList[aj];
                }

                subArray1 = mergeSort(subArray1);
                subArray2 = mergeSort(subArray2);

                int i = 0, j = 0, k = 0;

                while (subArray1.Length != j && subArray2.Length != k)
                {
                    if (subArray1[j] < subArray2[k])
                    {
                        orderedList[i] = subArray1[j];
                        i++;
                        j++;
                    }
                    else
                    {
                        orderedList[i] = subArray2[k];
                        i++;
                        k++;
                    }
                }

                while (subArray1.Length != j)
                {
                    orderedList[i] = subArray1[j];
                    i++;
                    j++;
                }
                while (subArray2.Length != k)
                {
                    orderedList[i] = subArray2[k];
                    i++;
                    k++;
                }
            }

            return orderedList;
        }

        /// <summary>
        /// Quicksort implementation
        /// </summary>
        /// <param name="list"></param>
        /// <param name="beginIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static LinkedList<int> quickSort(LinkedList<int> list, int beginIndex, int endIndex)
        {
            LinkedList<int> orderedList = list;
            if (beginIndex < endIndex)
            {
                int middle = divide(orderedList, beginIndex, endIndex);
                quickSort(orderedList, beginIndex, middle - 1);
                quickSort(orderedList, middle, endIndex);
            }

            return orderedList;
        }

        static int divide(LinkedList<int> list, int beginIndex, int endIndex)
        {
            int pivot = list.ElementAt(endIndex);
            int i = beginIndex;

            for (int j = beginIndex; j <= endIndex - 1; j++)
            {
                if (list.ElementAt(j).CompareTo(pivot) < 1)
                {
                    int aux = list.ElementAt(i);
                    list.Find(list.ElementAt(i)).Value = list.ElementAt(j);
                    list.Find(list.ElementAt(j)).Value = aux;
                    i++;
                }
            }

            int aux2 = list.ElementAt(i);
            list.Find(list.ElementAt(i)).Value = list.ElementAt(endIndex);
            list.Find(list.ElementAt(endIndex)).Value = aux2;

            return i;
        }

        /// <summary>
        /// Heap Sort implementation
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static LinkedList<int> heapSort(LinkedList<int> data)
        {
            int heapSize = data.Count;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                MaxHeapify(data, heapSize, p);

            for (int i = data.Count - 1; i > 0; --i)
            {
                int temp = data.ElementAt(i);
                data.Find(data.ElementAt(i)).Value = data.ElementAt(0);
                data.Find(data.ElementAt(0)).Value = temp;

                --heapSize;
                MaxHeapify(data, heapSize, 0);
            }
            return data;
        }

        private static void MaxHeapify(LinkedList<int> data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && data.ElementAt(left) > data.ElementAt(index))
                largest = left;
            else
                largest = index;

            if (right < heapSize && data.ElementAt(right) > data.ElementAt(largest))
                largest = right;

            if (largest != index)
            {
                int temp = data.ElementAt(index);
                data.Find(data.ElementAt(index)).Value = data.ElementAt(largest);
                data.Find(data.ElementAt(largest)).Value = temp;

                MaxHeapify(data, heapSize, largest);
            }
        }

    }
}
