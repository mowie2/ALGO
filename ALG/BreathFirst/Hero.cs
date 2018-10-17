using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg
{
    public class Hero
    {
        public Room currentRoom;
        public Hero(Room visitRoom)
        {
            visitRoom.Visit();
            currentRoom = visitRoom;
        }

        public void Visit(Room visitRoom)
        {
            if((currentRoom.x != visitRoom.x) && (currentRoom.y != visitRoom.y))
            {
                visitRoom.Visit();
                currentRoom.Leave();
                currentRoom = visitRoom;
            }
        }
    }
}
