using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class GamepadController : IController
    {
        private Dictionary<Buttons, ICommand> controllerMappings;
        private PlayerIndex index;

        public GamepadController(PlayerIndex playerIndex)
        {
            controllerMappings = new Dictionary<Buttons, ICommand>();
            index = playerIndex;
        }

        public void Register(object button, ICommand command)
        {
            controllerMappings.Add((Buttons) button, command);
        }

        public void Update()
        {
            foreach (Buttons button in controllerMappings.Keys)
            {
                if (GamePad.GetState(index).IsButtonDown(button))
                {
                    controllerMappings[button].Execute();
                }
            }

        }

    }
}
