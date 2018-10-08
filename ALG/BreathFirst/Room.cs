using BreathFirst;
using System.Collections.Generic;

namespace Alg
{
    public class Room : IDrawable
    {
        public enum Direction { north, east, south, west };

        public readonly Dictionary<Direction, Hall> Connections;

        public string value;

        protected static int globalId = 0;
        public int id = 0;

        public Room()
        {
            Connections = new Dictionary<Direction, Hall>();
            value = "X";
            globalId++;
            id = globalId;
        }

        public void Visit()
        {
            value = "*";
        }

        public string Draw()
        {
            return value;
        }
    }
}

