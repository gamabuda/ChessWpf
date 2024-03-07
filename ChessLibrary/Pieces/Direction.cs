using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Pieces
{
    public class Direction
    {
        public int XDirection {  get; set; }
        public int YDirection { get; set; }
        public Tuple<int, int> DirectionVector { get; set; }

        public Direction(int xDirection, int yDirection)
        {
            XDirection = xDirection;
            YDirection = yDirection;
            DirectionVector = new Tuple<int, int>(xDirection, yDirection);
        }

        
    }
}
