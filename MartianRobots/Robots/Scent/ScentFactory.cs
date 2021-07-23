using MartianRobots.Planets;

namespace MartianRobots.Robots.Scent {
    public class ScentFactory {
        /// <summary>
        /// Creates a new instance of a subclass of IScent
        /// </summary>
        /// <param name="optimizeSpeed">Allows to choose the class to use</param>
        /// <param name="p">Allow to parametrize the class to use</param>
        /// <returns>An instance implementing IScent</returns>
        public static IScent Create(bool optimizeSpeed, Planet p)
        {
            if (optimizeSpeed) return new ScentMatrix(p.ColumnCount, p.RowCount);
            else return new ScentList();
        }
    }
}
