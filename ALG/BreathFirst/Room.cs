using BreathFirst;
using System.Collections.Generic;

namespace Alg
{
    public class Room : IDrawable
    {
        public enum Direction { north, eacht, south, west };

        private readonly Dictionary<Direction, Hall> Connections;

        private string value;

        public Room()
        {
            value = "X";
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

