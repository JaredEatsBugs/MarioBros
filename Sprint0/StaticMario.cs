using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class StaticMario : Sprites
    {

        public StaticMario(Texture2D texture, int rows, int columns) : base(texture, rows, columns)
        { }

        public override void UpdateLocation()
        { }

        public override void UpdateFrame()
        { }

    }

}
