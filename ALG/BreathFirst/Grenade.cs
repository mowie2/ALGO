using Alg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreathFirst
{
    class Grenade
    {
        public void Use(Room startRoom)
        {
            List<Hall> smallestSpanningTree = new List<Hall>();
            List<Room> que = new List<Room>();
            List<Room> visited = new List<Room>();

            int lowestLevel = 10;
            //Hall lowestHall = new Hall(1,new Room(),new Room());
            Room lowestRoom = startRoom;

            Room currentRoom = startRoom;
            Hall lookHall;
            Room lookRoom;

            foreach (Room.Direction dir in currentRoom.Connections.Keys)
            {
                lookHall = currentRoom.Connections[dir];
               // lookRoom = currentRoom.Connections[dir].rooms[currentRoom];
                
                //if(!que.Contains(lookRoom) && !visited.Contains(lookRoom) && !smallestSpanningTree.Contains(lookHall) 
                //    && lowestLevel>lookHall.enemy.level)
                //{
                //    lowestLevel = lookHall.enemy.level;
                //    //lowestHall = lookHall;
                //    lowestRoom = lookRoom;
                //}
                que.Add(lowestRoom);
                //smallestSpanningTree.Add(lowestHall);
                visited.Add(currentRoom);
                currentRoom = lowestRoom;
            }
        }
    }
}
