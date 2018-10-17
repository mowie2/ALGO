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
        public Room[,] Rooms { get; set; }
        public Room EndRoom { get; set; }
        public List<Hall> Halls { get; set; }
        public Graph(int roomsizeX,int roomsizeY,/*int startX,int startY, */int endX, int endY)
        {
            this.roomsizeX = roomsizeX;
            this.roomsizeY = roomsizeY;
            this.Rooms = new Room[roomsizeX, roomsizeY];
            Halls = new List<Hall>();
            MakeGraph();
            //Hero h = new Hero(rooms[startX, startY]);
            this.EndRoom = Rooms[endX, endY];
            this.EndRoom.value = "E";
        }

        private void MakeGraph()
        {
            Random rand = new Random();
            for (int x = 0; x < roomsizeX; x++)
            {
                for (int y = 0; y < roomsizeY; y++)
                {
                    Room temp = new Room(x, y);
                    Rooms[x, y] = temp;
                }
            }

            for (int x = 0; x < roomsizeX; x++)
            {
                for (int y = 0; y < roomsizeY; y++)
                {
                    if (x != 0)
                    {
                        Hall hall = new Hall(rand.Next(1, 10));
                        Rooms[x, y].AddHall(hall, Room.Direction.WEST);
                        Rooms[x - 1, y].AddHall(hall, Room.Direction.EAST);
                        hall.AddConnections(Rooms[x, y], Rooms[x - 1, y]);
                        Halls.Add(hall);
                    }
                    if (y != 0)
                    {
                        Hall hall = new Hall(rand.Next(1, 9));
                        Rooms[x, y].AddHall(hall, Room.Direction.SOUTH);
                        Rooms[x, y - 1].AddHall(hall, Room.Direction.NORTH);
                        hall.AddConnections(Rooms[x, y], Rooms[x, y - 1]);
                        Halls.Add(hall);
                    }
                }
            }
            
        }

        public void Draw()
        {
            for (int y = roomsizeY - 1; y >= 0; y--)
            {
                for (int x = 0; x < roomsizeX; x++)
                {
                    Console.Write(Rooms[x, y].Draw() + " ");
                    if (Rooms[x, y].HasConnection(Room.Direction.EAST))
                    {
                        Console.Write(Rooms[x, y].Connections[Room.Direction.EAST].Draw() + " ");
                    }

                }
                Console.WriteLine("");
                for (int x = 0; x < roomsizeX; x++)
                {
                    if (Rooms[x, y].HasConnection(Room.Direction.SOUTH))
                    {
                        Console.Write(Rooms[x, y].Connections[Room.Direction.SOUTH].Draw() + "  ");
                        Console.Write(" ");
                    }
                }
                Console.WriteLine(" ");
            }
        }
    }
}
