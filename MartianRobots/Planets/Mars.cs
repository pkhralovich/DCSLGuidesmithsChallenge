namespace MartianRobots.Planets {
    /// <summary>
    /// A subclass of Planet representing Mars
    /// </summary>
    public class Mars : Planet {
        public Mars(int rows, int columns) : base(rows, columns) { }

        public override string Name => "Mars";
    }
}
