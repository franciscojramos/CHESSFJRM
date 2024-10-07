using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLOGIC;



namespace ChessINTERFACE
{
    public static class Images
    {
        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Relative));// It says is a relative path for the image
        }
        private static readonly Dictionary<TypePiece, ImageSource> blackSources = new()
        {
            //Black one
            //pawn
            {TypePiece.Pawn, LoadImage("ASSETS/PawnB.png") },
            //rook
            {TypePiece.Rook, LoadImage("ASSETS/RookB.png") },
            //Knight
            {TypePiece.Knight, LoadImage("ASSETS/KnightB.png") },
            //Bishop
            {TypePiece.Bishop, LoadImage("ASSETS/BishopB.png") },
            //queen
            {TypePiece.Queen, LoadImage("ASSETS/QueenB.png") },
            //King
            {TypePiece.King, LoadImage("ASSETS/KingB.png") }
        };
        private static readonly Dictionary<TypePiece, ImageSource> whiteSources = new()
        {
            //Whites one
            //pawn
            {TypePiece.Pawn, LoadImage("ASSETS/PawnW.png") },
            //rook
            {TypePiece.Rook, LoadImage("ASSETS/RookW.png") },
            //Knight
            {TypePiece.Knight, LoadImage("ASSETS/KnightW.png") },
            //Bishop
            {TypePiece.Bishop, LoadImage("ASSETS/BishopW.png") },
            //queen
            {TypePiece.Queen, LoadImage("ASSETS/QueenW.png") },
            //King
            {TypePiece.King, LoadImage("ASSETS/KingW.png") }
        };

        public static ImageSource GetImage(Piece piece)
        {
           if (piece == null)
            {
                return null;
            }
            return GetImage(piece.Color, piece.Type);
        }

        private static ImageSource GetImage(Player color , TypePiece type)
        {
            return color switch
            {
                Player.White => whiteSources[type],
                Player.Black => blackSources[type],
                _ => null // in other case 
            };

        }

        
    }
}
