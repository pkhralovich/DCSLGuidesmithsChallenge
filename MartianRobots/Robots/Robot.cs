using MartianRobots.Planets;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Robots {
    public class Robot {
        #region Properties
        public bool IsLost { get; private set; }
        public Position CurrentPosition { get; }
        #endregion

        #region Static Properties
        //TODO: Decide how to manage "Scent". It should be a centralized static storage system
        #endregion

        #region Constructors
        public Robot(Position pos)
        {
            this.IsLost = false;
            this.CurrentPosition = pos;
        }
        #endregion

        #region Instance methods
        public void ApplyMovement()
        {
            throw new NotImplementedException("TODO: Implement");
        }
        #endregion

        #region Static methods
        public static Robot Create(string position, string instructions)
        {
            throw new NotImplementedException("TODO: Implement");
        }

        public static void InitScent(Planet planet)
        {
            throw new NotImplementedException("TODO: Implement");
        }
        #endregion
    }
}
