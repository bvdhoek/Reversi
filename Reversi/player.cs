using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    class Player
    {
        public Color color;
        public int score;

        public Player(Color color, int score)
        {
            this.color = color;
            this.score = score;
        }
    }
}
