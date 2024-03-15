using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLib
{
    public class Pawn
    {
        public int position;
        public bool isWhite;

        public Pawn(int position, bool isWhite)
        {
            this.position = position;
            this.isWhite = isWhite;
        }

        public bool CanMove(int newPosition)
        {
            if (newPosition < 1 || newPosition > 8)
                return false;

            if (isWhite)
            {
                if (position == newPosition)
                    return false;

                if (position == 2 && newPosition == 4)
                    return true;

                if (position == 2 && newPosition == 3)
                    return true;

                if (position == 3 && newPosition == 4)
                    return true;

                if (position > 2 && newPosition == position + 1)
                    return true;

                if (position == 7 && newPosition == 8)
                    return true;

                return false;
            }
            else
            {
                if (position == newPosition)
                    return false;

                if (position == 7 && newPosition == 5)
                    return true;

                if (position == 7 && newPosition == 6)
                    return true;

                if (position == 6 && newPosition == 5)
                    return true;

                if (position < 7 && newPosition == position - 1)
                    return true;

                if (position == 2 && newPosition == 1)
                    return true;

                return false;

            }
        }
    }
}