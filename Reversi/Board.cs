using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Board
    {
        bool?[,] playingBoard;

        /* everything will be empty except for the four tiles in the center of the board
         * null null null null
         * null   F   T   null
         * null   T   F   null
         * null null null null
        */
        public Board(int boardWidth, int boardHight)
        {
            playingBoard = new bool?[boardWidth, boardHight];
            for (int row = 0; row < boardWidth; row++)
            {
                for (int column = 0; column < boardHight; column++)
                {
                    playingBoard[row, column] = null;
                }
            }
            Console.WriteLine(boardHight / 2 + ", " + boardHight / 2);
            playingBoard[boardWidth / 2 - 1, boardHight / 2 - 1] = false;
            playingBoard[boardWidth / 2, boardHight / 2 - 1] = true;
            playingBoard[boardWidth / 2 - 1, boardHight / 2] = true;
            playingBoard[boardWidth / 2, boardHight / 2] = false;
        }

        public bool MakeMove(Point location, bool player)
        {
            if (ValidMove(location))
            {
                playingBoard[location.X, location.Y] = player;
                return true;
            }
            return false;
        }

        public bool ValidMove(Point location)
        {
            if (playingBoard[location.X, location.Y] != null)
                return false;
            return scanHorizontal(location.X, location.Y) || scanVertical(location.X, location.Y) || scanDiagonal(location.X, location.Y);
        }

        private bool scanHorizontal(int column, int row)
        {
            return true;
        }

        private bool scanVertical(int column, int row)
        {
            return true;
        }

        private bool scanDiagonal(int column, int row)
        {
            return true;
        }

        public bool?[,] toA()
        {
            return playingBoard;
        }
    }
}
