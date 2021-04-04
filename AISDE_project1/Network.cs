using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AISDE_project1
{


    class Network
    {

        List<Node> listNodes = new List<Node>();
        List<Edge> listEdges = new List<Edge>();
        List<int> countLast = new List<int>();
        List<int> countLast2 = new List<int>();


        public const int INF = 1000000;
        public int[,] Graph5;


        public Network(int[,] graph)
        {
            Graph5 = graph;
        }
        public Network()
        {

        }


        public void Graph(string path)
        {

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while (((line = sr.ReadLine()) != null))
                {

                    if (Regex.IsMatch(line, "\\bWEZLY = \\b"))
                    {
                        Program.nodes = Convert.ToInt32(Regex.Replace(line, @"[^\d]+", ""));
                    }

                    if (Regex.IsMatch(line, "\\bLACZA = \\b"))
                    {
                        Program.edges = Convert.ToInt32(Regex.Replace(line, @"[^\d]+", ""));
                    }

                    if ((Regex.IsMatch(line[0].ToString(), @"[0-9]")) && (listNodes.Count < Program.nodes))
                    {
                        String[] dates = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        listNodes.Add(new Node(Int32.Parse(dates[0]), Int32.Parse(dates[1]), Int32.Parse(dates[2])));
                    }

                    else if ((Regex.IsMatch(line[0].ToString(), @"[0-9]")) && (listNodes.Count >= Program.nodes))
                    {
                        String[] dates = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        listEdges.Add(new Edge(Int32.Parse(dates[0]), Int32.Parse(dates[1]), Int32.Parse(dates[2])));
                    }
                }
                sr.Close();
            }

        }


        public List<Edge> minimumSpanningTree()
        {
            List<Edge> Edges = new List<Edge>();//lista koncowych krawedzi
            List<int> usedNodes = new List<int>();//lista wykorzystanych wiershhokow


            Random rnd = new Random();
            int NUMBER = rnd.Next(1, Program.nodes);

            int index = 0;
            int numberOfEdge = 0;
            double minLenght = 0;
            double minLenght1 = 0;
            bool b = true;
            usedNodes.Add(NUMBER);



            for (int e = 0; e < Program.nodes - 1; e++)//5
            {
                numberOfEdge = 0;
                b = true;
                for (int i = 0; i < Program.edges; i++)//10
                {

                    for (int k = 0; k < usedNodes.Count; k++)//sprawdzamy dla wierszholkow w listUsed
                    {
                        if (usedNodes[k] == listEdges[i].startNode || usedNodes[k] == listEdges[i].endNode)//szukamy z jakimi wierszhokami jest polaczony
                        {

                            if (usedNodes[k] == listEdges[i].startNode && !usedNodes.Contains(listEdges[i].endNode))//sprawdzamy czy nie ma juz tego wierszholka w wykorzystanych
                            {
                                if (b == true)
                                {
                                    minLenght = length(listEdges[i].startNode, listEdges[i].endNode);
                                    if (usedNodes[k] == listEdges[i].startNode)
                                    {
                                        index = listEdges[i].endNode;
                                        numberOfEdge = i;
                                    }
                                    if (usedNodes[k] == listEdges[i].endNode)
                                    {
                                        index = listEdges[i].startNode;
                                        numberOfEdge = i;
                                    }
                                    b = false;
                                }


                                minLenght1 = length(listEdges[i].startNode, listEdges[i].endNode);

                                if (minLenght < minLenght1)
                                {

                                }

                                if (minLenght > minLenght1)
                                {
                                    minLenght = minLenght1;
                                    if (usedNodes[k] == listEdges[i].startNode)
                                    {
                                        index = listEdges[i].endNode;
                                        numberOfEdge = i;
                                    }
                                    if (usedNodes[k] == listEdges[i].endNode)
                                    {
                                        index = listEdges[i].startNode;
                                        numberOfEdge = i;
                                    }
                                }

                            }

                            if (usedNodes[k] == listEdges[i].endNode && !usedNodes.Contains(listEdges[i].startNode))
                            {

                                if (b == true)
                                {
                                    minLenght = length(listEdges[i].startNode, listEdges[i].endNode);
                                    if (usedNodes[k] == listEdges[i].startNode)
                                    {
                                        index = listEdges[i].endNode;
                                        numberOfEdge = i;
                                    }
                                    if (usedNodes[k] == listEdges[i].endNode)
                                    {
                                        index = listEdges[i].startNode;
                                        numberOfEdge = i;
                                    }
                                    b = false;
                                }


                                minLenght1 = length(listEdges[i].startNode, listEdges[i].endNode);

                                if (minLenght < minLenght1)
                                {

                                }

                                if (minLenght > minLenght1)
                                {
                                    minLenght = minLenght1;
                                    if (usedNodes[k] == listEdges[i].startNode)
                                    {
                                        index = listEdges[i].endNode;
                                        numberOfEdge = i;
                                    }
                                    if (usedNodes[k] == listEdges[i].endNode)
                                    {
                                        index = listEdges[i].startNode;
                                        numberOfEdge = i;
                                    }
                                }
                            }



                        }


                    }
                }
                usedNodes.Add(index);//dodajemy wiercholek do listUsed
                Edges.Add(listEdges[numberOfEdge]); //dodajemy krawedz do koncowej listy krawedzi(wynikow)

            }



            drawEdges(listEdges, listNodes, Edges, NUMBER);

            return Edges;

        }


        int[,] graph = new int[Program.nodes, Program.nodes];

        public int[,] returnGraph(Network network5)
        {

            for (int i = 1; i <= Program.nodes; i++)
            {
                for (int j = 1; j <= Program.nodes; j++)
                {
                    for (int u = 0; u < Program.edges; u++)
                    {
                        if ((i == network5.listEdges[u].startNode && j == network5.listEdges[u].endNode) || (j == network5.listEdges[u].startNode && i == network5.listEdges[u].endNode))
                        {

                            Graph5[i - 1, j - 1] = length(i, j);
                            break;
                        }
                        else if (i == j)
                        {
                            Graph5[i - 1, j - 1] = 0;
                        }
                        else
                        {
                            Graph5[i - 1, j - 1] = INF;
                        }
                    }
                }
            }

            return Graph5;
        }


        public List<Edge> shortestPath(int startNode, int endNode)
        {



            int graphSize = Graph5.GetLength(0);   //5   
            int[] dist = new int[graphSize];//5
            int[] prev = new int[graphSize];
            int[] nodes = new int[graphSize];

            for (int i = 0; i < dist.Length; i++)
            {
                dist[i] = prev[i] = INF;
                nodes[i] = i;
            }

            dist[startNode] = 0;
            do
            {
                int smallest = nodes[0];
                int smallestIndex = 0;
                for (int i = 1; i < graphSize; i++)//5
                {
                    if (dist[nodes[i]] < dist[smallest])
                    {
                        smallest = nodes[i];
                        smallestIndex = i;
                    }
                }
                graphSize--;
                nodes[smallestIndex] = nodes[graphSize];

                if (dist[smallest] == INF || smallest == endNode)
                    break;

                for (int i = 0; i < graphSize; i++)
                {
                    int v = nodes[i];
                    int newDist = dist[smallest] + Graph5[smallest, v];
                    if (newDist < dist[v])
                    {
                        dist[v] = newDist;
                        prev[v] = smallest;
                    }
                }
            }
            while (graphSize > 0);
            return ReconstructPath(prev, startNode, endNode);


        }



        public List<Edge> ReconstructPath(int[] prev, int SRC, int DEST)
        {
            int[] ret = new int[prev.Length];
            int currentNode = 0;
            ret[currentNode] = DEST;
            while (ret[currentNode] != INF && ret[currentNode] != SRC)
            {
                ret[currentNode + 1] = prev[ret[currentNode]];
                currentNode++;
            }
            if (ret[currentNode] != SRC)
                return null;
            int[] reversed = new int[currentNode + 1];
            for (int i = currentNode; i >= 0; i--)
                reversed[currentNode - i] = ret[i];


            List<Edge> edgesResult = new List<Edge>();


            for (int i = 0; i < reversed.Length - 1; i++)
            {
                int number = 0;
                for (int j = 0; i < Program.edges; j++)
                {
                    if ((reversed[i] == listEdges[j].startNode - 1 && reversed[i + 1] == listEdges[j].endNode - 1) || (reversed[i] == listEdges[j].endNode - 1 && reversed[i + 1] == listEdges[j].startNode - 1))
                    {
                        number = j;
                        break;

                    }
                }
                edgesResult.Add(listEdges[number]);
            }


            drawEdges2(listEdges, listNodes, edgesResult, reversed);

            return edgesResult;


        }


        public int length(int id1, int id2)
        {
            int p = (int)Math.Sqrt(Math.Pow((listNodes[id1 - 1].x - listNodes[id2 - 1].x), 2) + Math.Pow((listNodes[id1 - 1].y - listNodes[id2 - 1].y), 2));
            return p;
        }

        public int minLenght(List<Edge> p)
        {
            int minLenght1 = 0;
            for (int i = 0; i < p.Count; i++)
            {
                minLenght1 += length(p[i].startNode, p[i].endNode);
            }
            return minLenght1;
        }

        public void drawEnd(Network network)//robimy Dijkstre kilka razy i zapisujemy do listy koncowej
        {
            int t = 0;
            List<Edge> listEdgesSUM = new List<Edge>();
            List<Edge> listEdgesSUM2 = new List<Edge>();
            for (int i = 0; i < listNodes.Count; i++)
            {
                t = 0;
                for (int j = 0; j < listNodes.Count; j++)//ile krawedzi musimy dodac do listy (.Count)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    for (int k = 0; k < network.shortestPath(i, j).Count; k++)
                    {
                        listEdgesSUM.Add(network.shortestPath(i, j)[k]);//dodawanie do listy
                                                                        // Console.WriteLine("     "+(i+1) + " " + (j+1));
                        ++t;
                    }

                }
                countLast.Add(t);

            }

            int max = countLast[0];
            List<int> id = new List<int>();
            List<int> id2 = new List<int>();
            for (int y = 0; y < countLast.Count ; y++) //countLast.Count=5
            {
                if (max < countLast[y])
                {
                    max = countLast[y];
                    id.Clear();

                }
                if (max == countLast[y])
                    id.Add(y + 1);
               
            }

            for (int y = 0; y < id.Count; y++) //
            {               
                Console.WriteLine(id[y]);
            }


            Console.WriteLine();

            for (int i = 0; i < countLast.Count; i++)
            {
                Console.Write(countLast[i]);
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < listNodes.Count; i++)
            {
                t = 0;
                for (int j = 0; j < listNodes.Count; j++)//ile krawedzi musimy dodac do listy (.Count)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (i == (id[0]-1) || j == (id[0]-1))
                    {
                        continue;
                    }
                    for (int k = 0; k < network.shortestPath(i, j).Count; k++)
                    {
                      
                        listEdgesSUM2.Add(network.shortestPath(i, j)[k]);//dodawanie do listy                                                                  
                        ++t;
                    }

                }
                countLast2.Add(t);

            }

            int max2 = countLast2[0];

            for (int y = 0; y < countLast2.Count; y++) //countLast.Count=5
            {
                if (max2 < countLast2[y])
                {
                    max2 = countLast2[y];
                    id2.Clear();

                }
                if (max2 == countLast2[y])
                    id2.Add(y + 1);

            }

            for (int y = 0; y < id2.Count; y++) 
            {
                Console.WriteLine(id2[y]);
            }


            Console.WriteLine();

            for (int i = 0; i < countLast2.Count; i++)
            {
                Console.Write(countLast2[i]);
                Console.WriteLine();
            }
        }



        public void drawEdges(List<Edge> EdgesDraw, List<Node> listNodesDraw, List<Edge> listEdgesDraw,int t)
        {

            StreamWriter file = new StreamWriter("result.dot");
            file.WriteLine("Graph{");
            file.WriteLine("node [shape=circle];");
            for (int i = 0; i < EdgesDraw.Count; i++)
            {
                file.Write(EdgesDraw[i].startNode + "--" + EdgesDraw[i].endNode + "[label=" + length(EdgesDraw[i].startNode, EdgesDraw[i].endNode)  + "]");
                for (int j = 0; j < Program.nodes - 1; j++)
                {                 
                    if (EdgesDraw[i].id == listEdgesDraw[j].id)
                    {
                        file.WriteLine("[color = red];");
                        break;
                    }
                    else if (j == Program.nodes - 2 )
                    {
                        file.WriteLine("[color = black];");
                        break;
                    }
                }

            }

            file.WriteLine(listNodesDraw[t-1].id + "[fillcolor = blue, style = filled]; }");
            file.Close();


        }

        public void drawEdges2(List<Edge> EdgesDraw, List<Node> listNodesDraw, List<Edge> listEdgesDraw, int[] t)
        {

            StreamWriter file = new StreamWriter("result2.dot");
            file.WriteLine("Graph{");
            file.WriteLine("node [shape=circle];");
            for (int i = 0; i < EdgesDraw.Count; i++)
            {
                file.Write(EdgesDraw[i].startNode + "--" + EdgesDraw[i].endNode + "[label=" + length(EdgesDraw[i].startNode, EdgesDraw[i].endNode) + "]");
                for (int j = 0; j < listEdgesDraw.Count; j++)
                {
                    if (EdgesDraw[i].id == listEdgesDraw[j].id)
                    {
                        file.WriteLine("[color = red];");
                        break;
                    }
                    else if (j == Program.nodes - 2)
                    {
                        file.WriteLine("[color = black];");
                        break;
                    }
                }

            }

            file.WriteLine(listNodesDraw[t[0]].id + "[fillcolor = green, style = filled]; ");
            file.WriteLine(listNodesDraw[t[t.Length-1]].id + "[fillcolor = orange, style = filled]; }");
            file.Close();

        }



    }




    }



