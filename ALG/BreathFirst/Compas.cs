using Alg;
using System.Collections.Generic;
using System.Linq;

namespace BreathFirst
{
    public class Compas
    {
        public Room[,] rooms;
        public Compas(Room[,] rooms)
        {
            this.rooms = rooms;
        }


        public List<Room.Direction> Use(Room start, Room end)
        {

            Dictionary<Room, Room> previous = new Dictionary<Room, Room>();
            Dictionary<Room, int> distances = new Dictionary<Room, int>();
            List<Room> queRooms = new List<Room> { start };



            foreach (Room room in rooms)
            {
                if (room == start)
                {
                    distances[room] = 0;
                }
                else
                {
                    distances[room] = int.MaxValue;
                }
            }

            List<Room> visited = new List<Room>();

            Room currentRoom = start;
            while (queRooms.Count > 0)
            {
                List<Hall> queHalls = new List<Hall>();
                foreach (Room.Direction dir in currentRoom.Connections.Keys)
                {
                    Hall lookHall = currentRoom.Connections[dir];
                    Room lookRoom = lookHall.rooms[currentRoom];
                    if (!lookHall.collapsed)
                    {
                        int lookcost = (distances[currentRoom] + lookHall.enemy.level);
                        if (distances[lookRoom] > lookcost)
                        {
                            queRooms.Add(lookRoom);
                            queHalls.Add(lookHall);
                            previous[lookRoom] = currentRoom;
                            distances[lookRoom] = lookcost;
                        }
                    }
                }
                queRooms.Remove(currentRoom);
                visited.Add(currentRoom);
                if (queHalls.Count > 0)
                {
                    currentRoom = queHalls.OrderBy(pv => pv.enemy.level).ToList()[0].rooms[currentRoom];
                }
                else if (queRooms.Count > 0)
                {
                    currentRoom = queRooms[0];
                }
            }

            List<Room.Direction> pathInDirections = new List<Room.Direction>();
            Room searchRoom = end;

            while (searchRoom != start)
            {
                Room newRoom = previous[searchRoom];
                Room.Direction dir = newRoom.Connections.Where(pv => pv.Value.rooms[newRoom] == searchRoom).Select(pv => pv.Key).ToList()[0];
                pathInDirections.Insert(0, dir);
                searchRoom = newRoom;
            }
            return pathInDirections;

        }


        public List<Hall> GetHalls(List<Room.Direction> directions, Room startRoom)
        {
            List<Hall> enemies = new List<Hall>();
            //directions.Reverse();

            //enemies.Add(currentRoom.Connections[directions[0]]);
            //directions.RemoveAt(0);
            Room currentRoom = startRoom;

            while (directions.Count() >= 0)
            {
                if(directions.Count == 0)
                {
                    break;
                }
                if (directions.Count != 0 && directions[0] == Room.Direction.EAST)
                {
                    if (directions.Count != 0)
                    {
                        enemies.Add(currentRoom.Connections[directions[0]]);

                        currentRoom.Visit();
                    }
                    currentRoom = rooms[currentRoom.x + 1, currentRoom.y];
                }
                if (directions.Count != 0 && directions[0] == Room.Direction.WEST)
                {
                    if (directions.Count != 0)
                    {
                        enemies.Add(currentRoom.Connections[directions[0]]);

                        currentRoom.Visit();
                    }
                    currentRoom = rooms[currentRoom.x - 1, currentRoom.y];
                }
                if (directions.Count != 0 && directions[0] == Room.Direction.NORTH)
                {
                    if (directions.Count != 0)
                    {
                        enemies.Add(currentRoom.Connections[directions[0]]);

                        currentRoom.Visit();
                    }
                    currentRoom = rooms[currentRoom.x, currentRoom.y + 1];
                }
                if (directions.Count != 0 && directions[0] == Room.Direction.SOUTH)
                {
                    if (directions.Count != 0)
                    {
                        enemies.Add(currentRoom.Connections[directions[0]]);

                        currentRoom.Visit();
                    }
                    currentRoom = rooms[currentRoom.x, currentRoom.y - 1];
                }
                directions.RemoveAt(0);
            }

            startRoom.value = "S";
            return enemies;
        }
    }
}
