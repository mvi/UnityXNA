using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Graphics
{
    public class SpriteBatch : GraphicsResource
    {
        private GraphicsDevice graphicsDevice;
		
		Vector2 texCoordTL = new Vector2 (0,0);
		Vector2 texCoordBR = new Vector2 (0,0);
		Rectangle tempRect = new Rectangle (0,0,0,0);

        public SpriteBatch(GraphicsDevice graphicsDevice)
        {
			if (graphicsDevice == null) {
				throw new ArgumentException ("graphicsDevice");
			}

            // TODO: Complete member initialization
            this.graphicsDevice = graphicsDevice;
        }
        
		public void Begin ()
		{
            Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.Identity);	
		}

		public void Begin (SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect, Matrix transformMatrix)
		{
/*
			// defaults
			_sortMode = sortMode;
			_blendState = blendState ?? BlendState.AlphaBlend;
			_samplerState = samplerState ?? SamplerState.LinearClamp;
			_depthStencilState = depthStencilState ?? DepthStencilState.None;
			_rasterizerState = rasterizerState ?? RasterizerState.CullCounterClockwise;

			_effect = effect;
			
			_matrix = transformMatrix;
			
			
			if (sortMode == SpriteSortMode.Immediate) {
				//setup things now so a user can chage them
				Setup();
			}
*/
		}

		public void Begin (SpriteSortMode sortMode, BlendState blendState)
		{
			Begin (sortMode, blendState, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Matrix.Identity);			
		}

		public void Begin (SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState)
		{
			Begin (sortMode, blendState, samplerState, depthStencilState, rasterizerState, null, Matrix.Identity);	
		}

		public void Begin (SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect)
		{
			Begin (sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, Matrix.Identity);			
		}

        internal void End()
        {
        }

        internal void Draw(Texture2D texture2D, Vector2 position, Nullable<Rectangle> source, Color color, float p, Vector2 Origin, float p_2, SpriteEffects spriteEffects, float p_3)
        {
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, position, source, color.ToVector4(), Origin, spriteEffects));
        }
		
		//TODO: Draw stretching
		internal void Draw(Texture2D texture2D, Nullable<Rectangle> source, Color color)
        {
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, Vector2.Zero, source, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
        }
		
		//Draw texture section
		internal void Draw(Texture2D texture2D, Vector2 position, Nullable<Rectangle> source, Color color)
        {
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture2D, position, source, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
        }
		
		//TODO:
		internal void Draw (Texture2D texture, Nullable<Rectangle> source, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effect, float depth)
		{
/*
			if (sourceRectangle.HasValue) {
				tempRect = sourceRectangle.Value;
			} else {
				tempRect.X = 0;
				tempRect.Y = 0;
				tempRect.Width = texture.Width;
				tempRect.Height = texture.Height;				
			}
			
			texCoordTL.X = tempRect.X / (float)texture.Width;
			texCoordTL.Y = tempRect.Y / (float)texture.Height;
			texCoordBR.X = (tempRect.X + tempRect.Width) / (float)texture.Width;
			texCoordBR.Y = (tempRect.Y + tempRect.Height) / (float)texture.Height;

			if ((effect & SpriteEffects.FlipVertically) != 0) {
				float temp = texCoordBR.Y;
				texCoordBR.Y = texCoordTL.Y;
				texCoordTL.Y = temp;
			}
			if ((effect & SpriteEffects.FlipHorizontally) != 0) {
				float temp = texCoordBR.X;
				texCoordBR.X = texCoordTL.X;
				texCoordTL.X = temp;
			}
*/
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture, Vector2.Zero, source, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
		}

		//TODO:
		internal void Draw (Texture2D texture, Nullable<Rectangle> source, Rectangle? sourceRectangle, Color color)
		{
			graphicsDevice.DrawQueue.EnqueueSprite(new DrawSpriteCall(texture, Vector2.Zero, source, color.ToVector4(), Vector2.Zero, SpriteEffects.None));
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
