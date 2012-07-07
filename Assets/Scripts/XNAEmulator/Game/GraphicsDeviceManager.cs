using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
    class GraphicsDeviceManager
    {
        private Game game;

        public GraphicsDevice GraphicsDevice
        {
            get
            {
                return game.GraphicsDevice;
            }
        }

        public GraphicsDeviceManager(Game game)
        {
            // TODO: Complete member initialization
            this.game = game;
        }
    }
}
