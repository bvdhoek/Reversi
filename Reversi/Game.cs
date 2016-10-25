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
        Player[] players = new Player[2];
        MoveHandler moveHandler;
        public Player currentPlayer;

        public Game(int boardWidth, int boardHight)
        {
            initPlayers();
            Console.WriteLine("Current player: " + currentPlayer.color); 
            board = new Board(this, boardWidth, boardHight);
            moveHandler = new MoveHandler(this, board);
        }

        public Player[] Players
        {
            get { return players; }
        }

        public Player getPlayer(int playerNr)
        {
            return players[playerNr];
        }

        private void initPlayers()
        {
            players[0] = new Player(Color.Black);
            players[1] = new Player(Color.Red);
            currentPlayer = players[0];
        }

        public void MakeMove(Point location)
        {
            if (moveHandler.MakeMove(location))
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
            Console.WriteLine("Current player: " + currentPlayer.color);
        }

        public Tile[,] getBoard()
        {
            return board.tiles;
        }
    }
}
