using Alg;
using System;
using System.Collections.Generic;

namespace BreathFirst
{
    internal class Program
    {

        

        private static void Main(string[] args)
        {
            Console.WriteLine("Geef een graaflengte x op :");
            int.TryParse(Console.ReadLine(), out int x);
            while (x < 1)
            {
                Console.WriteLine("Geef een GELDIGE graaflengte x op :");
                int.TryParse(Console.ReadLine(), out x);
            }
            Console.WriteLine("Geef een graaflengte y op :");
            int.TryParse(Console.ReadLine(), out int y);
            while (y < 1)
            {
                Console.WriteLine("Geef een GELDIGE graaflengte y op :");
                int.TryParse(Console.ReadLine(), out y);
            }



            Console.WriteLine("Geef een startpositie X  op :");
            int.TryParse(Console.ReadLine(), out int startX);
            while (startX < 0 || startX>=x)
            {
                Console.WriteLine("Geef een GELDIGE startpositie X  op :");
                int.TryParse(Console.ReadLine(), out startX);
            }
            Console.WriteLine("Geef een startpositie y op :");
            int.TryParse(Console.ReadLine(), out int startY);
            while (startY < 0 || startY >=y)
            {
                Console.WriteLine("Geef een GELDIGE startpositie y op :");
                int.TryParse(Console.ReadLine(), out startY);
            }



            Console.WriteLine("Geef een eindpositie X  op :");
            int.TryParse(Console.ReadLine(), out int endX);
            while (endX < 0 || endX >=x)
            {
                Console.WriteLine("Geef een GELDIGE eindpositie X  op :");
                int.TryParse(Console.ReadLine(), out endX);
            }
            Console.WriteLine("Geef een eindpositie y op :");
            int.TryParse(Console.ReadLine(), out int endY);
            while (endY < 0 || endY >=y)
            {
                Console.WriteLine("Geef een GELDIGE eindpositie y op :");
                int.TryParse(Console.ReadLine(), out endY);
            }

            Graph gr = new Graph(x, y, endX, endY);
            TalisMan t = new TalisMan();
            Hero h = new Hero(gr.rooms[startX, startY]);
            gr.Draw();
            Console.WriteLine(t.Use(h.currentRoom, gr.endRoom));
            

            Grenade g = new Grenade(gr.rooms,gr.halls);
            g.FindMSTKruskal(gr.halls);
            g.Use(h.currentRoom);
            gr.Draw();
            gr.ReviveGraph();
            gr.Draw();
            g.minimumSpanningTree = new List<Hall>();
            g.FindMSTPrim(h.currentRoom);
            g.Use(h.currentRoom);
            gr.Draw();




            Console.WriteLine();
            Console.ReadKey();
        }

    }
}
