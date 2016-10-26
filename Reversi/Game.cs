using System;
using System.Collections.Generic;
using System.Drawing;

namespace Reversi
{
    class Game
    {
        public Board board;
        public Player[] players = new Player[2];
        private MoveHandler moveHandler;
        public Player currentPlayer;

        public Game(int boardWidth, int boardHight)
        {
            initPlayers();
            board = new Board(this, boardWidth, boardHight);
            moveHandler = new MoveHandler(this, board);
        }

        public List<Point> ValidMoves(Player player)
        {
            return moveHandler.ValidMoves(player);
        }

        private void initPlayers()
        {
            players[0] = new Player(Color.Black, 2);
            players[1] = new Player(Color.Red, 2);
            currentPlayer = players[0];
        }

        public bool MakeMove(Point location)
        {
            if (moveHandler.MakeMove(location, currentPlayer))
            {
                UpdatePlayer();
                return true;
            }
            return false;
        }

        private bool GameOver()
        {
            return !moveHandler.AnyMoves(players[0]) && !moveHandler.AnyMoves(players[1]);
        }

        public void UpdateScores(int tilesChanged)
        {
            currentPlayer.score += tilesChanged;
            players[OtherPlayer()].score -= (tilesChanged - 1);
        }

        public void UpdatePlayer()
        {
            currentPlayer = players[OtherPlayer()];
        }
        
        private int OtherPlayer()
        {
            if (players[0] == currentPlayer)
                return 1;
            return 0;
        }
    }
}
