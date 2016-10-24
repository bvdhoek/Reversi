using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Game
    {
        Board board;
        bool player;
        int boardWidth, boardHight;

        public Game(int boardWidth, int boardHight)
        {
            player = true;
            this.boardWidth = boardWidth;
            this.boardHight = boardHight;
            board = new Board(boardWidth, boardHight);
        }

        public void MakeMove(Point location)
        {
            if (board.MakeMove(location, player))
                updatePlayer();
        }

        private bool GameOver()
        {
            bool gameOver = false;
            for (int column = 0; column < boardWidth; column++)
            {
                for (int row = 0; row < boardHight; row++)
                {
                    if (board.ValidMove(new Point(column, row)))
                        gameOver = true;
                }
            }
            return gameOver;
        }

        private void updatePlayer()
        {
            player = !player;
        }

        public bool?[,] getBoard()
        {
            return board.toA();
        }
    }
}
