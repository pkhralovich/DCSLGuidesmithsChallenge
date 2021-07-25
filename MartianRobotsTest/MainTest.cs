using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MartianRobots;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianRobotsTest {
    [TestClass]
    public class MainTest {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void TestCases_OptimizeSpeed(int i)
        {
            Arguments args = new Arguments();
            args.OptimizeSpeed = true;

            String path = Directory.GetCurrentDirectory();
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            args.InstructionsPath = path + @"\Samples\case" + i + ".txt";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                MartianRobots.Robots.Robot.ResetScent();
                MartianRobots.MartianRobots.MoveRobots(args);

                string expected = File.ReadAllText(path + @"\Samples\case" + i + "_expected.txt");
                string result = sw.ToString();
                File.WriteAllText(path + @"\Samples\case" + i + "_result.txt", result);
                Assert.AreEqual<string>(expected, sw.ToString(), "Case failed: " + i);
            }
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        public void TestCases_OptimizeMemory(int i)
        {
            Arguments args = new Arguments();
            args.OptimizeSpeed = false;

            String path = Directory.GetCurrentDirectory();
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            path = Directory.GetParent(path).FullName;
            args.InstructionsPath = path + @"\Samples\case" + i + ".txt";

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                MartianRobots.Robots.Robot.ResetScent();
                MartianRobots.MartianRobots.MoveRobots(args);

                string expected = File.ReadAllText(path + @"\Samples\case" + i + "_expected.txt");
                string result = sw.ToString();
                File.WriteAllText(path + @"\Samples\case" + i + "_result.txt", result);
                Assert.AreEqual<string>(expected, sw.ToString(), "Case failed: " + i);
            }
        }
    }
}
