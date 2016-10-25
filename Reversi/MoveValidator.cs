using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class MoveValidator
    {
        Game game;
        Board board;
        Point move;

        public MoveValidator(Game game, Board board)
        {
            this.game = game;
            this.board = board;
        }

        public bool MoveIsValid(Point move)
        {
            this.move = move;
            return !(TileOccupied() || OwnedByCurrentPlayer()) && (ScanHorizontal() || ScanVertical() || ScanDiagonal());
        }

        private bool OwnedByCurrentPlayer()
        {
            return board.tiles[move.X, move.Y].OwnedBy(game.currentPlayer);
        }

        private bool ScanHorizontal()
        {
            return ScanLeft() || ScanRight();
        }

        private bool ScanVertical()
        {
            return ScanTop() || ScanBottom();
        }

        private bool ScanDiagonal()
        {
            return ScanDiagonalBottomLeft() || ScanDiagonalBottomRight() || ScanDiagonalTopRight() || ScanDiagonalTopLeft();
        }

        private bool ScanDiagonalTopLeft()
        {
            if (move.X >= 2 && move.Y >= 2 && OccupiedByOtherPlayer(move.X - 1, move.Y - 1))
            {
                for (int x = move.X - 2; x >= 0; x--)
                {
                    if (OccupiedByCurrentPlayer(x, x - move.X + move.Y))
                        return true;
                }
            }
            return false;
        }

        private bool ScanDiagonalTopRight()
        {
            if (move.X <= board.width - 2 && move.Y >= 2 && OccupiedByOtherPlayer(move.X + 1, move.Y - 1))
            {
                for (int x = move.X + 2; x < board.width; x++)
                {
                    if (OccupiedByCurrentPlayer(x, move.Y - x + move.X))
                        return true;
                }
            }
            return false;
        }

        private bool ScanDiagonalBottomLeft()
        {
            if (move.X >= 2 && move.Y < board.height - 2 && OccupiedByOtherPlayer(move.X - 1, move.Y + 1))
            {
                for (int x = move.X - 2; x >= 0; x--)
                {
                    if (OccupiedByCurrentPlayer(x, move.X - x + move.Y))
                        return true;
                }
            }
            return false;
        }

        private bool ScanDiagonalBottomRight()
        {
            if (move.X < board.width - 2 && move.Y < board.height - 2 && OccupiedByOtherPlayer(move.X + 1, move.Y + 1))
            {
                for (int x = move.X + 2; x < board.width; x++)
                {
                    if (OccupiedByCurrentPlayer(x, x - move.X + move.Y))
                        return true;
                }
            }
            return false;
        }

        private bool ScanLeft()
        {
            if (move.X >= 2 && OccupiedByOtherPlayer(move.X - 1, move.Y))
            {
                for (int x = move.X - 2; x >= 0; x--)
                {
                    if (OccupiedByCurrentPlayer(x, move.Y))
                        return true;
                }
            }
            return false;
        }

        private bool ScanRight()
        {
            if (move.X < board.width - 2 && OccupiedByOtherPlayer(move.X + 1, move.Y))
            {
                for (int x = move.X + 2; x < board.width; x++)
                {
                    if (OccupiedByCurrentPlayer(x, move.Y))
                        return true;
                }
            }
            return false;
        }

        private bool ScanTop()
        {
            if (move.Y >= 2 && OccupiedByOtherPlayer(move.X, move.Y - 1))
            {
                for (int y = move.Y - 2; y >= 0; y--)
                {
                    if (OccupiedByCurrentPlayer(move.X, y))
                        return true;
                }
            }
            return false;
        }

        private bool ScanBottom()
        {
            if (move.Y < board.width - 2 && OccupiedByOtherPlayer(move.X, move.Y + 1))
            {
                for (int y = move.Y + 2; y < board.height; y++)
                {
                    if (OccupiedByCurrentPlayer(move.X, y))
                        return true;
                }
            }
            return false;
        }

        private bool OccupiedByOtherPlayer(int x, int y)
        {
            if (x < 0 || x >= board.width || y < 0 || y >= board.height)
                return false;
            return board.tiles[x, y].owner != null && board.tiles[x, y].owner != game.currentPlayer;
        }

        private bool OccupiedByCurrentPlayer(int x, int y)
        {
            if (x < 0 || x >= board.width || y < 0 || y >= board.height)
                return false;
            return board.tiles[x, y].owner != null && board.tiles[x, y].owner == game.currentPlayer;
        }

        private bool TileOccupied()
        {
            return board.tiles[move.X, move.Y].Occupied;
        }
    }
}
