using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        int Rows { get; set; }
        int Columns { get; set; }
        void UpdateLocation();

        void UpdateFrame();
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
