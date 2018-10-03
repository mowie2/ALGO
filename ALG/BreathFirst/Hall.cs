using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg
{
    class Hall:Node
    {

        private Enemy enemy;
        public Hall(int level)
        {
            this.enemy = new Enemy(level);
        }
        public void Visit()
        {
            enemy.Kill();
        }
        public override string ToString()
        {
            return enemy.GetLevel().ToString();
        }
    }
}
