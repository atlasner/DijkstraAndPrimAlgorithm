using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDE_project1
{
    
    class Node
    {
        public int x, y;
        public int id;
        
        public Node(int id,int x, int y )
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }
    }
}
