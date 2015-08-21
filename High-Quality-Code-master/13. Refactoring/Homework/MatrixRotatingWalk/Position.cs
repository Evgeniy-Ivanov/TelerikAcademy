namespace RotatingWalkInMatrix
{
    public class Position
    {
        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public void UpdatePosition(Walk step)
        {
            this.Row += step.Vertical;
            this.Column += step.Horizontal;
        }
    }
}
