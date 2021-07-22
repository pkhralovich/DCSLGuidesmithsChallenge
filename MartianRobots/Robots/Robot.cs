using MartianRobots.Planets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static MartianRobots.Robots.Position;

namespace MartianRobots.Robots {
    /// <summary>
    /// Class that represents a Robot. I assume that no more
    /// kind of robots are going to be implemented in the future. Anyway, 
    /// it's possible to allow it with some changes in the class structure.
    /// </summary>
    public class Robot {
        #region Custom exceptions
        /// <summary>
        /// Exception thrown when the robot position is not valid
        /// </summary>
        public class RobotPositionException : Exception {
            public RobotPositionException(string message) : base(message) { }
        }

        /// <summary>
        /// Exception thrown then the robot instructions are not valid
        /// </summary>
        public class RobotInstructionsException : Exception {
            public RobotInstructionsException(string message) : base(message) { }
        }
        #endregion

        #region Constants
        /// <summary>
        /// Pattern that must follow the robot position string
        /// </summary>
        private const string ROBOT_POSITION_PATTERN = @"\d+ \d+ [NSEW]";
        /// <summary>
        /// Pattern that must follow the robot instructions string
        /// </summary>
        private const string ROBOT_INSTRUCTIONS_PATTERN = @"[RFL]{1,100}";
        /// <summary>
        /// Separator character between position information
        /// </summary>
        private const string POSITION_SEPARATOR = " ";
        #endregion

        #region Properties
        /// <summary>
        /// Tells if the robot is lost in the infinite
        /// </summary>
        public bool IsLost { get; private set; }
        /// <summary>
        /// Returns the current position of the robot
        /// </summary>
        public Position CurrentPosition { get; }
        /// <summary>
        /// Returns the instructions set to be applied to the robot
        /// </summary>
        public List<Instruction> Instructions { get; set; }
        #endregion

        #region Static Properties
        //TODO: Decide how to manage "Scent". It should be a centralized static storage system
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor to create a new robot
        /// </summary>
        /// <param name="pos">Initial position of the robot</param>
        /// <param name="instructions">Instructions set to apply to him</param>
        private Robot(Position pos, List<Instruction> instructions)
        {
            this.IsLost = false;
            this.CurrentPosition = pos;
            this.Instructions = instructions;
        }
        #endregion

        #region Instance methods
        public void ApplyMovement()
        {
            throw new NotImplementedException("TODO: Implement");
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.CurrentPosition.ToString(), this.IsLost ? "LOST" : String.Empty);
        }
        #endregion

        #region Static methods
        public static void InitScent(Planet planet)
        {
            throw new NotImplementedException("TODO: Implement");
        }

        /// <summary>
        /// Method that creates a new robot with the given strings
        /// </summary>
        /// <param name="planet">Planet where the robot is going to be placed</param>
        /// <param name="position">Initial position of the robot in string format</param>
        /// <param name="instructions">Instructions to apply to the robot</param>
        /// <returns>A new robot instance</returns>
        public static Robot Create(Planet planet, string position, string instructions)
        {
            Position p = ParsePosition(planet, position);
            List<Instruction> instrucctions = ParseInstructions(instructions);
            return new Robot(p, instrucctions);
        }

        /// <summary>
        /// Tries to parse the given position string. Throws an exception if the string is not valid.
        /// </summary>
        /// <param name="planet">Planet where the robot is going to be placed</param>
        /// <param name="position">Initial position of the robot in string format</param>
        /// <returns>A new valid position</returns>
        private static Position ParsePosition(Planet planet, string position)
        {
            if (Regex.IsMatch(position, ROBOT_POSITION_PATTERN))
            {
                String[] values = position.Split(POSITION_SEPARATOR);
                int X = Position.ParseCoordinate(values[0]);
                int Y = Position.ParseCoordinate(values[1]);
                EnumOrientation orientation = Position.ParseOrientation(values[2]);

                if (!planet.InRange(X, Y)) throw new RobotPositionException("Robot coordinates out of planet bounds");

                return new Position(X, Y, orientation);
            }
            else throw new RobotPositionException("Invalid robot position format");
        }

        /// <summary>
        /// Tries to parse the given instructions string. Throws an exception if the string is not valid.
        /// </summary>
        /// <param name="instructions">Instructions set to apply to the robot in string format</param>
        /// <returns>List of parsed instructions</returns>
        private static List<Instruction> ParseInstructions(string instructions)
        {
            if (Regex.IsMatch(instructions, ROBOT_INSTRUCTIONS_PATTERN))
            {
                List<Instruction> oRes = new List<Instruction>();

                CharEnumerator enumerator = instructions.GetEnumerator();
                while(enumerator.MoveNext())
                {
                    oRes.Add(Instruction.Create(enumerator.Current));
                }

                return oRes;
            }
            throw new RobotInstructionsException("Invalid robot instructions format");
        }
        #endregion
    }
}
