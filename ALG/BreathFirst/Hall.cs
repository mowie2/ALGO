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

        //public Dictionary<Room, Room> rooms;
        public Enemy enemy;
        public Hall(int level/*, Room room1, Room room2*/)
        {
            //this.rooms = new Dictionary<Room, Room>
            //{
            //    [room1] = room2,
            //    [room2] = room1,
            //};
            this.enemy = new Enemy(level);
        }

        public string Draw()
        {
            return enemy.Draw();
        }
    }
}
