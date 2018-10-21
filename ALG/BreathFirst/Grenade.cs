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
        public List<Hall> minimumSpanningTree;
        public Room[,] rooms;
        public List<Hall> halls;

        public Grenade(Room[,] rooms,List<Hall> halls)
        {
            this.rooms = rooms;
            this.halls = halls;
            minimumSpanningTree = new List<Hall>();
            //FindMST(halls);
        }

        private void FindMST(List<Hall> halls)
        {
            List<Hall> que = halls.ToList();
            List<Hall> oldQue;

            List<Room> visited = new List<Room>();

            while (que.Count>0)
            {
                oldQue = que.ToList();
                Hall lowestHall = null;
                Room lowestRoom1 = null;
                Room lowestRoom2 = null;
                foreach (Hall currentHall in oldQue)
                {
                    Room lookRoom1 = currentHall.rooms.First().Value;
                    Room lookRoom2 = currentHall.rooms.Last().Value;
                    bool criterea1 = (visited.Contains(lookRoom1) && visited.Contains(lookRoom2));
                    bool criterea2 = (!visited.Contains(lookRoom1) && !visited.Contains(lookRoom2));
                    if ((criterea1 || criterea2) && visited.Count>0)
                    {
                        if (criterea1)
                        {
                            que.Remove(currentHall);
                        }
                        continue;
                    }
                    if (lowestHall == null)
                    {
                        lowestHall = currentHall;
                        lowestRoom1 = lookRoom1;
                        lowestRoom2 = lookRoom2;
                    }
                    else
                    {
                        if (lowestHall.enemy.level >= currentHall.enemy.level)
                        {
                            lowestHall = currentHall;
                            lowestRoom1 = lookRoom1;
                            lowestRoom2 = lookRoom2;
                        }
                    }
                }
                if (lowestHall!=null)
                {
                    if(lowestRoom1 == null)
                    {
                        break;
                    }
                    minimumSpanningTree.Add(lowestHall);
                    visited.Add(lowestRoom1);
                    visited.Add(lowestRoom2);
                    que.Remove(lowestHall);
                }
            }
        }


        public void FindMSTPrim(Room startRoom)
        {
            Room currentRoom = startRoom;
            List<Hall> que = new List<Hall>();
            List<Room> visited = new List<Room>();

            while (currentRoom != null)
            {
                foreach (Room.Direction dir in currentRoom.Connections.Keys)
                {
                    Hall currentHall = currentRoom.Connections[dir];
                    Room lookRoom = currentHall.rooms[currentRoom];
                    if (!que.Contains(currentHall) && !minimumSpanningTree.Contains(currentHall) && !visited.Contains(lookRoom))
                    {
                        que.Add(currentHall);
                    }
                }
                visited.Add(currentRoom);


                Room lowestRoom = null;
                Hall lowestHall = null;
                que = que.OrderBy(r => r.enemy.level).ToList();
                while (lowestRoom == null && que.Count > 0)
                {
                    lowestHall = que[0];
                    Room lookRoom1 = lowestHall.rooms.First().Value;
                    Room lookRoom2 = lowestHall.rooms.Last().Value;
                    if (!visited.Contains(lookRoom1) || !visited.Contains(lookRoom2))
                    {
                        lowestRoom = lookRoom1;
                        if (!visited.Contains(lookRoom2))
                        {
                            lowestRoom = lookRoom2;
                        }
                    }
                    else { que.Remove(lowestHall); }
                }

                if (lowestRoom != null)
                {
                    minimumSpanningTree.Add(lowestHall);
                }
                que.Remove(lowestHall);
                currentRoom = lowestRoom;
            }
        }


        public void Use(Room startRoom)
        {
            FindMSTPrim(startRoom);
            foreach(Hall currentHall in halls)
            {
                if (!minimumSpanningTree.Contains(currentHall))
                {
                    currentHall.Collapse();
                }
            }

            Random rand = new Random();
            List<Room.Direction> startRoomHalls = new List<Room.Direction>();
            foreach(Room.Direction dir in startRoom.Connections.Keys)
            {
                Hall currentHall = startRoom.Connections[dir];
                if (currentHall.value != "~")
                {
                    startRoomHalls.Add(dir);
                }
            }
            int enemy2Die = rand.Next(0, startRoomHalls.Count);
            startRoom.Connections[startRoomHalls[enemy2Die]].KillEnemy();
        }
    }
}
