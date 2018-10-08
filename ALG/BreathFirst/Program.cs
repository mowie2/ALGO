using Alg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreathFirst
{
    class Program
    {
        static void TesCreateGraph()
        {
            Room[,] rooms;

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    Room temp = new Room();
                }
            }
        }

        static void TestTalisman()
        {
            Room r = new Room();// { value = "e" };
            Room r2 = new Room();
            Hall h = new Hall(1,r,r2);
            r.Connections[Room.Direction.west] = h;
            r2.Connections[Room.Direction.east] = h;

            r = r2;
            r2 = new Room();
            h = new Hall(1, r, r2);
            r.Connections[Room.Direction.west] = h;
            r2.Connections[Room.Direction.east] = h;
            //r = r2;

            TalisMan t = new TalisMan();
            Console.Write(t.Use(r));
        }

        static void Main(string[] args)
        {
            TestTalisman();
            Console.Read();
        }
    }
}
