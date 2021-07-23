using CommandLine;
using MartianRobots.Planets;
using MartianRobots.Robots;
using System;
using System.Collections.Generic;
using System.IO;

namespace MartianRobots {
    public class MartianRobots {
        static void Main(string[] args) {
            Parser.Default
                .ParseArguments<Arguments>(args)
                .WithParsed(MoveRobots);
            Console.ReadKey();
        }

        /// <summary>
        /// Try to execute script with the given config
        /// </summary>
        /// <param name="config">Configuration params</param>
        private static void MoveRobots(Arguments config) {
            try
            {
                StreamReader instructions = new StreamReader(config.InstructionsPath);
                Planet mars = Planet.Create(instructions.ReadLine());

                //Initialize robots common "Scent"
                Robot.InitScent(config.OptimizeSpeed, mars);
                //Initialize list of Robots
                List<Robot> robots = new List<Robot>();

                //Read and process file
                while (!instructions.EndOfStream)
                {
                    string robotLine1 = instructions.ReadLine();
                    string robotLine2 = instructions.ReadLine();

                    //Try to create a new robot instance
                    Robot currentRobot = Robot.Create(mars, robotLine1, robotLine2);
                    //Try to apply movement to the robot
                    currentRobot.ApplyMovement();
                    //Add robot to the array
                    robots.Add(currentRobot);
                }

                //Print results
                Console.WriteLine("End of file! Results: ");
                robots.ForEach(robot => Console.WriteLine(robot.ToString()));
            } catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found. Check the entered path.");
            } catch (Exception e)
            {
                Console.WriteLine("Oops... Something happned:" + e.Message);
            }
        }
    }

    #region Auxiliar classes
    /// <summary>
    /// Class that contains the allowed arguments
    /// </summary>
    class Arguments {
        [Option("fast", Required = false, Default = true, HelpText="Apply a faster version that uses more memory")]
        public bool OptimizeSpeed { get; set; }

        [Option("instructions", Required = true, HelpText="Path to the file containing the movements")]
        public string InstructionsPath { get; set; }
    }
    #endregion
}
