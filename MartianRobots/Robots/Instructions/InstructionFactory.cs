using MartianRobots.Robots.Instructions;
using System;
using System.Collections.Generic;

namespace MartianRobots.Robots.Movement {
    public class InstructionFactory {
        #region Custom exceptions
        /// <summary>
        /// Exception thrown when the current instruction is not valid
        /// </summary>
        public class InvalidCommantException : Exception {
            public InvalidCommantException(string message) : base(message) { }
        }
        #endregion

        #region Constants
        /// <summary>
        /// Rotate to right command
        /// </summary>
        private const char ROTATE_RIGHT = 'R';
        /// <summary>
        /// Rotate to left command
        /// </summary>
        private const char ROTATE_LEFT = 'L';
        /// <summary>
        /// Move forward command
        /// </summary>
        private const char MOVE_FORWARD = 'F';
        #endregion

        /// <summary>
        /// Creates a new instance of a movement
        /// </summary>
        /// <param name="command">Chosen command</param>
        /// <returns>Movement corresponding to the given command</returns>
        public static IInstruction Create(char command)
        {
            switch (command)
            {
                case ROTATE_RIGHT: return new RotateRight();
                case ROTATE_LEFT: return new RotateLeft();
                case MOVE_FORWARD: return new MoveForward();
                default: throw new InvalidCommantException("Invalid command: " + command);
            }
        }

        public static List<Char> GetAllowedCommands() {
            return new List<Char>() { ROTATE_RIGHT, ROTATE_LEFT, MOVE_FORWARD };
        }
    }
}
