using System;
using System.Collections.Generic;
namespace ChessLOGIC
{
    public class Bishop : Piece //inherit
    {
        public override TypePiece Type => TypePiece.Bishop;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[] // moves for BISHOPS
        {
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthWest,
            Direction.SouthEast
        };

        //constructor 
        public Bishop(Player color)
        {

            Color = color;
        }
        //copy method
        public override Piece Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePosInDirection(from, board, dirs).Select(to => new Normal(from, to));
        }
    }
}
