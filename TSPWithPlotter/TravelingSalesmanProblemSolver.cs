using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TravelingSalesmanProblem
{
    public class TravelingSalesmanProblemSolver
    {
        public List<City> Cities { get; set; }
        public int[,] Map { get; set; }
        public Random random = new Random();
        public List<City> TwoOptMethod(string path)
        {
            Cities = new List<City>();
            FileReaderHelper.ReadValues(path, Cities);
            Map = GenerateMap();
            List<City> solution = GenerateRandomSolution();
            int firstDistance = CalculateDistanceBetweenCities(solution);
            int iterations = 0;
            int initialDistance = 0;
            int newDistance = 0;
            int startIndex = 0;
            int endIndex = 0;
            List<City> newSolution = new List<City>(solution);
            bool MoreTransfomations = true;
            while (iterations < 1000)
            {
                newSolution = new List<City>(solution);
                initialDistance = CalculateDistanceBetweenCities(solution);
                newDistance = 0;
                startIndex = random.Next(0, Cities.Count);
                endIndex = random.Next(startIndex, Cities.Count);
                for (int i = startIndex; i <= endIndex; i++)
                {
                    City temporary = newSolution[i];
                    newSolution[i] = newSolution[endIndex];
                    newSolution[endIndex] = temporary;
                    endIndex--;
                }
                newDistance = CalculateDistanceBetweenCities(newSolution);
                if(newDistance < initialDistance)
                {
                    solution = newSolution;
                    iterations = 0;   
                }
                else
                {
                    iterations++;
                }
            }
            Console.WriteLine("Initial distance: " + firstDistance);
            Console.WriteLine("Final distance: " + newDistance);
            return newSolution;
        }
        


        public List<City> GreedyMethod(string path)
        {
            Cities = new List<City>();
            FileReaderHelper.ReadValues(path, Cities);
            Map = GenerateMap();
            List<City> solution = new List<City>
            {
                GenerateRandomSolution().First<City>()
            };
            while(solution.Count < Cities.Count-1) {
                solution.Add(GetNearestNeighbourCity(solution.Last<City>(), solution));
            }

            Console.WriteLine("Total distance: " + CalculateDistanceBetweenCities(solution));
            return solution;
        }

        public List<City> SimulatedAnnealing(string path)
        {
            double temperature = 10000;
            double alpha = 0.9999;
            double minimTemperature = 0.00001;

            Cities = new List<City>();
            FileReaderHelper.ReadValues(path, Cities);
            Map = GenerateMap();
            int startIndex = 0;
            int endIndex = 0;
            List<City> solution = GenerateRandomSolution();
            while (temperature > minimTemperature)
            {
                startIndex = random.Next(0, Cities.Count);
                endIndex = random.Next(startIndex, Cities.Count);
                List<City> temporarySolution = GetTwoOptNeighbour(startIndex, endIndex, solution);
                int solutionTotalDistance = CalculateDistanceBetweenCities(solution);
                int temporarySolutionTotalDistance = CalculateDistanceBetweenCities(temporarySolution);
                int delta = temporarySolutionTotalDistance - solutionTotalDistance;
                if (delta < 0)
                {
                    solution = temporarySolution;
                } else if (random.NextDouble() < Math.Exp(-delta / temperature))
                {
                    solution = temporarySolution;
                }
                temperature = alpha * temperature;
            }
            Console.WriteLine("Total distance: " + CalculateDistanceBetweenCities(solution));
            return solution;
        }

        public List<City> GetTwoOptNeighbour(int startIndex, int endIndex, List<City> cities)
        {
            List<City> neighbour = new List<City>(cities);
            for (int i = startIndex; i <= endIndex; i++)
            {
                City temporary = neighbour[i];
                neighbour[i] = neighbour[endIndex];
                neighbour[endIndex] = temporary;
                endIndex--;
            }
            return neighbour;
        }

        private City GetNearestNeighbourCity(City city, List<City> solution)
        {
            int minimum = int.MaxValue;
            int cityIndex = -1;
            for(int i = 0; i < Cities.Count - 1; i++)
            {
                if (Map[city.Index - 1, i] < minimum && !solution.Contains(Cities[i]))
                {
                    minimum = Map[city.Index - 1, i];
                    cityIndex = i;
                }
            }
            return Cities[cityIndex];
        }

        public List<City> GenerateRandomSolution()
        {
            List<City> randomSolution = new List<City>(Cities);
            return randomSolution.OrderBy<City,int>((item) => random.Next()).ToList<City>();
        }

        private int CalculateDistanceBetweenCities(List<City> cities)
        {
            int totalDistance = 0;
            for(int i = 0; i < cities.Count-2; i++)
            {
                totalDistance += Map[cities[i].Index-1, cities[i+1].Index-1];
            }
            return totalDistance;
        }
        private int[,] GenerateMap()
        {
            int size = Cities.Count;
            int[,] map = new int[size, size];
            for(int i = 0; i < size ; i++)
            {
                for(int j = 0; j < size ; j++)
                {
                    map[i,j] = CalculateDistance(Cities[i], Cities[j]);
                }
            }
            return map;
        }

        private int CalculateDistance(City startingCity, City destinationCity)
        {
            return (int)Math.Sqrt((startingCity.XCoordinate - destinationCity.XCoordinate) * (startingCity.XCoordinate - destinationCity.XCoordinate) +
                (startingCity.YCoordinate - destinationCity.YCoordinate) * (startingCity.YCoordinate - destinationCity.YCoordinate));
        }

        private void PrintMap()
        {
            Map = GenerateMap();
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.Write(Map[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
