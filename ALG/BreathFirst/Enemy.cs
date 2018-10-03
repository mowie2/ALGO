using BreathFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg
{
    public class Enemy : IDrawable
    {
        int level;
        public Enemy(int level)
        {
            this.level = level;
        }

        public string Draw()
        {
            return level.ToString();
        }
    }
}
