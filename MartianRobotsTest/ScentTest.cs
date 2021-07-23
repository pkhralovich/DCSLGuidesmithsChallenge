using MartianRobots.Planets;
using MartianRobots.Robots;
using MartianRobots.Robots.Scent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MartianRobots.Robots.Position;

namespace MartianRobotsTest.Robots.Scent {
    [TestClass]
    public class ScentTest {
        static Planet p;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            p = new Mars(5, 5);
        }

        [TestMethod]
        public void ScentFactory_ScentList()
        {
            IScent scent = ScentFactory.Create(false, p);
            Assert.IsInstanceOfType(scent, typeof(ScentList));
        }

        [TestMethod]
        public void ScentFactory_ScentMatrix()
        {
            IScent scent = ScentFactory.Create(true, p);
            Assert.IsInstanceOfType(scent, typeof(ScentMatrix));
        }

        [TestMethod]
        public void ScentMatrix_IsLost()
        {
            IScent scent = ScentFactory.Create(true, p);
            Position pos = new Position(0, 0, EnumOrientation.NORTH);
            scent.Add(pos);

            Assert.AreEqual(true, scent.IsLost(pos));
        }

        [TestMethod]
        public void ScentMatrix_Not_IsLost()
        {
            IScent scent = ScentFactory.Create(true, p);
            Position pos = new Position(0, 0, EnumOrientation.NORTH);

            Assert.AreEqual(false, scent.IsLost(pos));
        }

        [TestMethod]
        public void ScentMatrix_IsLost_Repeated()
        {
            IScent scent = ScentFactory.Create(true, p);
            Position pos = new Position(0, 0, EnumOrientation.NORTH);
            Position pos2 = new Position(0, 0, EnumOrientation.SOUTH);
            scent.Add(pos);
            scent.Add(pos2);

            Assert.AreEqual(true, scent.IsLost(pos));
            Assert.AreEqual(true, scent.IsLost(pos));
        }

        [TestMethod]
        public void ScentList_IsLost()
        {
            IScent scent = ScentFactory.Create(false, p);
            Position pos = new Position(0, 0, EnumOrientation.NORTH);
            scent.Add(pos);

            Assert.AreEqual(true, scent.IsLost(pos));
        }

        [TestMethod]
        public void ScentList_Not_IsLost()
        {
            IScent scent = ScentFactory.Create(false, p);
            Position pos = new Position(0, 0, EnumOrientation.NORTH);

            Assert.AreEqual(false, scent.IsLost(pos));
        }

        [TestMethod]
        public void ScentList_IsLost_Repeated()
        {
            IScent scent = ScentFactory.Create(false, p);
            Position pos = new Position(0, 0, EnumOrientation.NORTH);
            Position pos2 = new Position(0, 0, EnumOrientation.SOUTH);
            scent.Add(pos);
            scent.Add(pos2);

            Assert.AreEqual(true, scent.IsLost(pos));
            Assert.AreEqual(true, scent.IsLost(pos));
        }
    }
}
