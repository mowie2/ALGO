using Alg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreathFirst
{
    class TalisMan
    {
        public int Use(Room startRoom)
        {
            Room currentRoom;
            List<Room> que = new List<Room> { startRoom };
            List<Room> visited = new List<Room> { startRoom };
            int count = 0;
            bool found = false;

            while (true)
            {
                List<Room> newQue = new List<Room>();
                foreach (Room r in que)
                {
                    currentRoom = r;
                    if(currentRoom.value.Equals("e"))
                    {
                        found = true;
                        break;
                    }
                    foreach (Room.Direction dir in currentRoom.Connections.Keys)
                    {
                        Room lookRoom = currentRoom.Connections[dir].rooms[currentRoom];

                        if (!que.Contains(lookRoom) && !visited.Contains(lookRoom))
                        {
                            newQue.Add(lookRoom);
                        }
                    }
                    visited.Add(currentRoom);
                }
                que = newQue;
                if (que.Count() == 0)
                {
                    break;
                }
                count++;
            }
            if (found)
            {
                return count;
            }
            Console.WriteLine("end not found");
            return -1;
        }

    }
}
