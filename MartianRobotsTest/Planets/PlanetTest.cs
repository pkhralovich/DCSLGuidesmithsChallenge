using MartianRobots.Planets;
using MartianRobots.Robots;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MartianRobots.Robots.Position;

namespace MartianRobotsTest.Planets {
    [TestClass]
    public class PlanetTest {
        static Planet p;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            p = Planet.Create(5, 5);
        }

        [TestMethod]
        public void InRange_ResultTrue()
        {
            Assert.AreEqual<bool>(true, p.InRange(3, 2));
        }

        [DataTestMethod]
        public void InRange_ResultFalse_1()
        {
            Assert.AreEqual<bool>(false, p.InRange(6, 5));
        }

        [DataTestMethod]
        public void InRange_ResultFalse_2()
        {
            Assert.AreEqual<bool>(false, p.InRange(5, 6));
        }

        [TestMethod]
        public void InRange_Position_ResultTrue()
        {
            Position pos = new Position(3, 2, EnumOrientation.EAST);
            Assert.AreEqual<bool>(true, p.InRange(pos));
        }

        [TestMethod]
        public void InRange_Position_ResultFalse_1()
        {
            Position pos = new Position(6, 5, EnumOrientation.EAST);
            Assert.AreEqual<bool>(false, p.InRange(pos));
        }

        [TestMethod]
        public void InRange_Position_ResultFalse_2()
        {
            Position pos = new Position(5, 6, EnumOrientation.EAST);
            Assert.AreEqual<bool>(false, p.InRange(pos));
        }

        [DataTestMethod]
        [DataRow("5 5")]
        [DataRow("10 10")]
        public void Create_Valid(string value)
        {
            Planet created = Planet.Create(value);
            Assert.IsNotNull(created);
            Assert.AreEqual<string>(value, (created.ColumnCount-1) + " " + (created.RowCount-1));
        }

        [DataTestMethod]
        [ExpectedException(typeof(Planet.PlanetLimitsException))]
        [DataRow("")]
        [DataRow("XX")]
        [DataRow("1 2 3")]
        [DataRow("-1 51")]
        [DataRow("1 -51")]
        public void Create_InvalidFormat(string value)
        {
            Planet.Create(value);
        }

        [DataTestMethod]
        [ExpectedException(typeof(InvalidPositionException))]
        [DataRow("51 1")]
        [DataRow("1 51")]
        public void Create_InvalidCoordinates(string value)
        {
            Planet.Create(value);
        }
    }
}
