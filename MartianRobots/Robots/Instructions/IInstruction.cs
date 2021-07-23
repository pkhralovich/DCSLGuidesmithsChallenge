namespace MartianRobots.Robots.Movement {
    public interface IInstruction {
        void Apply(Position pos);
    }
}


