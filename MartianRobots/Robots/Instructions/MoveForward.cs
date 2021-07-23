using MartianRobots.Robots.Movement;

namespace MartianRobots.Robots.Instructions {
    public class MoveForward : IInstruction {
        /// <summary>
        /// Moves the position in the direction that it is oriented
        /// </summary>
        /// <param name="pos">Position where the movement is going to be applied</param>
        public void Apply(Position pos)
        {
            if (pos.Orientation == Position.EnumOrientation.EAST) pos.X++;
            else if (pos.Orientation == Position.EnumOrientation.WEST) pos.X--;
            else if (pos.Orientation == Position.EnumOrientation.SOUTH) pos.Y--;
            else pos.Y++; //North orientation
        }
    }
}
