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
            this.playerturn = new System.Windows.Forms.Label();
            this.score2 = new System.Windows.Forms.Label();
            this.score1 = new System.Windows.Forms.Label();
            this.HelpButton = new System.Windows.Forms.Button();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.board = new System.Windows.Forms.Panel();
            this.userControlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // userControlPanel
            // 
            this.userControlPanel.AutoSize = true;
            this.userControlPanel.Controls.Add(this.playerturn);
            this.userControlPanel.Controls.Add(this.score2);
            this.userControlPanel.Controls.Add(this.score1);
            this.userControlPanel.Controls.Add(this.HelpButton);
            this.userControlPanel.Controls.Add(this.NewGameButton);
            this.userControlPanel.Location = new System.Drawing.Point(0, 0);
            this.userControlPanel.Name = "userControlPanel";
            this.userControlPanel.Size = new System.Drawing.Size(667, 163);
            this.userControlPanel.TabIndex = 0;
            // 
            // playerturn
            // 
            this.playerturn.AutoSize = true;
            this.playerturn.Location = new System.Drawing.Point(70, 135);
            this.playerturn.Name = "playerturn";
            this.playerturn.Size = new System.Drawing.Size(46, 17);
            this.playerturn.TabIndex = 4;
            this.playerturn.Text = "label1";
            // 
            // score2
            // 
            this.score2.AutoSize = true;
            this.score2.Location = new System.Drawing.Point(70, 107);
            this.score2.Name = "score2";
            this.score2.Size = new System.Drawing.Size(46, 17);
            this.score2.TabIndex = 3;
            this.score2.Text = "label2";
            // 
            // score1
            // 
            this.score1.AutoSize = true;
            this.score1.Location = new System.Drawing.Point(70, 79);
            this.score1.Name = "score1";
            this.score1.Size = new System.Drawing.Size(38, 17);
            this.score1.TabIndex = 2;
            this.score1.Text = "label";
            // 
            // HelpButton
            // 
            this.HelpButton.Location = new System.Drawing.Point(236, 26);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(102, 39);
            this.HelpButton.TabIndex = 1;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(92, 26);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(105, 39);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // board
            // 
            this.board.AutoSize = true;
            this.board.BackColor = System.Drawing.Color.Transparent;
            this.board.Location = new System.Drawing.Point(0, 166);
            this.board.Margin = new System.Windows.Forms.Padding(0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(100, 100);
            this.board.TabIndex = 0;
            this.board.Paint += new System.Windows.Forms.PaintEventHandler(this.drawBoard);
            this.board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MakeMove);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 597);
            this.Controls.Add(this.board);
            this.Controls.Add(this.userControlPanel);
            this.Name = "UserInterface";
            this.Text = "Reversi";
            this.ResizeEnd += new System.EventHandler(this.resize);
            this.userControlPanel.ResumeLayout(false);
            this.userControlPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel userControlPanel;
        private System.Windows.Forms.Panel board;
        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.Label score2;
        private System.Windows.Forms.Label score1;
        private System.Windows.Forms.Label playerturn;
    }
}

