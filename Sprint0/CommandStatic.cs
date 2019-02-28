using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class CommandStatic : ICommand
    {
        private Game1 myGame;

        public CommandStatic(Game1 game)
        {
            this.myGame = game;
        }

        public void Execute()
        {
            this.myGame.Mario = new StaticMario(
                this.myGame.Mario.Texture,
                this.myGame.Mario.Rows,
                this.myGame.Mario.Columns);
        }
    }
}
