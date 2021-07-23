using MartianRobots.Robots.Movement;
using System;
using System.Collections.Generic;
using System.Text;
using static MartianRobots.Robots.Position;

namespace MartianRobots.Robots.Instructions {
    class RotateRight : IInstruction {
        public void Apply(Position pos)
        {
            Array enumValues = Enum.GetValues(typeof(EnumOrientation));

            int currentOrientation = (int)pos.Orientation;
            currentOrientation++;

            if (currentOrientation >= enumValues.Length)
                pos.Orientation = 0;

            pos.Orientation = (EnumOrientation) currentOrientation;
        }
    }
}
