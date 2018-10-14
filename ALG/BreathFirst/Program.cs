using Alg;
using System;
using System.Collections.Generic;

namespace BreathFirst
{
    internal class Program
    {

        public static void Draw(Room[,] rooms,int roomsizeY, int roomsizeX)
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

        private static void Main(string[] args)
        {
            //Console.ReadLine();
            int roomsizeX = 3;
            int roomsizeY = 3;
            Room[,] rooms = new Room[roomsizeX, roomsizeY];
            List<Hall> halls = new List<Hall>();
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
                        hall.AddConnections(rooms[x, y], rooms[x , y-1]);
                        halls.Add(hall);
                    }

                }
            }

            Hero h = new Hero(rooms[1,1]);
            rooms[0, 0].value = "e";

            Draw(rooms, roomsizeY, roomsizeX);



            TalisMan t = new TalisMan();
            Grenade g = new Grenade(rooms,halls);
            

            Console.WriteLine(t.Use(h.currentRoom));
            g.Use(h.currentRoom);

            Draw(rooms, roomsizeY, roomsizeX);
            
            Console.WriteLine();
            Console.ReadKey();
        }

    }
}
