using MartianRobots.Robots;
using MartianRobots.Robots.Instructions;
using MartianRobots.Robots.Movement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MartianRobots.Robots.Position;

namespace MartianRobotsTest.Instructions {
    [TestClass]
    public class InstructionsTest {
        [TestMethod]
        public void RotateRight_NorthToEast()
        {
            IInstruction i = InstructionFactory.Create('R');
            Position p = new Position(0, 0, EnumOrientation.NORTH);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(RotateRight));
            Assert.AreEqual(EnumOrientation.EAST, p.Orientation);
        }

        [TestMethod]
        public void RotateRight_EastToSouth()
        {
            IInstruction i = InstructionFactory.Create('R');
            Position p = new Position(0, 0, EnumOrientation.EAST);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(RotateRight));
            Assert.AreEqual(EnumOrientation.SOUTH, p.Orientation);
        }
        [TestMethod]
        public void RotateRight_SouthToWest()
        {
            IInstruction i = InstructionFactory.Create('R');
            Position p = new Position(0, 0, EnumOrientation.SOUTH);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(RotateRight));
            Assert.AreEqual(EnumOrientation.WEST, p.Orientation);
        }

        [TestMethod]
        public void RotateRight_WestToNorth()
        {
            IInstruction i = InstructionFactory.Create('R');
            Position p = new Position(0, 0, EnumOrientation.WEST);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(RotateRight));
            Assert.AreEqual(EnumOrientation.NORTH, p.Orientation);
        }

        [TestMethod]
        public void RotateLeft_NorthToWest()
        {
            IInstruction i = InstructionFactory.Create('L');
            Position p = new Position(0, 0, EnumOrientation.NORTH);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(RotateLeft));
            Assert.AreEqual(EnumOrientation.WEST, p.Orientation);
        }

        [TestMethod]
        public void RotateLeft_WestToSouth()
        {
            IInstruction i = InstructionFactory.Create('L');
            Position p = new Position(0, 0, EnumOrientation.WEST);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(RotateLeft));
            Assert.AreEqual(EnumOrientation.SOUTH, p.Orientation);
        }
        [TestMethod]
        public void RotateLeft_SouthToEast()
        {
            IInstruction i = InstructionFactory.Create('L');
            Position p = new Position(0, 0, EnumOrientation.SOUTH);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(RotateLeft));
            Assert.AreEqual(EnumOrientation.EAST, p.Orientation);
        }

        [TestMethod]
        public void RotateLeft_EastToNorth()
        {
            IInstruction i = InstructionFactory.Create('L');
            Position p = new Position(0, 0, EnumOrientation.EAST);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(RotateLeft));
            Assert.AreEqual(EnumOrientation.NORTH, p.Orientation);
        }

        [TestMethod]
        public void MoveForward()
        {
            IInstruction i = InstructionFactory.Create('F');
            Position p = new Position(0, 0, EnumOrientation.NORTH);
            Position target = new Position(0, 1, EnumOrientation.NORTH);
            i.Apply(p);

            Assert.IsInstanceOfType(i, typeof(MoveForward));
            Assert.AreEqual(target, p);
        }
    }
}
