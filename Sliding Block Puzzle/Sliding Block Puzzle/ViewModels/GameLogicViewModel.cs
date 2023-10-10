using Sliding_Block_Puzzle.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Sliding_Block_Puzzle.ViewModels
{
    public class GameLogicViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        // Backing fields to Notify Property Changed
        private GameBoard _gameBoardInstance;
        public GameBoard GameBoardInstance
        {
            get => _gameBoardInstance;
            set
            {
                if (_gameBoardInstance != value) 
                {
                    _gameBoardInstance = value;
                    OnPropertyChanged(nameof(GameBoardInstance));
                }
            }
        }

        private PuzzlePiece _emptyPiece;
        public PuzzlePiece EmptyPiece
        {
            get => _emptyPiece;
            set
            {
                if (_emptyPiece != value)
                {
                    _emptyPiece = value;
                    OnPropertyChanged(nameof(EmptyPiece));
                }
            }
        }

        private PuzzlePiece _topMiddlePiece;
        public PuzzlePiece TopMiddlePiece
        {
            get => _topMiddlePiece;
            set
            {
                if (_topMiddlePiece != value)
                {
                    _topMiddlePiece = value;
                    OnPropertyChanged(nameof(TopMiddlePiece));
                }
            }
        }

        private PuzzlePiece _topRightPiece;
        public PuzzlePiece TopRightPiece
        {
            get => _topRightPiece;
            set
            {
                if (_topRightPiece != value)
                {
                    _topRightPiece = value;
                    OnPropertyChanged(nameof(TopRightPiece));
                }
            }
        }

        private PuzzlePiece _centreLeftPiece;
        public PuzzlePiece CentreLeftPiece
        {
            get => _centreLeftPiece;
            set
            {
                if (_centreLeftPiece != value)
                {
                    _centreLeftPiece = value;
                    OnPropertyChanged(nameof(CentreLeftPiece));
                }
            }
        }

        private PuzzlePiece _centreMiddlePiece;
        public PuzzlePiece CentreMiddlePiece
        {
            get => _centreMiddlePiece;
            set
            {
                if (_centreMiddlePiece != value)
                {
                    _centreMiddlePiece = value;
                    OnPropertyChanged(nameof(CentreMiddlePiece));
                }
            }
        }

        private PuzzlePiece _centreRightPiece;
        public PuzzlePiece CentreRightPiece
        {
            get => _centreRightPiece;
            set
            {
                if (_centreRightPiece != value)
                {
                    _centreRightPiece = value;
                    OnPropertyChanged(nameof(CentreRightPiece));
                }
            }
        }

        private PuzzlePiece _bottomLeftPiece;
        public PuzzlePiece BottomLeftPiece
        {
            get => _bottomLeftPiece;
            set
            {
                if (_bottomLeftPiece != value)
                {
                    _bottomLeftPiece = value;
                    OnPropertyChanged(nameof(BottomLeftPiece));
                }
            }
        }
        private PuzzlePiece _bottomMiddlePiece;
        public PuzzlePiece BottomMiddlePiece
        {
            get => _bottomMiddlePiece;
            set
            {
                if (_bottomMiddlePiece != value)
                {
                    _bottomMiddlePiece = value;
                    OnPropertyChanged(nameof(BottomMiddlePiece));
                }
            }
        }

        private PuzzlePiece _bottomRightPiece;
        public PuzzlePiece BottomRightPiece
        {
            get => _bottomRightPiece;
            set
            {
                if (_bottomRightPiece != value)
                {
                    _bottomRightPiece = value;
                    OnPropertyChanged(nameof(BottomRightPiece));
                }
            }
        }



        public ICommand SelectPuzzlePieceCommand { get; set; } // Command to select Puzzle Piece


        public GameLogicViewModel()
        {
            GameBoardInstance = new GameBoard(); // Initialise the Game Board
            SelectPuzzlePieceCommand = new Command<PuzzlePiece>(SelectPuzzlePiece);
            RandomiseBoard();
            RefreshPuzzlePieces(); // Update UI
        }

        public void SelectPuzzlePiece(PuzzlePiece selectedPuzzlePiece)
        {
            // Logging for debugging purposes
            Debug.WriteLine($"Image {selectedPuzzlePiece.ImageSource} has been selected.");

            int row = selectedPuzzlePiece.Row;
            int col = selectedPuzzlePiece.Column;



            if ( selectedPuzzlePiece.ImageSource != "empty.png") // If user selected any other image other than the empty one
            {
                try
                {
                    // Try to find an adjacent empty puzzle piece space
                    if (row > 0 && GameBoardInstance.Board[row - 1, col]?.ImageSource == "empty.png")  // Check above
                    {
                        SwapPuzzlePieces(selectedPuzzlePiece, row - 1, col);
                        return;
                    }
                    if (row < 2 && GameBoardInstance.Board[row + 1, col]?.ImageSource == "empty.png")  // Check below
                    {
                        SwapPuzzlePieces(selectedPuzzlePiece, row + 1, col);
                        return;
                    }
                    if (col > 0 && GameBoardInstance.Board[row, col - 1]?.ImageSource == "empty.png")  // Check left
                    {
                        SwapPuzzlePieces(selectedPuzzlePiece, row, col - 1);
                        return;
                    }
                    if (col < 2 && GameBoardInstance.Board[row, col + 1]?.ImageSource == "empty.png")  // Check right
                    {
                        SwapPuzzlePieces(selectedPuzzlePiece, row, col + 1);
                        return;
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}. Not a valid selection.");
                }
                catch (NullReferenceException ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}. Not a valid selection.");
                }
            }

            // Move not valid if here
            Debug.WriteLine("No available move for the selected piece.");
        }


        // Logic for swapping a puzzle piece after selecting it.
        public void SwapPuzzlePieces(PuzzlePiece piece, int targetRow, int targetCol)
        {
            // Store the target piece
            PuzzlePiece targetPiece = GameBoardInstance.Board[targetRow, targetCol];

            // Swap the pieces on the board
            GameBoardInstance.Board[targetRow, targetCol] = piece;
            GameBoardInstance.Board[piece.Row, piece.Column] = targetPiece;

            // Update the Row and Column of the selected puzzle piece
            piece.Row = targetRow;
            piece.Column = targetCol;

            // Update the Row and Column of the target piece (should be the old position of the selected piece)
            targetPiece.Row = piece.Row;
            targetPiece.Column = piece.Column;

            RefreshPuzzlePieces();

            if (CheckWinCondition())
            {
                Application.Current.MainPage.DisplayAlert("Congratulations!", "You Win!", "OK");
            }
        }

        // Randomises the board with only legal moves so the puzzle is solvable.  
        public void RandomiseBoard()
        {
            Random rand = new Random();
            int row = 0; // Start position of EmptyPiece
            int col = 0;

            // Loop through 20 legal moves before displaying the board
            for (int i = 0; i < 5; i++)
            {
                List<(int, int)> validMoves = new List<(int, int)>(); // List to store row, col of valid moves

                // Check Up, Down, Left, Right for valid moves
                if (row > 0) validMoves.Add((row - 1, col));
                if (row < 2) validMoves.Add((row + 1, col));
                if (col > 0) validMoves.Add((row, col - 1));
                if (col < 2) validMoves.Add((row, col + 1));

                // Randomly select a valid move
                var move = validMoves[rand.Next(validMoves.Count)];
                int newRow = move.Item1;
                int newCol = move.Item2;

                SwapPuzzlePieces(GameBoardInstance.Board[newRow, newCol], row, col);

                // Update empty position
                row = newRow;
                col = newCol;
            }
        }

        // Check if the player has all the pieces the correct position
        private bool CheckWinCondition()
        {
            if (GameBoardInstance.Board[0, 0]?.ImageSource != "empty.png") return false;
            if (GameBoardInstance.Board[0, 1]?.ImageSource != "top_middle.png") return false;
            if (GameBoardInstance.Board[0, 2]?.ImageSource != "top_right.png") return false;
            if (GameBoardInstance.Board[1, 0]?.ImageSource != "centre_left.png") return false;
            if (GameBoardInstance.Board[1, 1]?.ImageSource != "centre_middle.png") return false;
            if (GameBoardInstance.Board[1, 2]?.ImageSource != "centre_right.png") return false;
            if (GameBoardInstance.Board[2, 0]?.ImageSource != "bottom_left.png") return false;
            if (GameBoardInstance.Board[2, 1]?.ImageSource != "bottom_middle.png") return false;
            if (GameBoardInstance.Board[2, 2]?.ImageSource != "bottom_right.png") return false;

            return true;
        }


        // Refreshes the board
        private void RefreshPuzzlePieces()
        {
            EmptyPiece = GameBoardInstance.Board[0, 0];
            TopMiddlePiece = GameBoardInstance.Board[0, 1];
            TopRightPiece = GameBoardInstance.Board[0, 2];
            CentreLeftPiece = GameBoardInstance.Board[1, 0];
            CentreMiddlePiece = GameBoardInstance.Board[1, 1];
            CentreRightPiece = GameBoardInstance.Board[1, 2];
            BottomLeftPiece = GameBoardInstance.Board[2, 0];
            BottomMiddlePiece = GameBoardInstance.Board[2, 1];
            BottomRightPiece = GameBoardInstance.Board[2, 2];
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
