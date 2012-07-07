using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    public class GraphicsDevice
    {
        Viewport viewport = new Viewport();
        private DrawQueue drawQueue;

        public DrawQueue DrawQueue
        {
            get { return drawQueue; }
            set { drawQueue = value; }
        }

        public GraphicsDevice(DrawQueue drawQueue)
        {
            // TODO: Complete member initialization
            this.drawQueue = drawQueue;
			
			viewport = new Viewport(0,0,UnityEngine.Screen.width, UnityEngine.Screen.height);
        }

        public Viewport Viewport
        {
            get { return viewport; }
            set { viewport = value; }
        }


        internal void Clear(Color color)
        {
            
        }
    }
}
