using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Robots.Movement {
    public interface IInstruction {
        void Apply(Position pos);
    }
}


