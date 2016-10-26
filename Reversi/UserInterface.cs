using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    partial class UserInterface : Form
    {
        private const int rowCount = 6, columnCount = 6;
        Game game;
        int boxWidth, boxHeight;

        public UserInterface(Game game)
        {
            this.game = game;
            InitializeComponent();
            setSizes();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {

        }

        private void HelpButton_Click(object sender, EventArgs e)
        {

        }

        private void resize(object sender, EventArgs e)
        {
            setSizes();
            board.Invalidate();
        }

        private void setSizes()
        {
            int borderWidth = (Width - ClientSize.Width) / 2;
            int titleBarHeight = Height - ClientSize.Height - 2 * borderWidth;
            userControlPanel.Width = Width - 2 * borderWidth;
            board.Width = Width - 2 * borderWidth;
            board.Height = Height - userControlPanel.Height - titleBarHeight - borderWidth;
            boxHeight = board.Height / rowCount;
            boxWidth = board.Width / columnCount;
        }

        private void drawBoard(object sender, PaintEventArgs e)
        {
            int columnWidth = board.Width / columnCount;
            int rowHeight = board.Height / rowCount;
            for (int row = 0; row <= rowCount; row++)
            {
                e.Graphics.DrawLine(
                    new Pen(
                        Color.Black),
                        new Point(0, row * rowHeight),
                        new Point(board.Width, row * rowHeight)
                    );
                for (int column = 0; column <= columnCount; column++)
                {
                    e.Graphics.DrawLine(
                    new Pen(
                        Color.Black),
                        new Point(column * columnWidth, 0),
                        new Point(column * columnWidth, board.Height)
                    );
                }
            }
            drawPieces(e);
        }

        private void drawPieces(PaintEventArgs e)
        {
            Tile[,] board = game.getBoard();
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    DrawPiece(e, row, column, board[row, column]);
                }
            }
            Console.WriteLine("current player: " + game.currentPlayer.color);
        }

        private void MakeMove(object sender, MouseEventArgs e)
        {
            if (game.MakeMove(PixelToLocation(e.Location)))
                board.Invalidate();
        }

        private void DrawPiece(PaintEventArgs e, int column, int row, Tile tile)
        {
            if (tile.owner != null)
            {
                e.Graphics.FillEllipse(new SolidBrush(tile.owner.color), new Rectangle(new Point(column * boxWidth, row * boxHeight), new Size(boxWidth, boxHeight)));
            }
        }

        private Point PixelToLocation(Point location)
        {
            return new Point(location.X / boxWidth, location.Y / boxHeight);
        }
    }
}
