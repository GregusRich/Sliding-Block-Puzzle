using Sliding_Block_Puzzle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sliding_Block_Puzzle.Models
{
    public class GameBoard
    {
        public PuzzlePiece[,] Board { get; set; }

        public GameBoard()
        {
            Board = new PuzzlePiece[3, 3];

            // Sets up the Board with Puzzle Pieces 
            Board[0, 0] = new PuzzlePiece { Row = 0, Column = 0, ImageSource = "empty.png" };
            Board[0, 1] = new PuzzlePiece { Row = 0, Column = 1, ImageSource = "top_middle.png" };
            Board[0, 2] = new PuzzlePiece { Row = 0, Column = 2, ImageSource = "top_right.png" };
            Board[1, 0] = new PuzzlePiece { Row = 1, Column = 0, ImageSource = "centre_left.png" };
            Board[1, 1] = new PuzzlePiece { Row = 1, Column = 1, ImageSource = "centre_middle.png" };
            Board[1, 2] = new PuzzlePiece { Row = 1, Column = 2, ImageSource = "centre_right.png" };
            Board[2, 0] = new PuzzlePiece { Row = 2, Column = 0, ImageSource = "bottom_left.png" };
            Board[2, 1] = new PuzzlePiece { Row = 2, Column = 1, ImageSource = "bottom_middle.png" };
            Board[2, 2] = new PuzzlePiece { Row = 2, Column = 2, ImageSource = "bottom_right.png" };
        }
    }
}
