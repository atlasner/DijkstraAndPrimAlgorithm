using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE_project1
{
    class Program
    {
        public static string path = @"network.txt";
        public static int nodes = 0;
        public static int edges = 0;
       

        static void Main(string[] args)
        {


             
            Network network2 = new Network();
            network2.Graph(path);
            int[,] graph1 = new int[Program.nodes, Program.nodes];                  
            int startNode = 1;
            int endNode = 3;
            Network network = new Network(graph1);
            network.Graph(path);
            network.returnGraph(network);
            network.minimumSpanningTree();
            network.drawEnd(network);
            var arrayEdges = network.shortestPath(startNode - 1, endNode - 1);




            int[,] graphOfShortestPaths = new int[Program.nodes, Program.nodes];   // tablica wszystkich najkrotszych odleglosci od wierzcholka do wierzcholka

            Console.ReadKey();

          


        }

    }
}
