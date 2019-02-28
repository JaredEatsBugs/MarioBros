using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class DeadMario : Sprites
    {
        public DeadMario(Texture2D texture, int rows, int columns) : base(texture, rows, columns)
        { }

        public override void UpdateLocation()
        {
            int height = (int)this.CentralPoint.Y * 2;

            int newY = (int)this.CurrentLoc.Y;
            newY++;
            if (newY > height)
            {
                newY = 0;
            }
            this.CurrentLoc = new Vector2(CurrentLoc.X, newY);
        }

        public override void UpdateFrame()
        { }

    }
}
