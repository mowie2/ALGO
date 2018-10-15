using Alg;
using System;
using System.Collections.Generic;

namespace BreathFirst
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Console.ReadLine();
            int roomsizeX = 10;
            int roomsizeY = 10;
            Room[,] rooms = new Room[roomsizeX, roomsizeY];
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
                        Hall hall = new Hall(rand.Next(1, 9));
                        Room room = rooms[x, y];
                        room.AddHall(hall, Room.Direction.WEST);
                        rooms[x - 1, y].AddHall(hall, Room.Direction.EAST);
                    }
                    if (y != 0)
                    {
                        Hall hall = new Hall(rand.Next(1, 9));
                        rooms[x, y].AddHall(hall, Room.Direction.SOUTH);
                        rooms[x, y - 1].AddHall(hall, Room.Direction.NORTH);
                    }

                }
            }


            for (int y = roomsizeY - 1; y >= 0; y--)
            {
                for (int x = 0; x < roomsizeX; x++)
                {
                    Console.Write(rooms[x, y].Draw());
                    if (rooms[x, y].HasConnection(Room.Direction.EAST))
                    {
                        Console.Write(rooms[x, y].Connections[Room.Direction.EAST].Draw());
                    }

                }
                Console.WriteLine("");
                for (int x = 0; x < roomsizeX; x++)
                {
                    if (rooms[x, y].HasConnection(Room.Direction.SOUTH))
                    {
                        Console.Write(rooms[x, y].Connections[Room.Direction.SOUTH].Draw());
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }

            Console.ReadKey();
        }

    }
}
