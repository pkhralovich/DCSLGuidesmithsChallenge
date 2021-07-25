using MartianRobots.Robots;
using System;
using System.Text.RegularExpressions;

namespace MartianRobots.Planets {
    public abstract class Planet {
        #region Custom exceptions
        /// <summary>
        /// Exception that is thrown when an invalid string is given as the planets limit
        /// </summary>
        public class PlanetLimitsException : Exception {
            public PlanetLimitsException(string message) : base(message) { }
        }
        #endregion

        #region Constants
        /// <summary>
        /// Pattern that must follow the planet limits string
        /// </summary>
        private const string PLANET_LIMITS_REGEX = @"^\d+ \d+$";
        #endregion

        #region Properties
        /// <summary>
        /// Name of the planet
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Number of columns in the planet coordinate system. We assume that the minimum coordinate is 0.
        /// </summary>
        public int ColumnCount { get; }
        /// <summary>
        /// Number of rows in the planet coordinate system. We assume that the minimum coordinate is 0.
        /// </summary>
        public int RowCount { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor to be called from the child classes.
        /// </summary>
        /// <param name="rows">Number of rows of the planet</param>
        /// <param name="columns">Number of columns of the planet</param>
        protected Planet(int rows, int columns)
        {
            this.RowCount = rows;
            this.ColumnCount = columns;
        }
        #endregion

        #region Instance methods
        /// <summary>
        /// Validates if the given coordinates exists in the planet
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>True if the coordinates are in the valid range</returns>
        public bool InRange(int x, int y) {
            return x >= 0 
                    && x < ColumnCount
                    && y >= 0 
                    && y < RowCount;
        }
        
        /// <summary>
        /// Validates if the given position exists in the planet.
        /// </summary>
        /// <param name="pos">Position to validate</param>
        /// <returns>True if the position is in the valid range</returns>
        public bool InRange(Position pos) {
            return InRange(pos.X, pos.Y);
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Factory Method. Creates a new instance of a class that inherits from Planet
        /// </summary>
        /// <param name="worldLimits">String in format X Y. Each value must be less or equal to 50. Represents the limits of the planet.</param>
        /// <returns>Returns a new planet</returns>
        public static Planet Create(String worldLimits) {
            //Check if the given string matches the expected pattern
            if (!String.IsNullOrEmpty(worldLimits) && Regex.IsMatch(worldLimits, PLANET_LIMITS_REGEX))
            {
                String[] values = worldLimits.Split(" ");
                //Create planet with limits that contains the given right-top position.
                //As it's a position and the world base is (0,0), we add a +1 to the given value.
                int ColumnCount = Position.ParseCoordinate(values[0], true) + 1;
                int RowCount = Position.ParseCoordinate(values[1], false) + 1;

                //TODO: Allow other subclasses creation with other properties
                //if there is some interest in giving different properties to each planet
                return new Mars(RowCount, ColumnCount);
            }
            else throw new PlanetLimitsException("Invalid worldLimits format");
        }
        #endregion
    }
}
