using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg
{
    class Room:Node
    {
        private bool visited = false;
        private char print = 'X';

        public void Visit()
        {
            visited = true;
            print = '*';
        }
        public bool GetVisited()
        {
            return visited;
        }
        public override string ToString()
        {
            return print.ToString();
        }
    }
}
