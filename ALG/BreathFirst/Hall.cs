using BreathFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg
{
    public class Hall : IDrawable
    {

        private Enemy enemy;
        public Hall(int level)
        {
            this.enemy = new Enemy(level);
        }
        public string Draw()
        {
            return enemy.Draw();
        }
    }
}
