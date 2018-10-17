using Alg;
using System.Collections.Generic;
using System.Linq;

namespace BreathFirst
{
    public class Compas
    {
        public Room[,] rooms;
        //private readonly Hero hero;
        public Compas(Room[,] rooms/*, Hero hero*/)
        {
            //this.hero = hero;
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
                //queRooms.Add(room);
            }

            List<Room> visited = new List<Room>();

            Room currentRoom = start;
            while (queRooms.Count>0)
            {
                List<Hall> queHalls = new List<Hall>();
                foreach (Room.Direction dir in currentRoom.Connections.Keys)
                {
                    Hall lookHall = currentRoom.Connections[dir];
                    Room lookRoom = lookHall.rooms[currentRoom];
                    if (!lookHall.collapsed)
                    {
                        if (!visited.Contains(lookRoom) && !queRooms.Contains(lookRoom))
                        {
                            queRooms.Add(lookRoom);
                            queHalls.Add(lookHall);
                        }
                        int lookcost = (distances[currentRoom] + lookHall.enemy.level);
                        if (distances[lookRoom] > lookcost)
                        {
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
                } else if (queRooms.Count > 0)
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


            




            /*
            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] = distances[y]);
                Room smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == end)
                {
                    pathInDirections = new List<Room.Direction>();
                    List<Room> pathInRooms = new List<Room>();
                    while (previous.ContainsKey(smallest))
                    {
                        pathInRooms.Add(smallest);
                        smallest = previous[smallest];
                    }

                    while (pathInRooms.Count != 0)
                    {

                        foreach (Room.Direction direction in pathInRooms[0].Connections.Keys)
                        {
                            if (direction == Room.Direction.EAST)
                            {
                                if (pathInRooms[1] != null)
                                {
                                    if (pathInRooms[0].x == pathInRooms[1].x + 1 && pathInRooms[0].y == pathInRooms[1].y)
                                    {
                                        pathInDirections.Add(Room.Direction.EAST);
                                    }
                                }
                            }
                        }

                        for (int positionInList = 0; positionInList < pathInRooms.Count; positionInList++)
                        {
                            foreach (Room.Direction direction in pathInRooms[positionInList].Connections.Keys)
                            {
                                if (direction == Room.Direction.EAST)
                                {
                                    if (pathInRooms[positionInList + 1] != null)
                                    {
                                        if (pathInRooms[positionInList].x == pathInRooms[positionInList + 1].x + 1 && pathInRooms[positionInList].y == pathInRooms[positionInList + 1].y)
                                        {
                                            pathInDirections.Add(Room.Direction.EAST);
                                        }
                                    }
                                }
                                if (direction == Room.Direction.WEST)
                                {
                                    if (pathInRooms[positionInList + 1] != null)
                                    {
                                        if (pathInRooms[positionInList].x == pathInRooms[positionInList + 1].x - 1 && pathInRooms[positionInList].y == pathInRooms[positionInList + 1].y)
                                        {
                                            pathInDirections.Add(Room.Direction.WEST);
                                        }
                                    }
                                }

                                if (direction == Room.Direction.NORTH)
                                {
                                    if (pathInRooms[positionInList + 1] != null)
                                    {
                                        if (pathInRooms[positionInList].x == pathInRooms[positionInList + 1].x && pathInRooms[positionInList].y == pathInRooms[positionInList + 1].y + 1)
                                        {
                                            pathInDirections.Add(Room.Direction.NORTH);
                                        }
                                    }
                                }
                                if (direction == Room.Direction.SOUTH)
                                {
                                    if (pathInRooms[positionInList + 1] != null)
                                    {
                                        if (pathInRooms[positionInList].x == pathInRooms[positionInList + 1].x && pathInRooms[positionInList].y == pathInRooms[positionInList + 1].y - 1)
                                        {
                                            pathInDirections.Add(Room.Direction.SOUTH);
                                        }
                                    }
                                }
                            }
                        }


                    }
                    break;
                }
                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach(var neigbour in smallest.Connections)
                {
                    var alt = distances[smallest] + neigbour.Value.enemy.level;

                    if(alt < distances[neigbour])
                    {

                    }
                }
            }
            */
            return pathInDirections;

        }
    }
}
