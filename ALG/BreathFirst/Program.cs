﻿using Alg;
using System;
using System.Collections.Generic;

namespace BreathFirst
{
    internal class Program
    {
        public static Room[,] MaakTestGraaf()
        {
            Room[,] rooms = new Room[2, 3];

            Room nRoom1 = new Room(1, 2);
            Room nRoom2 = new Room(0, 2);
            Hall haa = new Hall(2);
            haa.AddConnections(nRoom1, nRoom2);
            nRoom1.Connections[Room.Direction.WEST] = haa;
            nRoom2.Connections[Room.Direction.EAST] = haa;
            rooms[1, 2] = nRoom1;
            rooms[0, 2] = nRoom2;

            nRoom1 = rooms[1, 2];
            nRoom2 = new Room(1, 1);
            haa = new Hall(6);
            haa.AddConnections(nRoom1, nRoom2);
            nRoom1.Connections[Room.Direction.SOUTH] = haa;
            nRoom2.Connections[Room.Direction.NORTH] = haa;
            rooms[1, 1] = nRoom2;

            nRoom1 = rooms[0, 2];
            nRoom2 = new Room(0, 1);
            haa = new Hall(5);
            haa.AddConnections(nRoom1, nRoom2);
            nRoom1.Connections[Room.Direction.SOUTH] = haa;
            nRoom2.Connections[Room.Direction.NORTH] = haa;
            rooms[0, 1] = nRoom2;

            nRoom1 = rooms[1, 1];
            nRoom2 = rooms[0, 1];
            haa = new Hall(9);
            haa.AddConnections(nRoom1, nRoom2);
            nRoom1.Connections[Room.Direction.WEST] = haa;
            nRoom2.Connections[Room.Direction.EAST] = haa;

            nRoom1 = rooms[1, 1];
            nRoom2 = new Room(1, 0);
            haa = new Hall(6);
            haa.AddConnections(nRoom1, nRoom2);
            nRoom1.Connections[Room.Direction.SOUTH] = haa;
            nRoom2.Connections[Room.Direction.NORTH] = haa;
            rooms[1, 0] = nRoom2;

            nRoom1 = rooms[0, 1];
            nRoom2 = new Room(0, 0);
            haa = new Hall(6);
            haa.AddConnections(nRoom1, nRoom2);
            nRoom1.Connections[Room.Direction.SOUTH] = haa;
            nRoom2.Connections[Room.Direction.NORTH] = haa;
            rooms[0, 0] = nRoom2;

            nRoom1 = rooms[1, 0];
            nRoom2 = rooms[0, 0];
            haa = new Hall(9);
            haa.AddConnections(nRoom1, nRoom2);
            nRoom1.Connections[Room.Direction.WEST] = haa;
            nRoom2.Connections[Room.Direction.EAST] = haa;
            return rooms;
        }
        public static void PrintTestGraaf(Room[,] rooms)
        {
            for (int y = 3 - 1; y >= 0; y--)
            {
                for (int x = 0; x < 2; x++)
                {
                    Console.Write(rooms[x, y].Draw() + " ");
                    if (rooms[x, y].HasConnection(Room.Direction.EAST))
                    {
                        Console.Write(rooms[x, y].Connections[Room.Direction.EAST].Draw() + " ");
                    }

                }
                Console.WriteLine("");
                for (int x = 0; x < 2; x++)
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
            int sizex = 0;
            int sizey = 0;

            // roomsize
            while (sizex == 0 || sizey == 0)
            {
                if (sizex == 0)
                {

                    Console.WriteLine("Roomwidth:");
                    string size = Console.ReadKey().KeyChar.ToString();

                    if (!int.TryParse(size, out sizex))
                    {
                        Console.Clear();
                        Console.WriteLine("please give a valid roomsize");
                        continue;
                    }
                    Console.Clear();
                }
                if (sizey == 0)
                {

                    Console.WriteLine("RoomHeight:");
                    string size = Console.ReadKey().KeyChar.ToString();

                    if (!int.TryParse(size, out sizey))
                    {
                        Console.Clear();
                        Console.WriteLine("please give a valid roomsize");
                        continue;
                    }
                    Console.Clear();
                }

            }

            Random rand = new Random();
            Graph gr = new Graph(sizex, sizey, rand.Next(sizex), rand.Next(sizey));



            int startX = rand.Next(sizex);
            int startY = rand.Next(sizey);
            Hero h = new Hero(gr.Rooms[startX, startY]);

            TalisMan talisMan = new TalisMan();

            while (true)
            {
                //Console.Clear();
                Console.WriteLine("");
                gr.Draw();
                Console.WriteLine("");
                string key = Console.ReadKey().KeyChar.ToString();
                int ky = 9;
                if (!int.TryParse(key, out ky))
                {
                    Console.Clear();
                    Console.WriteLine("please select a valid key");
                    Console.WriteLine("1: talisman");
                    Console.WriteLine("2: gernade");
                    Console.WriteLine("3: compas");
                    Console.WriteLine("4: exit");
                    continue;
                }

                switch (ky)
                {
                    case 1:
                        Console.WriteLine("exit is" + talisMan.Use(h.currentRoom, gr.EndRoom) + " steps away");
                        continue;
                    case 2:
                        Grenade g = new Grenade(gr.Rooms, gr.Halls);
                        continue;
                    case 3:
                        Compas c = new Compas(gr.Rooms);

                        List<Room.Direction> k = c.Use(h.currentRoom, gr.EndRoom);

                        foreach (Room.Direction dir in k)
                        {
                            Console.Write(dir + " ");
                        }
                        List<Hall> halls = c.GetHalls(k, h.currentRoom);
                        Console.WriteLine("Enemy levels: ");
                        foreach (Hall hall in halls)
                        {
                            Console.Write("level " + hall.enemy.level + " ");
                        }
                        continue;
                    case 4:
                        Console.WriteLine();

                        Console.WriteLine("Thank you for playing!");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
