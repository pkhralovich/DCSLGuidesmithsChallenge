using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Robots {
    public class Instruction {
        //TODO: Decide how to apply instructions. Probably some kind of Factory + Behavioural (Strategy) patterns
        public char Command { get; set; }

        public Instruction(char command)
        {
            this.Command = command;
        }

        public static Instruction Create(char command)
        {
            return new Instruction(command);
        }
    }
}
