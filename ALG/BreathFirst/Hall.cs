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

        public Room[] rooms;
        private Enemy enemy;
        public Hall(int level, Room room1, Room room2)
        {
            this.rooms = new Room[2];
            this.rooms[0] = room1;
            this.rooms[1] = room2;
            this.enemy = new Enemy(level);
        }

        public string Draw()
        {
            return enemy.Draw();
        }
    }
}
