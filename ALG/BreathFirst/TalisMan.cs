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
            Room currentRoom = startRoom;
            List<Room> que = new List<Room> { currentRoom };
            List<Room> visited = new List<Room>();
            int count = 0;

            while (true)
            {
                if (que.Count() == 0 || currentRoom.value.Equals("e"))
                {
                    break;
                }

                que.Remove(currentRoom);
                count++;

                foreach (Room.Direction dir in currentRoom.Connections.Keys)
                {
                    Room lookRoom = currentRoom.Connections[dir].rooms[0];
                    if (currentRoom.id == lookRoom.id)
                    {
                        lookRoom = currentRoom.Connections[dir].rooms[1];
                    }

                    if (!que.Contains(lookRoom) && !visited.Contains(lookRoom))
                    {
                        que.Add(lookRoom);
                    }
                }

                visited.Add(currentRoom);
                currentRoom = que[0];
            }
            return count;
        }

    }
}
