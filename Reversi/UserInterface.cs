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
        bool help;

        public UserInterface(Game game)
        {
            help = false;
            this.game = game;
            InitializeComponent();
            setSizes();
            DrawInfo();
        }

        private void resize(object sender, EventArgs e)
        {
            setSizes();
            board.Invalidate();
        }

        private void setSizes()
        {
            int borderWidth = (Width - ClientSize.Width) / 2;
            int titleBarHeight = Height - ClientSize.Height - borderWidth;
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
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), new Rectangle(new Point(0, 0), new Size(columnCount * columnWidth, rowCount * rowHeight)));
            for (int row = 0; row <= rowCount; row++)
            {
                e.Graphics.DrawLine(
                    new Pen(
                        Color.Black),
                        new Point(0, row * rowHeight),
                        new Point(columnCount*columnWidth, row * rowHeight)
                    );
                for (int column = 0; column <= columnCount; column++)
                {
                    e.Graphics.DrawLine(
                    new Pen(
                        Color.Black),
                        new Point(column * columnWidth, 0),
                        new Point(column * columnWidth, rowCount*rowHeight)
                    );
                }
            }
            drawPieces(e);
        }

        private void drawPieces(PaintEventArgs e)
        {
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    Tile t = game.board.tiles[row, column];
                    if (t.owner != null)
                        DrawPiece(e, new SolidBrush((Color) t.PieceColor) , row, column, t);
                }
            }
            if (help)
            {
                foreach (Point p in game.ValidMoves(game.currentPlayer))
                {
                    DrawPiece(e, p.X, p.Y, 20, 20);
                }
            }
        }

        private void MakeMove(object sender, MouseEventArgs e)
        {
            if (game.MakeMove(PixelToLocation(e.Location)))
            {
                board.Invalidate();
                help = false;
                DrawInfo();
            }
        }

        private void DrawInfo()
        {
            score1.Text = "Score player 1 (" + game.players[0].color + ") : " + game.players[0].score;
            score1.Invalidate();

            score2.Text = "Score player 2 (" + game.players[1].color + ") : " + game.players[1].score;
            score2.Invalidate();

            playerturn.Text = "Turn Player: " + (Array.IndexOf(game.players, game.currentPlayer) + 1);
            playerturn.Invalidate();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            game.NewGame();
            board.Invalidate();
        }

        private void DrawPiece(PaintEventArgs e, SolidBrush brush, int column, int row, Tile tile)
        {
            e.Graphics.FillEllipse(brush, new Rectangle(new Point(column * boxWidth, row * boxHeight), new Size(boxWidth, boxHeight)));
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            help = !help;
            board.Invalidate();
        }

        private void DrawPiece(PaintEventArgs e, int column, int row, int reducedWidth, int reducedHeight)
        {
            e.Graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(new Point(column * boxWidth + (int) (0.5 * reducedWidth), row * boxHeight + (int) (0.5 * reducedHeight)), new Size(boxWidth - reducedWidth, boxHeight - reducedHeight)));
        }

        private Point PixelToLocation(Point location)
        {
            return new Point(location.X / boxWidth, location.Y / boxHeight);
        }
    }
}
