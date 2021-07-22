using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Robots {
    public class Position {
        #region Custom exceptions
        /// <summary>
        /// Exception thrown when a position is not valid
        /// </summary>
        public class InvalidPositionException : Exception {
            public InvalidPositionException(string message) : base(message) { }
        }

        /// <summary>
        /// Exception thrown when the orientation is not valid
        /// </summary>
        public class InvalidOrientationException : Exception {
            public InvalidOrientationException(string message) : base(message) { }
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

        /// <summary>
        /// Character corresponding to the EAST orientation
        /// </summary>
        private const char EAST_CHAR = 'E';
        /// <summary>
        /// Character corresponding to the WEST orientation
        /// </summary>
        private const char WEST_CHAR = 'W';
        /// <summary>
        /// Character corresponding to the NORTH orientation
        /// </summary>
        private const char NORTH_CHAR = 'N';
        /// <summary>
        /// Character corresponding to the SOUTH orientation
        /// </summary>
        private const char SOUTH_CHAR = 'S';
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
        /// Orientation of the current position
        /// </summary>
        public EnumOrientation Orientation { get; set; }

        /// <summary>
        /// Orientation of the current position in string format
        /// </summary>
        public char VisualOrientation
        {
            get
            {
                switch (this.Orientation)
                {
                    case EnumOrientation.NORTH: return NORTH_CHAR;
                    case EnumOrientation.SOUTH: return SOUTH_CHAR;
                    case EnumOrientation.EAST: return EAST_CHAR;
                    case EnumOrientation.WEST: return WEST_CHAR;
                    default: throw new InvalidOrientationException("Invalid orientation:" + this.Orientation);
                }
            }
        }
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

        #region Instance methods
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", this.X, this.Y, this.Orientation.ToString());
        }
        #endregion

        #region Static methods    
        public static List<Char> GetAllowedOrientations()
        {
            return new List<Char>() { NORTH_CHAR, SOUTH_CHAR, WEST_CHAR, EAST_CHAR };
        }
        
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

        /// <summary>
        /// Transforms a string coordinate in a integer one. Throws an exception if it's not valid
        /// </summary>
        /// <param name="coordinate">Value to parse</param>
        /// <returns>Parsed coordinate</returns>
        public static int ParseCoordinate(string coordinate)
        {
            int result = int.Parse(coordinate);
            TryValidate(result);

            return result;
        }

        /// <summary>
        /// Transforms a string orientation in a enum one. Throws an exception if it's not valid.
        /// </summary>
        /// <param name="orientation">Value to parse</param>
        /// <returns>Parsed orientation</returns>
        public static EnumOrientation ParseOrientation(String orientation)
        {
            if (String.IsNullOrEmpty(orientation)) throw new InvalidOrientationException("Orientation cannot be empty");
            if (orientation.Length > 1) throw new InvalidOrientationException("Invalid orientation value: " + orientation);

            switch (Convert.ToChar(orientation))
            {
                case NORTH_CHAR: return EnumOrientation.NORTH;
                case SOUTH_CHAR: return EnumOrientation.SOUTH;
                case EAST_CHAR: return EnumOrientation.EAST;
                case WEST_CHAR: return EnumOrientation.WEST;
                default: throw new InvalidOrientationException("Invalid orientation value: " + orientation);
            }
        }
        #endregion
    }
}
