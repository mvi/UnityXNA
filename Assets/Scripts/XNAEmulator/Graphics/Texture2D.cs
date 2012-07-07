using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
	public class Texture2D : IDisposable
	{
        private UnityEngine.Texture2D unityTexture;

        public UnityEngine.Texture2D UnityTexture
        {
            get { return unityTexture; }
            set { unityTexture = value; }
        }

        public Texture2D()
        {

        }

        public Texture2D(UnityEngine.Texture2D unityTexture)
        {
            // TODO: Complete member initialization
            this.unityTexture = unityTexture;
        }

        public int Width
        {
            get { return unityTexture.width; }
        }
        public int Height
        {
            get { return unityTexture.height; }
        }

        public void Dispose()
        { }
	}
}
