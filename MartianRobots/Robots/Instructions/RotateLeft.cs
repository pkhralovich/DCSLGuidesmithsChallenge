using MartianRobots.Robots.Movement;
using System;
using System.Collections.Generic;
using System.Text;
using static MartianRobots.Robots.Position;

namespace MartianRobots.Robots.Instructions {
    class RotateLeft : IInstruction {
        /// <summary>
        /// Rotates to the right the current position. Moving to right implies rotatin counterclockwise.
        /// For example: E -> N -> W -> S -> E
        /// </summary>
        /// <param name="pos">Position where the movement is going to be applied</param>
        public void Apply(Position pos)
        {
            Array enumValues = Enum.GetValues(typeof(EnumOrientation));

            int currentOrientation = (int)pos.Orientation;
            currentOrientation++;

            if (currentOrientation >= enumValues.Length)
                currentOrientation = 0;

            pos.Orientation = (EnumOrientation)currentOrientation;
        }
    }
}
