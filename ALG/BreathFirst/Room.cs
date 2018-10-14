using BreathFirst;
using System.Collections.Generic;

namespace Alg
{
    public class Room : IDrawable
    {
        public enum Direction { NORTH, EAST, SOUTH, WEST };

        public Dictionary<Direction, Hall> Connections;
        Hero hero;
        public string value;
        private bool hasVisited = false;
        public int x;
        public int y;

        public Room(int x, int y)
        {
            this.x = x;
            this.y = y;
            Connections = new Dictionary<Direction, Hall>();
            value = "X";

        }

        public void Visit(Hero hero)
        {
            this.hero = hero;
            hasVisited = true;
            value = "o";
        }

        public string Draw()
        {
            //if(hero != null && hasVisited)
            //{
            //    return "*";
            //}
            return value;
            //return string.Format(" [{0},{1}]  ", this.x, this.y);
        }

        public void Visit()
        {
            value = "S";
        }

        public void Leave()
        {
            value = "*";
        }

        public void AddHall(Hall hall, Direction direction)
        {
            if (!Connections.ContainsKey(direction))
            {
                Connections.Add(direction, hall);
            }

        }

        public void RemoveHall(Direction direction)
        {
            if (Connections.ContainsKey(direction))
            {
                Connections.Remove(direction);
            }

        }

        public bool HasConnection(Direction direction)
        {
            return Connections.ContainsKey(direction);
        }
    }
}

