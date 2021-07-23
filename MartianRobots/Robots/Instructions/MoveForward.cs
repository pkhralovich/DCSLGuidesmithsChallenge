using MartianRobots.Robots.Movement;

namespace MartianRobots.Robots.Instructions {
    class MoveForward : IInstruction {
        public void Apply(Position pos)
        {
            if (pos.Orientation == Position.EnumOrientation.EAST) pos.X++;
            else if (pos.Orientation == Position.EnumOrientation.WEST) pos.X--;
            else if (pos.Orientation == Position.EnumOrientation.SOUTH) pos.Y--;
            else pos.Y++; //North orientation
        }
    }
}
