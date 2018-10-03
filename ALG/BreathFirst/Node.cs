using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg
{
    abstract class Node
    {
        public Node north { get; set; }
        public Node south { get; set; }
        public Node east { get; set; }
        public Node west { get; set; }
    }
}
