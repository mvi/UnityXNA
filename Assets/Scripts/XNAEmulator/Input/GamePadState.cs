using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Input
{
    public class GamePadState
    {
        public GamePadThumbSticks ThumbSticks
        {
            get 
            {
                // TODO
                return new GamePadThumbSticks();
            }
        }
        public GamePadButtons Buttons
        {
            get 
            {
                // TODO
                return new GamePadButtons();
            }
        }
        internal bool IsButtonDown(Buttons buttons)
        {
            // TODO:
            return false;
        }
    }
}
