using Alg;
using System.Collections.Generic;

namespace BreathFirst
{
    public class Compas
    {
        public Room[,] rooms;
        private readonly Hero hero;
        public Compas(Room[,] rooms, Hero hero)
        {
            this.hero = hero;
            this.rooms = rooms;
        }

        public List<Room.Direction> Use(Room start, Room end)
        {

            Dictionary<Room, Room> previous = new Dictionary<Room, Room>();
            Dictionary<Room, int> distances = new Dictionary<Room, int>();
            List<Room> nodes = new List<Room>();

            List<Room.Direction> pathInDirections = null;

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

                nodes.Add(room);
            }


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

            return pathInDirections;

        }


    }
}
