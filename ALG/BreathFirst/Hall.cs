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

        public Dictionary<Room, Room> rooms;
        public Enemy enemy;
        public string value;
        public Hall(int level)
        {
            this.rooms = new Dictionary<Room, Room>();
            this.enemy = new Enemy(level);
            this.value = this.enemy.level.ToString();
        }

        public void AddConnections(Room room1, Room room2)
        {
            rooms[room1] = room2;
            rooms[room2] = room1;
        }

        public void KillEnemy()
        {
            enemy.level = 0;
            value = enemy.level.ToString();
        }

        public void Collapse()
        {
            value = "~";
        }

        public string Draw()
        {
            return value;
        }
    }
}
