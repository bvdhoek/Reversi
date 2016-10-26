namespace Reversi
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userControlPanel = new System.Windows.Forms.Panel();
            this.board = new System.Windows.Forms.Panel();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.userControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // userControlPanel
            // 
            this.userControlPanel.AutoSize = true;
            this.userControlPanel.Controls.Add(this.NewGameButton);
            this.userControlPanel.Location = new System.Drawing.Point(0, 0);
            this.userControlPanel.Name = "userControlPanel";
            this.userControlPanel.Size = new System.Drawing.Size(440, 97);
            this.userControlPanel.TabIndex = 0;
            // 
            // board
            // 
            this.board.AutoSize = true;
            this.board.BackColor = System.Drawing.Color.Transparent;
            this.board.Location = new System.Drawing.Point(0, 100);
            this.board.Margin = new System.Windows.Forms.Padding(0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(100, 100);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.drawBoard);
            this.board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MakeMove);
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(73, 26);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(105, 39);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 440);
            this.Controls.Add(this.board);
            this.Controls.Add(this.userControlPanel);
            this.Name = "UserInterface";
            this.Text = "Reversi";
            this.ResizeEnd += new System.EventHandler(this.resize);
            this.userControlPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel userControlPanel;
        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.Button NewGameButton;
    }
}

