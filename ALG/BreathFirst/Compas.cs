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

            List<Room.Direction> path = null;

            foreach (Room room in rooms)
            {
                if(room == start)
                {
                    distances[room] = 0;
                }
                else
                {
                    distances[room] = int.MaxValue;
                }

                nodes.Add(room);
            }


            while(nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] = distances[y]);
                Room smallest = nodes[0];
                nodes.Remove(smallest);

                if(smallest == end)
                {
                    path = new List<Room.Direction>();
                    List<Room> temp = new List<Room>();
                    while (previous.ContainsKey(smallest))
                    {
                        temp.Add(smallest);
                        smallest = previous[smallest];
                    }

                    while(temp.Count != 0)
                    {
                        Room.Direction dir;

                        //foreach (Room.Direction direction in temp[0].Connections.Keys)
                        //{
                        //    if(direction == Room.Direction.EAST)
                        //    {
                        //        if(temp[0].x == temp[1].x+1 && )
                        //    }
                        //}

                        // path.Add(dir);
                    }
                    break;
                }
            }

            return path;

        }


    }
}
