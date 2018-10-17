using Alg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreathFirst
{
    class Graph
    {
        private readonly int roomsizeX;
        private readonly int roomsizeY;
        public Room[,] rooms;
        public Room endRoom;
        public List<Hall> halls;
        public Graph(int roomsizeX,int roomsizeY,int endX, int endY)
        {
            this.roomsizeX = roomsizeX;
            this.roomsizeY = roomsizeY;
            this.rooms = new Room[roomsizeX, roomsizeY];
            halls = new List<Hall>();
            MakeGraph();
            this.endRoom = rooms[endX, endY];
            this.endRoom.value = "E";
        }

        private void MakeGraph()
        {
            Random rand = new Random();
            for (int x = 0; x < roomsizeX; x++)
            {
                for (int y = 0; y < roomsizeY; y++)
                {
                    Room temp = new Room(x, y);
                    rooms[x, y] = temp;
                }
            }

            for (int x = 0; x < roomsizeX; x++)
            {
                for (int y = 0; y < roomsizeY; y++)
                {
                    if (x != 0)
                    {
                        Hall hall = new Hall(rand.Next(1, 10));
                        rooms[x, y].AddHall(hall, Room.Direction.WEST);
                        rooms[x - 1, y].AddHall(hall, Room.Direction.EAST);
                        hall.AddConnections(rooms[x, y], rooms[x - 1, y]);
                        halls.Add(hall);
                    }
                    if (y != 0)
                    {
                        Hall hall = new Hall(rand.Next(1, 9));
                        rooms[x, y].AddHall(hall, Room.Direction.SOUTH);
                        rooms[x, y - 1].AddHall(hall, Room.Direction.NORTH);
                        hall.AddConnections(rooms[x, y], rooms[x, y - 1]);
                        halls.Add(hall);
                    }
                }
            }
            
        }

        public void ReviveGraph()
        {
            foreach (Hall currentHall in halls)
            {
                currentHall.value = currentHall.enemy.level.ToString();
            }
        }

        public void Draw()
        {
            for (int y = roomsizeY - 1; y >= 0; y--)
            {
                for (int x = 0; x < roomsizeX; x++)
                {
                    Console.Write(rooms[x, y].Draw() + " ");
                    if (rooms[x, y].HasConnection(Room.Direction.EAST))
                    {
                        Console.Write(rooms[x, y].Connections[Room.Direction.EAST].Draw() + " ");
                    }
                }
                Console.WriteLine("");
                for (int x = 0; x < roomsizeX; x++)
                {
                    if (rooms[x, y].HasConnection(Room.Direction.SOUTH))
                    {
                        Console.Write(rooms[x, y].Connections[Room.Direction.SOUTH].Draw() + "  ");
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }
}
