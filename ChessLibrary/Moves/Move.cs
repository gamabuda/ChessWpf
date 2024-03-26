using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position From { get; }
        public abstract Position To { get; }
        public abstract void Execute(Board board);
    }
}
