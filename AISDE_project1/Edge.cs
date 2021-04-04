using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE_project1
{
    class Edge
    {
        public int startNode, endNode;
        public int id;
        public double weight=100;

        public Edge(int id, int startNode, int endNode)
        {
            this.id = id;
            this.startNode = startNode;
            this.endNode = endNode;
            
        }
    }
}
