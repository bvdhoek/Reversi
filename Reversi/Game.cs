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
        public Player[] players = new Player[2];
        MoveHandler moveHandler;
        public Player currentPlayer;

        public Game(int boardWidth, int boardHight)
        {
            initPlayers();
            board = new Board(this, boardWidth, boardHight);
            moveHandler = new MoveHandler(this, board);
        }

        private void initPlayers()
        {
            players[0] = new Player(Color.Black, 2);
            players[1] = new Player(Color.Red, 2);
            currentPlayer = players[0];
        }

        public void MakeMove(Point location)
        {
            if (moveHandler.MakeMove(location, currentPlayer))
                UpdatePlayer();
        }

        private bool GameOver()
        {
            return !moveHandler.AnyMoves(players[0]) && !moveHandler.AnyMoves(players[1]);
        }

        public void UpdatePlayer()
        {
            if (Array.IndexOf(players, currentPlayer) == 0)
                currentPlayer = players[1];
            else
                currentPlayer = players[0];
        }

        public Tile[,] getBoard()
        {
            return board.tiles;
        }
    }
}
