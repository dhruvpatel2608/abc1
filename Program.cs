using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStructure
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 2 || !int.TryParse(args[0], out int numElements) || !int.TryParse(args[1], out int numTestElements))
            {
                Console.WriteLine("Usage: <program> <numElements> <numTestElements>");
                return;
            }

            if (numElements < 500 || numElements > 10000000 || numTestElements < 1 || numTestElements > (numElements / 100))
            {
                Console.WriteLine("Error: Invalid input ranges.");
                return;
            }

            string[] stringArray = new string[numElements];
            List<string> stringList = new List<string>(numElements);
            ArrayList arrayList = new ArrayList(numElements);

            for (int i = 0; i < numElements; i++)
            {
                string guidString = Guid.NewGuid().ToString();
                stringArray[i] = guidString;
                stringList.Add(guidString);
                arrayList.Add(guidString);
            }

            // Step 4: Sort the List and ArrayList for binary search
            stringList.Sort();
            arrayList.Sort();

            // Step 5: Create valid test data (randomly chosen without duplicates)
            string[] validTestArray = new string[numTestElements];
            Random rand = new Random();
            HashSet<int> chosenIndices = new HashSet<int>();

            for (long i = 0; i < numTestElements; i++)
            {
                int randomIndex;
                do
                {
                    randomIndex = rand.Next(0, numElements);
                } while (chosenIndices.Contains(randomIndex));

                validTestArray[i] = stringArray[randomIndex];
                chosenIndices.Add(randomIndex);
            }

            // Step 6: Create invalid test data (random GUIDs)
            string[] invalidTestArray = new string[numTestElements];
            for (int i = 0; i < numTestElements; i++)
            {
                invalidTestArray[i] = Guid.NewGuid().ToString();
            }

            // Step 7: Execute tests and measure performance
            Stopwatch sw = new Stopwatch();

            // Test 1: Array.Find() with valid data
            sw.Start();
            for (long i = 0; i < validTestArray.Length; i++)
            {
                Array.Find(stringArray, x => x == validTestArray[i]);
            }
            sw.Stop();
            Console.WriteLine("Array.Find()             valid test took: " + sw.Elapsed.TotalMilliseconds + " ms");

            // Test 2: List.Find() with valid data
            sw.Reset();
            sw.Start();
            for (long i = 0; i < validTestArray.Length; i++)
            {
                stringList.Find(x => x == validTestArray[i]);
            }
            sw.Stop();
            Console.WriteLine("List.Find()              valid test took: " + sw.Elapsed.TotalMilliseconds + " ms");

            // Test 3: List.BinarySearch() with valid data
            sw.Reset();
            sw.Start();
            for (long i = 0; i < validTestArray.Length; i++)
            {
                stringList.BinarySearch(validTestArray[i]);
            }
            sw.Stop();
            Console.WriteLine("List.BinarySearch()      valid test took: " + sw.Elapsed.TotalMilliseconds + " ms");

            // Test 4: ArrayList.BinarySearch() with valid data
            sw.Reset();
            sw.Start();
            for (long i = 0; i < validTestArray.Length; i++)
            {
                arrayList.BinarySearch(validTestArray[i]);
            }
            sw.Stop();
            Console.WriteLine("ArrayList.BinarySearch() valid test took: " + sw.Elapsed.TotalMilliseconds + " ms");
            Console.WriteLine();

            // Test 5: Array.Find() with invalid data
            sw.Reset();
            sw.Start();
            for (long i = 0; i < invalidTestArray.Length; i++)
            {
                Array.Find(stringArray, x => x == invalidTestArray[i]);
            }
            sw.Stop();
            Console.WriteLine("Array.Find()             invalid test took: " + sw.Elapsed.TotalMilliseconds + " ms");

            // Test 6: List.Find() with invalid data
            sw.Reset();
            sw.Start();
            for (long i = 0; i < invalidTestArray.Length; i++)
            {
                stringList.Find(x => x == invalidTestArray[i]);
            }
            sw.Stop();
            Console.WriteLine("List.Find()              invalid test took: " + sw.Elapsed.TotalMilliseconds + " ms");

            // Test 7: List.BinarySearch() with invalid data
            sw.Reset();
            sw.Start();
            for (long i = 0; i < invalidTestArray.Length; i++)
            {
                stringList.BinarySearch(invalidTestArray[i]);
            }
            sw.Stop();
            Console.WriteLine("List.BinarySearch()      invalid test took: " + sw.Elapsed.TotalMilliseconds + " ms");

            // Test 8: ArrayList.BinarySearch() with invalid data
            sw.Reset();
            sw.Start();
            for (long i = 0; i < invalidTestArray.Length; i++)
            {
                arrayList.BinarySearch(invalidTestArray[i]);
            }
            sw.Stop();
            Console.WriteLine("ArrayList.BinarySearch() invalid test took: " + sw.Elapsed.TotalMilliseconds + " ms");
            Console.WriteLine();

            // Step 8: Report test results
            Console.WriteLine("Command line arguments: numElements = {0}, numTestElements = {1}", numElements, numTestElements);
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
    }
}