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
        public int Use(Room startRoom,Room endRoom)
        {
            Room currentRoom;
            List<Room> que = new List<Room> { startRoom };
            List<Room> visited = new List<Room>();
            int count = 0;
            bool found = false;

            while (que.Count() > 0)
            {
                List<Room> oldQue = que.ToList();
                foreach (Room r in oldQue)
                {
                    currentRoom = r;
                    if (currentRoom == endRoom)
                    {
                        que = new List<Room>();
                        found = true;
                        break;
                    }
                    foreach (Room.Direction dir in currentRoom.Connections.Keys)
                    {
                        Room lookRoom = currentRoom.Connections[dir].rooms[currentRoom];

                        if (!que.Contains(lookRoom) && !visited.Contains(lookRoom))
                        {
                            que.Add(lookRoom);
                        }
                    }
                    visited.Add(currentRoom);
                    que.Remove(currentRoom);
                }
                if (!found) { count++; }
            }
            if (found) { return count; }
            Console.WriteLine("end not found");
            return -1;
        }

    }
}
