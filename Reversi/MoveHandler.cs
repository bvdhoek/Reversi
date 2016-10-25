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
        MoveValidator moveValidator;

        public MoveHandler(Game game, Board board)
        {
            this.game = game;
            this.board = board;
            moveValidator = new MoveValidator(game, board);
        }

        public bool AnyMoves(Player player)
        {
            for (int x = 0; x < board.width; x ++) {
                for (int y = 0; y < board.height; y++)
                {
                    if (moveValidator.MoveIsValid(new Point(x, y)))
                        return true;
                }
            }
            return false;
        }

        public bool MakeMove(Point location)
        {
            if (moveValidator.MoveIsValid(location))
            {
                board.MakeMove(location);
                return true;
            }
            return false;
        }
    }
}
