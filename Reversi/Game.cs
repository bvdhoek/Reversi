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
            players[0] = new Player(Color.Black, 2, "Player 1");
            players[1] = new Player(Color.Red, 2, "Player 2");
            currentPlayer = players[0];
        }

        public void Reset()
        {
            Board newBoard = new Board(this, board.width, board.height);
            MoveHandler newMoveHandler = new MoveHandler(this, newBoard);
            board = newBoard;
            moveHandler = newMoveHandler;
            players[0].score = 2;
            players[1].score = 2;
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

        public bool GameOver()
        {
            return !moveHandler.AnyMoves(players[0]) && !moveHandler.AnyMoves(players[1]);
        }

        public Player Winner()
        {
            if (players[0].score > players[1].score)
                return players[0];
            else if (players[1].score > players[0].score)
                return players[1];
            return null;
        }

        public void UpdateScores(int tilesChanged)
        {
            currentPlayer.score += tilesChanged;
            OtherPlayer().score -= (tilesChanged - 1);
        }

        public void UpdatePlayer()
        {
            currentPlayer = OtherPlayer();
        }
        
        public Player OtherPlayer()
        {
            if (players[0] == currentPlayer)
                return players[1];
            return players[0];
        }
    }
}
