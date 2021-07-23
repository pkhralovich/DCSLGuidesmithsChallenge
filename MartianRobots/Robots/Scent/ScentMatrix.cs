namespace MartianRobots.Robots.Scent {
    public class ScentMatrix : IScent {
        private bool[,] Memory;

        public ScentMatrix(int columns, int rows)
        {
            Memory = new bool[columns, rows];
        }

        public void Add(Position p)
        {
            Memory[p.X, p.Y] = true;
        }

        public bool IsLost(Position p)
        {
            return Memory[p.X, p.Y];
        }
    }
}
