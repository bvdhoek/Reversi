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

        public Player(Color color)
        {
            this.color = color;
            score = 0;
        }
    }
}
