using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    abstract class Sprites : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 CurrentLoc { get; set; }
        public Vector2 CentralPoint { get; set; }
        protected int currentFrame;
        protected int totalFrames;

        public Sprites(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CentralPoint = new Vector2(400, 200);
            CurrentLoc = CentralPoint;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }
        public abstract void UpdateLocation();

        public abstract void UpdateFrame();

        public void Update()
        {
            UpdateLocation();
            UpdateFrame();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)CurrentLoc.X, (int)CurrentLoc.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
