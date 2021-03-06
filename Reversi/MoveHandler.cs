﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class MoveHandler
    {
        private Game game;
        private Board board;
        private List<Point> enclosedPoints;
        private readonly int[] HorizontalDirections = { -1, 0, 1 };
        private readonly int[] VerticalDirections = { -1, 0, 1 };
        private int NoDirection = 0;

        public MoveHandler(Game game, Board board)
        {
            this.game = game;
            this.board = board;
        }

        public bool AnyMoves(Player player)
        {
            return ValidMoves(player).Any();
        }

        private List<Point> ValidMoves(Player player)
        {
            List<Point> validMoves = new List<Point>();
            for (int x = 0; x < board.width; x++)
            {
                for (int y = 0; y < board.height; y++)
                {
                    Point move = new Point(x, y);
                    if (ValidMove(move, player))
                        validMoves.Add(move);
                }
            }
            return validMoves;
        }

        public bool ValidMove(Point location, Player player)
        {
            return ScanMove(location, player).Any();
        }

        public bool MakeMove(Point location, Player player)
        {
            List<Point> enclosedTiles = ScanMove(location, player);
            if (enclosedTiles.Any()) {
                board.UpdateTiles(enclosedTiles);
                game.UpdateScores(enclosedTiles.Count);
                return true;
            }
            return false;
        }

        public List<Point> ScanMove(Point move, Player player)
        {
            enclosedPoints = new List<Point>();
            foreach (int horizontalDirection in HorizontalDirections)
            {
                foreach (int verticalDirection in VerticalDirections)
                {
                    if (horizontalDirection == NoDirection && verticalDirection == NoDirection)
                        continue;
                    List<Point> points = Scan(move, horizontalDirection, verticalDirection, player);
                    if (points != null)
                        enclosedPoints.AddRange(Scan(move, horizontalDirection, verticalDirection, player));
                }
            }
            if (enclosedPoints.Any())
                enclosedPoints.Add(new Point(move.X, move.Y));
            return enclosedPoints;
        }

        private List<Point> Scan(Point move, int xDirection, int yDirection, Player player)
        {
            List<Point> enclosedPoints = new List<Point>();
            if (!(OutOfBounds(move.X + xDirection, move.Y + yDirection)) 
                && board.tiles[move.X + xDirection, move.Y + yDirection].owner != null 
                && board.tiles[move.X + xDirection, move.Y + yDirection].owner != player
            )
            {
                enclosedPoints.Add(new Point(move.X + xDirection, move.Y + yDirection));
                int x = move.X + 2 * xDirection;
                int y = move.Y + 2 * yDirection;
                while (!OutOfBounds(x, y))
                {
                    if (board.tiles[x, y].owner == player)
                        return enclosedPoints;
                    enclosedPoints.Add(new Point(x, y));
                    x += xDirection;
                    y += yDirection;
                }
            }
            return null;
        }

        private bool OutOfBounds(int x, int y)
        {
            return (x < 0 || x >= board.width || y < 0 || y >= board.height);
        }
    }
}
