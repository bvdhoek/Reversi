using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                else
                    return null;
            }
        }

        public bool Occupied
        {
            get { return owner != null; }
        }
    }
}
