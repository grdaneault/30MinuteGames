using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird_2016_05_23
{
    class Obscatcle
    {
        public int Height { get; private set; }
        public int LeftPadding { get; private set; }

        public Direction Direction { get; private set; }

        public Obscatcle(int height, int leftPad, Direction direction)
        {
            Height = height;
            LeftPadding = leftPad;
            Direction = direction;
        }

        public bool Here(int row, int col)
        {
            return col == LeftPadding &&
                   ((row > Height && Direction == Direction.Up) || (row < Height && Direction == Direction.Down));
        }

        public bool Update()
        {
            LeftPadding -= 1;
            return LeftPadding < 0;
        }
    }

    public enum Direction
    {
        Up, Down
    }
}
