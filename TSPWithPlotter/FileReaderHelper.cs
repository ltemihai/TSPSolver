using System;
using System.Collections.Generic;
using System.Text;

namespace TravelingSalesmanProblem
{
    public static class FileReaderHelper
    {
        public static List<City> Cities { get; set; }

        public static void ReadValues(string fileName, List<City> list)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);

            for (int i = 6; i < lines.Length - 1; i++)
            {
                string[] values = lines[i].Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
                list.Add(new City
                {
                    Index = int.Parse(values[0]),
                    XCoordinate = int.Parse(values[1]),
                    YCoordinate = int.Parse(values[2])
                });
            }
        }
        /*
        public void WriteValues(int totalValue, int totalWeight, double executionTime, Dictionary<KnapsackObject, bool> solution, int? iteration, string method)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("D:\\Facultate\\DISI\\Knapsack\\Knapsack\\" + method + ".txt"))
            {
                file.WriteLine("/////////////////////////////////");
                file.WriteLine("Method:" + method);
                file.WriteLine("Iteration: " + iteration);
                file.WriteLine("Total Value: " + totalValue);
                file.WriteLine("Total Weight: " + totalWeight);
                file.WriteLine("Execution time: " + executionTime);
                foreach (KeyValuePair<KnapsackObject, bool> entry in solution)
                {
                    file.WriteLine(entry.Key.Index + " " + entry.Key.Value + " " + entry.Key.Weight);
                }
            }
        }
        */
    }
}
