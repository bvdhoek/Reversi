using System.Drawing;

namespace Reversi
{
    class Player
    {
        public Color color;
        public int score;
        public string name;

        public string ColorString
        {
            get
            {
                if (color == Color.Black)
                    return "Black";
                else
                    return "Red";
            }
        }

        public Player(Color color, int score, string name)
        {
            this.color = color;
            this.score = score;
            this.name = name;
        }
    }
}
