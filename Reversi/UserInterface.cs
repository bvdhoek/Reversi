using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Reversi
{
    partial class UserInterface : Form
    {
        private const int rowCount = 6, columnCount = 6;
        Game game;
        int boxWidth, boxHeight;
        bool help, gameOver;

        public UserInterface(Game game)
        {
            gameOver = false;
            help = false;
            this.game = game;
            InitializeComponent();
            setSizes();
            DrawInfo();
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
            DrawBoardBackground(e);
            DrawBoardLines(e);
            drawPieces(e);
        }

        private Point PixelToLocation(Point location)
        {
            return new Point(location.X / boxWidth, location.Y / boxHeight);
        }

        private void MakeMove(object sender, MouseEventArgs e)
        {
            if (game.MakeMove(PixelToLocation(e.Location)))
            {
                help = false;
                gameOver = game.GameOver();
                board.Invalidate();
                DrawInfo();
                ShowNotifications();
            }
        }

        private void ShowNotifications()
        {
            if (!gameOver && !game.ValidMoves(game.currentPlayer).Any())
            {
                MessageBox.Show(game.currentPlayer.name + " does not have any valid moves.");
            }
            if (gameOver)
                NotifyGameOver();
        }

        private void NotifyGameOver()
        {
            Player winner = game.Winner();
            string text = "";
            if (winner == null)
                text = "It's a tie!";
            else
                text = "The winner is " + winner.name;
            MessageBox.Show("Game Over\n" + text);
        }

        private void DrawInfo()
        {
            score1.Text = "Score " + game.players[0].name + " (" + game.players[0].ColorString + ") : " + game.players[0].score;
            score1.Invalidate();

            score2.Text = "Score " + game.players[1].name + " (" + game.players[1].ColorString + ") : " + game.players[1].score;
            score2.Invalidate();

            playerturn.Text = "Turn Player: " + (game.currentPlayer.name);
            playerturn.Invalidate();
        }

        private void DrawBoardBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(
                new SolidBrush(Color.FromArgb(3, 164, 16)),
                new Rectangle(new Point(0, 0),
                new Size(columnCount * boxWidth, rowCount * boxHeight))
            );
        }

        private void DrawBoardLines(PaintEventArgs e)
        {
            for (int row = 0; row <= rowCount; row++)
            {
                e.Graphics.DrawLine(
                    new Pen(
                        Color.Black),
                        new Point(0, row * boxHeight),
                        new Point(columnCount * boxWidth, row * boxHeight)
                    );
                for (int column = 0; column <= columnCount; column++)
                {
                    e.Graphics.DrawLine(
                    new Pen(
                        Color.Black),
                        new Point(column * boxWidth, 0),
                        new Point(column * boxWidth, rowCount * boxHeight)
                    );
                }
            }
        }

        private void drawPieces(PaintEventArgs e)
        {
            DrawNormalPieces(e);
            if (help)
                DrawHelpPieces(e);
        }

        private void DrawHelpPieces(PaintEventArgs e)
        {
            foreach (Point p in game.ValidMoves(game.currentPlayer))
            {
                DrawPiece(e, p.X, p.Y, 20, 20);
            }
        }

        private void DrawPiece(PaintEventArgs e, SolidBrush brush, int column, int row, Tile tile)
        {
            e.Graphics.FillEllipse(brush, new Rectangle(new Point(column * boxWidth, row * boxHeight), new Size(boxWidth, boxHeight)));
        }

        private void DrawPiece(PaintEventArgs e, int column, int row, int reducedWidth, int reducedHeight)
        {
            e.Graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(new Point(column * boxWidth + (int)(0.5 * reducedWidth), row * boxHeight + (int)(0.5 * reducedHeight)), new Size(boxWidth - reducedWidth, boxHeight - reducedHeight)));
        }

        private void DrawNormalPieces(PaintEventArgs e)
        {
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    Tile t = game.board.tiles[row, column];
                    if (t.owner != null)
                        DrawPiece(e, new SolidBrush((Color)t.PieceColor), row, column, t);
                }
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            help = !help;
            board.Invalidate();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            game.Reset();
            board.Invalidate();
        }

        private void resize(object sender, EventArgs e)
        {
            setSizes();
            board.Invalidate();
        }
    }
}
