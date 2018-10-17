using Alg;
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
            Graph gr = new Graph(3, 3, 0, 0);
            TalisMan t = new TalisMan();
            int startX = 2;
            int startY = 2;
            Hero h = new Hero(gr.Rooms[startX, startY]);
            gr.Draw();
            //Console.WriteLine(t.Use(h.currentRoom));

            //Grenade g = new Grenade(gr.rooms,gr.halls);
            //g.Use(h.currentRoom);

            //gr.Draw();

            //Room[,] rooms = MaakTestGraaf();
            //PrintTestGraaf(rooms);

            Compas c = new Compas(gr.Rooms);
            List<Room.Direction> k = c.Use(h.currentRoom,gr.EndRoom);
            foreach(Room.Direction dir in k)
            {
                Console.Write(dir + " ");
            }
            Console.ReadKey();
        }

    }
}
