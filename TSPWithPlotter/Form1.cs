using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelingSalesmanProblem;

namespace TSPWithPlotter
{
    public partial class Form1 : Form
    {
        public TravelingSalesmanProblemSolver Solver { get; set; }
        public Point[] Points { get; set; }
        public Form1()
        {
            Solver = new TravelingSalesmanProblemSolver();
            InitializeComponent();
            AllocConsole();
            string kroC100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroC100.tsp";
            string kroD100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroD100.tsp";
            TravelingSalesmanProblemSolver solver = new TravelingSalesmanProblemSolver();
            Console.WriteLine("/// TWO - OPT METHOD - kroC100 ///");
            solver.TwoOptMethod(kroC100);
            solver.TwoOptMethod(kroC100);
            solver.TwoOptMethod(kroC100);
            solver.TwoOptMethod(kroC100);
            solver.TwoOptMethod(kroC100);
            Console.WriteLine("/// TWO - OPT METHOD - kroD100 ///");
            solver.TwoOptMethod(kroD100);
            solver.TwoOptMethod(kroD100);
            solver.TwoOptMethod(kroD100);
            solver.TwoOptMethod(kroD100);
            solver.TwoOptMethod(kroD100);
            Console.WriteLine("/// GREEDY METHOD - kroC100 ///");
            solver.GreedyMethod(kroC100);
            Console.WriteLine("/// GREEDY METHOD - kroD100 ///");
            solver.GreedyMethod(kroD100);
            Console.WriteLine("/// Simulated Annealing - kroC100 ///");
            solver.SimulatedAnnealing(kroC100);
            solver.SimulatedAnnealing(kroC100);
            solver.SimulatedAnnealing(kroC100);
            solver.SimulatedAnnealing(kroC100);
            solver.SimulatedAnnealing(kroC100);
            Console.WriteLine("/// Simulated Annealing - kroD100 ///");
            solver.SimulatedAnnealing(kroD100);
            solver.SimulatedAnnealing(kroD100);
            solver.SimulatedAnnealing(kroD100);
            solver.SimulatedAnnealing(kroD100);
            solver.SimulatedAnnealing(kroD100);
            Console.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CreateGraphics().Clear(Color.Gray);
            string kroC100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroC100.tsp";
            string kroD100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroD100.tsp";
            List<City> cities = Solver.TwoOptMethod(kroC100);
            Points = new Point[100];
            for (int i = 0; i < cities.Count; i++)
            {
                Points[i].X = cities[i].XCoordinate/3;
                Points[i].Y = cities[i].YCoordinate/3;
            }

            for (int i = 0; i < 99; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Red, 4), new Rectangle(Points[i], new Size(4, 4)));
                
                this.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2), Points[i], Points[i + 1]);
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.CreateGraphics().Clear(Color.Gray);
            string kroC100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroC100.tsp";
            string kroD100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroD100.tsp";
            List<City> cities = Solver.GreedyMethod(kroC100);
            Points = new Point[100];
            for (int i = 0; i < cities.Count; i++)
            {
                Points[i].X = cities[i].XCoordinate / 3;
                Points[i].Y = cities[i].YCoordinate / 3;
            }

            for (int i = 0; i < 99; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Red, 4), new Rectangle(Points[i], new Size(4,4)));

                this.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2), Points[i], Points[i + 1]);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.CreateGraphics().Clear(Color.Gray);
            string kroC100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroC100.tsp";
            string kroD100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroD100.tsp";
            List<City> cities = Solver.SimulatedAnnealing(kroC100);
            Points = new Point[100];
            for (int i = 0; i < cities.Count; i++)
            {
                Points[i].X = cities[i].XCoordinate / 3;
                Points[i].Y = cities[i].YCoordinate / 3;
            }

            for (int i = 0; i < 99; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Red, 4), new Rectangle(Points[i], new Size(4, 4)));
               
                this.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2), Points[i], Points[i + 1]);
                

            }
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button4_Click(object sender, EventArgs e)
        {
            this.CreateGraphics().Clear(Color.Gray);
            string kroC100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroC100.tsp";
            string kroD100 = "C:\\Users\\darkm\\Documents\\Visual Studio 2017\\Projects\\TravelingSalesmanProblem\\TravelingSalesmanProblem\\kroD100.tsp";
            List<City> cities = Solver.GenerateRandomSolution();
            Points = new Point[100];
            for (int i = 0; i < cities.Count; i++)
            {
                Points[i].X = cities[i].XCoordinate / 3;
                Points[i].Y = cities[i].YCoordinate / 3;
            }

            for (int i = 0; i < 99; i++)
            {
                this.CreateGraphics().DrawRectangle(new Pen(Brushes.Red, 4), new Rectangle(Points[i], new Size(4, 4)));

                this.CreateGraphics().DrawLine(new Pen(Brushes.Black, 2), Points[i], Points[i + 1]);


            }
        }
    }
}
