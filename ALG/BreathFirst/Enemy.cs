using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg
{
    class Enemy
    {
        int level;
        public Enemy(int level)
        {
            this.level = level;
        }
        public void Kill()
        {
            level = 0;
        }
        public int GetLevel()
        {
            return level;
        }
    }
}
