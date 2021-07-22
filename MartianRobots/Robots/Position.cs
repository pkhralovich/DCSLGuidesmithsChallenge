using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Robots {
    public class Position {
        #region Custom exceptions
        /// <summary>
        /// Exception thrown then a position is not valid
        /// </summary>
        public class InvalidPositionException : Exception {
            public InvalidPositionException(string message) : base(message) { }
        }
        #endregion

        #region Enums
        /// <summary>
        /// Allowed orientations of a position
        /// </summary>
        public enum EnumOrientation {
            NORTH = 0,
            SOUTH = 1,
            WEST = 2,
            EAST = 3
        }
        #endregion

        #region Constants
        /// <summary>
        /// Minimium allowed value of a coordinate
        /// </summary>
        public const int MIN_COORDINATE = 0;
        /// <summary>
        /// Maximim allowed value of a coordinate
        /// </summary>
        public const int MAX_COORDINATE = 50;
        #endregion

        #region Properties
        private int _X;
        private int _Y;

        /// <summary>
        /// X coordinate of the current position
        /// </summary>
        public int X
        {
            get
            {
                return _X;
            }
            set
            {
                Position.TryValidate(value);
                _X = value;
            }
        }

        /// <summary>
        /// Y coordinate of the current position
        /// </summary>
        public int Y {
            get
            {
                return _Y;
            }
            set {
                Position.TryValidate(Y);
                _Y = value;
            }
        }

        /// <summary>
        /// Orientation coordinate of the current position
        /// </summary>
        public EnumOrientation Orientation { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new position in the (0,0) point and with EAST orientation
        /// </summary>
        public Position()
        {
            this.X = 0;
            this.Y = 0;
            this.Orientation = EnumOrientation.EAST;
        }

        /// <summary>
        /// Creates a new position with the given value
        /// </summary>
        /// <param name="X">The X coordinate to set</param>
        /// <param name="Y">The Y coordinate to set</param>
        /// <param name="orientation">The orientation to set</param>
        public Position(int X, int Y, EnumOrientation orientation) {
            this.X = X;
            this.Y = Y;
            this.Orientation = orientation;
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Checks if the given value is a valid coordinate. Throws an exception if not.
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <exception cref="InvalidPositionException">The value is not inside the allowed range</throws>
        private static void TryValidate(int value)
        {
            if (value > MAX_COORDINATE || value < MIN_COORDINATE)
            {
                String message = String.Format("Invalid X value. Must be in range [{0},{1}]", MIN_COORDINATE, MAX_COORDINATE);
                throw new InvalidPositionException(message);
            }
        }
        #endregion
    }
}
