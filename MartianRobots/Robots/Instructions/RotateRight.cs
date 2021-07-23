using MartianRobots.Robots.Movement;
using System;
using static MartianRobots.Robots.Position;

namespace MartianRobots.Robots.Instructions {
    public class RotateRight : IInstruction {
        /// <summary>
        /// Rotates to the right the current position. Moving to right implies rotatin clockwise.
        /// For example: E -> S -> W -> N -> E
        /// </summary>
        /// <param name="pos">Position where the movement is going to be applied</param>
        public void Apply(Position pos)
        {
            Array enumValues = Enum.GetValues(typeof(EnumOrientation));

            int currentOrientation = (int)pos.Orientation;
            currentOrientation--;

            if (currentOrientation < 0)
                currentOrientation = 3;

            pos.Orientation = (EnumOrientation)currentOrientation;
        }
    }
}
