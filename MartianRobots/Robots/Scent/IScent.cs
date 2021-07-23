namespace MartianRobots.Robots.Scent {
    public interface IScent {
        bool IsLost(Position p);
        void Add(Position p);
    }
}
