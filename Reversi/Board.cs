using System;
using System.Collections.Generic;
using System.Drawing;

namespace Reversi
{
    class Board
    {
        private Game game;
        public Tile[,] tiles { get; }
        public int width { get; }
        public int height { get; }

        public Board(Game game, int boardWidth, int boardHight)
        {
            this.game = game;
            width = boardWidth;
            height = boardHight;
            tiles = new Tile[boardWidth, boardHight];
            initBoard();
        }

        /* everything will be empty except for the four tiles in the center of the board
         * null null null null
         * null black red null
         * null red black null
         * null null null null
        */
        private void initBoard()
        {
            for (int row = 0; row < width; row++)
            {
                for (int column = 0; column < height; column++)
                {
                    tiles[row, column] = new Tile(null);
                }
            }
            tiles[width / 2 - 1, height / 2 - 1].owner = game.players[0];
            tiles[width / 2, height / 2 - 1].owner = game.players[1];
            tiles[width / 2 - 1, height / 2].owner = game.players[1];
            tiles[width / 2, height / 2].owner = game.players[0];
        }

        public void UpdateTiles(List<Point> tiles)
        {
            foreach (Point p in tiles)
            {
                this.tiles[p.X, p.Y].owner = game.currentPlayer;
            } 
        }
    }
}
