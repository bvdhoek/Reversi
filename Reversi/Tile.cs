using System.Drawing;

namespace Reversi
{
    class Tile
    {
        public Player owner;

        public Tile(Player player)
        {
            owner = player;
        }

        public bool OwnedBy(Player player)
        {
            return owner == player;
        }

        public Color? PieceColor
        {
            get
            {
                if (Occupied)
                    return owner.color;
                return null;
            }
        }

        public bool Occupied
        {
            get { return owner != null; }
        }
    }
}
