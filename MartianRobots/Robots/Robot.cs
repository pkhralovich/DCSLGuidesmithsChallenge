using MartianRobots.Planets;
using MartianRobots.Robots.Movement;
using MartianRobots.Robots.Scent;
using System;
using System.Collections.Generic;
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
        public Position CurrentPosition { get; private set; }
        /// <summary>
        /// Returns the instructions set to be applied to the robot
        /// </summary>
        public List<IInstruction> Instructions { get; set; }
        /// <summary>
        /// Returns the planet where is located the robot
        /// </summary>
        public Planet CurrentPlanet { get; }
        #endregion

        #region Static Properties
        private static IScent memory;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor to create a new robot
        /// </summary>
        /// <param name="pos">Initial position of the robot</param>
        /// <param name="instructions">Instructions set to apply to him</param>
        /// <param name="planet">Planet where the robot is going to be located</param>
        private Robot(Position pos, List<IInstruction> instructions, Planet planet)
        {
            this.IsLost = false;
            this.CurrentPosition = pos;
            this.CurrentPlanet = planet;
            this.Instructions = instructions;
        }
        #endregion

        #region Instance methods
        /// <summary>
        /// Applies all the given instructions to the robot. If the robot is lost, it will stop applying them.
        /// </summary>
        public void ApplyMovement()
        {
            List<IInstruction>.Enumerator eInstructions = this.Instructions.GetEnumerator();
            while (eInstructions.MoveNext() && !this.IsLost)
            {
                Position nextPosition = new Position(this.CurrentPosition);
                IInstruction instruction = eInstructions.Current;
                instruction.Apply(nextPosition);

                if (!this.CurrentPlanet.InRange(nextPosition))
                {
                    if (memory.IsLost(this.CurrentPosition))
                        continue;

                    this.IsLost = true;
                    memory.Add(this.CurrentPosition);
                }
                else this.CurrentPosition = nextPosition;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}{1}", this.CurrentPosition.ToString(), this.IsLost ? " LOST" : String.Empty);
        }
        #endregion

        #region Static methods
        /// <summary>
        /// Initializes de memory system of the robots
        /// </summary>
        /// <param name="optimizeSpeed">Tells to the robots if they should optimize the memory or the speed</param>
        /// <param name="p">Planet where the robots are going to be placed</param>
        public static void InitScent(bool optimizeSpeed, Planet p)
        {
            if (memory == null) memory = ScentFactory.Create(optimizeSpeed, p);
        }

        /// <summary>
        /// Resets the memory of the rebots to the initial state. InitScent must be called again.
        /// </summary>
        public static void ResetScent()
        {
            memory = null;
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
            List<IInstruction> instrucctions = ParseInstructions(instructions);
            return new Robot(p, instrucctions, planet);
        }

        /// <summary>
        /// Tries to parse the given position string. Throws an exception if the string is not valid.
        /// </summary>
        /// <param name="planet">Planet where the robot is going to be placed</param>
        /// <param name="position">Initial position of the robot in string format</param>
        /// <returns>A new valid position</returns>
        private static Position ParsePosition(Planet planet, string position)
        {
            string pattern = @"^\d+ \d+ [" + new string(Position.GetAllowedOrientations().ToArray()) + "]$";
            if (Regex.IsMatch(position, pattern))
            {
                String[] values = position.Split(POSITION_SEPARATOR);
                int X = Position.ParseCoordinate(values[0], true);
                int Y = Position.ParseCoordinate(values[1], false);
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
        private static List<IInstruction> ParseInstructions(string instructions)
        {
            string pattern = @"^[" + new String(InstructionFactory.GetAllowedCommands().ToArray()) + "]{1,100}$";
            if (Regex.IsMatch(instructions, pattern))
            {
                List<IInstruction> oRes = new List<IInstruction>();

                CharEnumerator enumerator = instructions.GetEnumerator();
                while(enumerator.MoveNext())
                {
                    oRes.Add(InstructionFactory.Create(enumerator.Current));
                }

                return oRes;
            }
            throw new RobotInstructionsException("Invalid robot instructions format");
        }
        #endregion
    }
}
