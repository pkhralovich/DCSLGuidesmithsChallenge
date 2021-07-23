using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Robots {
    public interface IScent {
        bool IsLost(Position p);
        void Add(Position p);
    }
}
