using Alg;
using System;
using System.Collections.Generic;

namespace BreathFirst
{
    internal class Program
    {

        

        private static void Main(string[] args)
        {
            Graph gr = new Graph(5, 5, 0, 0);
            TalisMan t = new TalisMan();
            int startX = 1;
            int startY = 1;
            Hero h = new Hero(gr.rooms[startX, startY]);
            Console.WriteLine(t.Use(h.currentRoom));
            gr.Draw();

            Grenade g = new Grenade(gr.rooms,gr.halls);
            g.Use(h.currentRoom);

            gr.Draw();

            //Console.WriteLine();
            Console.ReadKey();
        }

    }
}
