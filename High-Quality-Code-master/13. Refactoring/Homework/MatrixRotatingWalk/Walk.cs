namespace RotatingWalkInMatrix
{
    using System;

    public class Walk
    {
        public Directions direction;

        static Walk()
        {
            ValidlDirections = Enum.GetValues(typeof(Directions)).Length;
        }

        public Walk(Directions direction)
        {
            this.Direction = direction;
        }

        public static int ValidlDirections { get; private set; }

        public Directions Direction
        {
            get
            {
                return this.direction;
            }

            set
            {
                this.direction = value;

                switch (value)
                {
                    case Directions.SE:
                        {
                            this.Vertical = 1;
                            this.Horizontal = 1;
                            break;
                        }

                    case Directions.S:
                        {
                            this.Vertical = 1;
                            this.Horizontal = 0;
                            break;
                        }

                    case Directions.SW:
                        {
                            this.Vertical = 1;
                            this.Horizontal = -1;
                            break;
                        }

                    case Directions.W:
                        {
                            this.Vertical = 0;
                            this.Horizontal = -1;
                            break;
                        }

                    case Directions.NW:
                        {
                            this.Vertical = -1;
                            this.Horizontal = -1;
                            break;
                        }

                    case Directions.N:
                        {
                            this.Vertical = -1;
                            this.Horizontal = 0;
                            break;
                        }

                    case Directions.NE:
                        {
                            this.Vertical = -1;
                            this.Horizontal = 1;
                            break;
                        }

                    default:
                        {
                            this.Vertical = 0;
                            this.Horizontal = 1;
                            break;
                        }
                }
            }
        }

        public int Vertical { get; private set; }

        public int Horizontal { get; private set; }

        public void ChangeDirection()
        {
            if ((int)this.Direction == ValidlDirections - 1)
            {
                this.Direction = 0;
            }
            else
            {
                this.Direction++;
            }
        }
    }
}
