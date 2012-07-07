using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    public class SpriteFont : IDisposable
    {
        #region Fields
        private string fontName;
        private float size;
		private float spacing;
        private bool useKerning;
        private string style;
        #endregion

        #region Properties
        public string FontName
        {
            get
            {
                return this.fontName;
            }
        }

        public float Size
        {
            get
            {
                return this.size;
            }
        }
		
        public float Spacing
        {
            get
            {
                return this.spacing;
            }
        }

        public string Style
        {
            get
            {
                return this.style;
            }
        }

        public bool UseKerning
        {
            get
            {
                return this.useKerning;
            }
        } 
        #endregion

        public SpriteFont(string fontName, float size, float spacing, bool useKerning, string style)
        {
            this.fontName = fontName;
            this.size = size;
			this.spacing = spacing;
            this.useKerning = useKerning;
            this.style = style;
        }
        internal Vector2 MeasureString(string text)
        {			
			
			UnityEngine.GUISkin skin = UnityEngine.GUISkin.CreateInstance<UnityEngine.GUISkin>();
			
			UnityEngine.Vector2 size = skin.label.CalcSize(new UnityEngine.GUIContent(text));
			return new Vector2(size.x, size.y);
        }
        public void Dispose()
        { }
    }
}
