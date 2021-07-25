using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MartianRobots.Planets;
using MartianRobots.Robots;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MartianRobots.Robots.Robot;

namespace MartianRobotsTest {
    [TestClass]
    public class RobotTest {
        static Planet p;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            p = Planet.Create(6, 6);
        }

        [DataTestMethod]
        [ExpectedException(typeof(RobotPositionException))]
        [DataRow("5 5 X")]
        [DataRow("-5 5 S")]
        [DataRow("5 -5 W")]
        [DataRow("")]
        [DataRow("0 0 N N")]
        public void ParsePosition_Error(string value)
        {
            try
            {
                object[] parameters = { p, value };
                CallReflectionRobot(parameters, "ParsePosition");
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        [DataTestMethod]
        [DataRow("5 5 N")]
        [DataRow("5 5 S")]
        [DataRow("5 5 W")]
        [DataRow("5 5 E")]
        [DataRow("0 0 N")]
        [DataRow("0 5 N")]
        [DataRow("5 0 N")]
        [DataRow("2 3 N")]
        public void ParsePosition_Success(string value)
        {
            object[] parameters = { p, value };
            CallReflectionRobot(parameters, "ParsePosition");
        }
       
        [DataTestMethod]
        [ExpectedException(typeof(RobotInstructionsException))]
        [DataRow("")]
        [DataRow("FLRB")]
        [DataRow("FLR FLR FLR")]
        [DataRow("FLRFLRFLRFLRFLRFFLRFLRFLRFLRFLRFFLRFLRFLRFLRFLRFFLRFLRF" +
                 "LRFLRFLRFFLRFLRFLRFLRFLRFFLRFLRFLRFLRFLRFFLRFLRFLRFLRFL" +
                 "RFFLRFLRFLRFLRFLRF")]
        public void ParseInstructions_Error(string value)
        {
            try
            {
                object[] parameters = { value };
                CallReflectionRobot(parameters, "ParseInstructions");
            } catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }

        [DataTestMethod]
        [DataRow("L")]
        [DataRow("R")]
        [DataRow("F")]
        [DataRow("LLFFRR")]
        [DataRow("LFRLFRLFRLFRLFRLFR")]
        public void ParseInstructions_Success(string value)
        {
            object[] parameters = { value };
            CallReflectionRobot(parameters, "ParseInstructions");
        }

        private void CallReflectionRobot(object[] parameters, string methodName)
        {
            //Testing private method through reflection
            MethodInfo methodInfo = typeof(Robot).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Static);
            methodInfo.Invoke(null, parameters);
        }
    }
}
