using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    public class SpriteBatch
    {
        private GraphicsDevice graphicsDevice;

        public SpriteBatch(GraphicsDevice graphicsDevice)
        {
            // TODO: Complete member initialization
            this.graphicsDevice = graphicsDevice;
        }
        internal void Begin()
        {

        }

        internal void End()
        {

        }

        internal void Draw(Texture2D texture2D, Vector2 position, Nullable<Rectangle> source, Color color, float p, Vector2 Origin, float p_2, SpriteEffects spriteEffects, float p_3)
        {
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, position, source, color.ToVector4(), Origin, spriteEffects));
        }

        internal void Draw(Texture2D texture2D, Vector2 position, Color color)
        {
            graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, position, null, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
        }

        internal void DrawString(SpriteFont font, string value, Vector2 position, Color color)
        {
            graphicsDevice.DrawQueue.EnqueueString(new DrawStringCall(font, value, position, color.ToVector4()));
        }
    }
}
