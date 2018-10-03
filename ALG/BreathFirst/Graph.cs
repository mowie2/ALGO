using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg
{
    class Graph
    {
        public Node root { get; set; }
        private readonly int x;
        private readonly int y;
        public Graph(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void SetUP()
        {
            SetUP(0, 0);
        }

        public void SetUP(int xStart,int yStart)
        {
        }
    }
}
