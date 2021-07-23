using System.Collections.Generic;

namespace MartianRobots.Robots.Scent {
    public class ScentList : IScent {
        private List<Position> Memory = new List<Position>();

        public void Add(Position p)
        {
            Memory.Add(p);
        }

        public bool IsLost(Position p)
        {
            return Memory.Find(item => item.X == p.X && item.Y == p.Y) != null;
        }
    }
}
