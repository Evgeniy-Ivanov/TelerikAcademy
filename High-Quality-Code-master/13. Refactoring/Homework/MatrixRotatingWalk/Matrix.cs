namespace RotatingWalkInMatrix
{
    using System;
    using System.Text;

    public class Matrix
    {       
        public const int MaxSize = 100;

        private static Walk[] steps;

        private int[,] matrix;
        
        static Matrix()
        {
            int directionsCount = Walk.ValidlDirections;
            steps = new Walk[directionsCount];

            for (int i = 0; i < directionsCount; i++)
            {
                steps[i] = new Walk((Directions)i);
            }
        }
        
        public Matrix(int size)
        {
            if (size < 1 || size > MaxSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("The matrix size must be in the range between 1 and {0}.", MaxSize));
            }

            this.matrix = new int[size, size];
        }
    
        public void RotatingWalk()
        {
            this.Clear();

            int count = 1;
            Position position = new Position(0, 0);
            Walk walk = new Walk(Directions.SE);

            while (true)
            {
                this.matrix[position.Row, position.Column] = count;

                if (!this.CanWalkToPosition(position))
                {
                    bool positionAvailable = this.FindAvailablePosition(out position);
                    if (positionAvailable)
                    {
                        count++;
                        this.matrix[position.Row, position.Column] = count;
                        walk.Direction = Directions.SE;
                    }
                    else
                    {
                        break;
                    }
                }

                while (!this.CheckIfPositionIsValid(position.Row + walk.Vertical, position.Column + walk.Horizontal))
                {
                    walk.ChangeDirection();
                }

                position.UpdatePosition(walk);
                count++;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    stringBuilder.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                stringBuilder.Append("\r\n");
            }

            stringBuilder.Length -= 2;
            return stringBuilder.ToString();
        }

        public void Clear()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int column = 0; column < this.matrix.GetLength(1); column++)
                {
                    this.matrix[row, column] = 0;
                }
            }
        }

        public bool CheckIfPositionIsValid(int row, int column)
        {
            bool isValidRow = 0 <= row && row < this.matrix.GetLength(0);
            bool isValidColumn = 0 <= column && column < this.matrix.GetLength(1);
            bool isPositionValid = isValidRow && isValidColumn && this.matrix[row, column] == 0;

            return isPositionValid;
        }

        public bool CanWalkToPosition(Position position)
        {
            for (int i = 0; i < steps.Length; i++)
            {
                if (this.CheckIfPositionIsValid(position.Row + steps[i].Vertical, position.Column + steps[i].Horizontal))
                {
                    return true;
                }
            }

            return false;
        }

        public bool FindAvailablePosition(out Position position)
        {
            position = new Position(0, 0);

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int column = 0; column < this.matrix.GetLength(1); column++)
                {
                    if (this.matrix[row, column] == 0)
                    {
                        position.Row = row;
                        position.Column = column;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
