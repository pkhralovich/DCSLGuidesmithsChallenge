using MartianRobots.Robots.Movement;
using System;
using System.Collections.Generic;
using System.Text;
using static MartianRobots.Robots.Position;

namespace MartianRobots.Robots.Instructions {
    class RotateLeft : IInstruction {
        public void Apply(Position pos)
        {
            Array enumValues = Enum.GetValues(typeof(EnumOrientation));

            int currentOrientation = (int) pos.Orientation;
            currentOrientation--;

            if (currentOrientation < 0)
                currentOrientation = 0;

            pos.Orientation = (EnumOrientation)currentOrientation;
        }
    }
}
