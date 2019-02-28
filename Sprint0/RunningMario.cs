using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class RunningMario : Sprites
    {

        public RunningMario(Texture2D texture, int rows, int columns) : base(texture, rows, columns)
        { }

        public override void UpdateLocation()
        {
            int width = (int)this.CentralPoint.X * 2;
            int height = (int)this.CentralPoint.Y * 2;

            int newX = (int)this.CurrentLoc.X;
            newX++;
            if (newX > width)
            {
                newX = 0;
            }

            this.CurrentLoc = new Vector2(newX, CurrentLoc.Y);
        }

        public override void UpdateFrame()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

    }
}
