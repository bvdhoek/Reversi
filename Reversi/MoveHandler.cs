using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class MoveHandler
    {
        Game game;
        Board board;
        List<Point> enclosedPoints;

        public MoveHandler(Game game, Board board)
        {
            this.game = game;
            this.board = board;
        }

        public bool AnyMoves(Player player)
        {
            /*for (int x = 0; x < board.width; x ++) {
                for (int y = 0; y < board.height; y++)
                {
                    if (moveValidator.MoveIsValid(new Point(x, y)))
                        return true;
                }
            }*/
            return false;
        }

        public bool MakeMove(Point location)
        {
            List<Point> enclosedTiles = ScanMove(location);
            if (enclosedTiles.Any()) {
                board.UpdateTiles(enclosedTiles);
                return true;
            }
            return false;
        }

        public List<Point> ScanMove(Point move)
        {
            enclosedPoints = new List<Point>();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;
                    List<Point> points = Scan(move, x, y);
                    if (points != null)
                        enclosedPoints.AddRange(Scan(move, x, y));
                }
            }
            if (enclosedPoints.Any())
                enclosedPoints.Add(new Point(move.X, move.Y));
            return enclosedPoints;
        }

        private List<Point> Scan(Point move, int xDirection, int yDirection)
        {
            List<Point> enclosedPoints = new List<Point>();
            if (!(OutOfBounds(move.X + xDirection, move.Y + yDirection)) 
                && board.tiles[move.X + xDirection, move.Y + yDirection].owner != null 
                && board.tiles[move.X + xDirection, move.Y + yDirection].owner != game.currentPlayer
            )
            {
                enclosedPoints.Add(new Point(move.X + xDirection, move.Y + yDirection));
                int x = move.X + 2 * xDirection;
                int y = move.Y + 2 * yDirection;
                while (!OutOfBounds(x, y))
                {
                    if (board.tiles[x, y].owner == game.currentPlayer)
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
