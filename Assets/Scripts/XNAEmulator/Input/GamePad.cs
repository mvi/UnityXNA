using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Input
{
    public static class GamePad
    {
        internal static GamePadState GetState(PlayerIndex playerIndex)
        {
            // TODO: Improve
            return new GamePadState();            
        }
    }
}