using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
	{
		private GameComponentCollection _components;
        Content.ContentManager content;
		GraphicsDevice graphicsDevice;
		DrawQueue drawQueue;
        long totalTicks = 0;

		public DrawQueue DrawQueue {
			get {
				return this.drawQueue;
			}
			set {
				drawQueue = value;
			}
		}
        public ContentManager Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        public GraphicsDevice GraphicsDevice
        {
            get
            {
				if(graphicsDevice == null)
					graphicsDevice = new GraphicsDevice(DrawQueue);
				
				return graphicsDevice;
            }
        }

        public Game()
        {
            content = new ContentManager(null, "");
			
			_components = new GameComponentCollection();	
        }

        protected virtual void Update(GameTime gameTime)
        {  
        }
		
		public GameComponentCollection Components
		{
			get
			{
				return this._components;
			}
		}

        protected virtual void Draw(GameTime gameTime)
        {
        }
        protected virtual void LoadContent()
        {
        }
        protected virtual void Exit()
        {
        }

        public GameWindow Window
        {
            get
            {
                // TODO
                return new UnityGameWindow();
            }
        }

        public GameServiceContainer Services
        {
            get
            {
                // TODO
                return null;
            }
        }

        internal void Run()
        {
            throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        internal void Begin()
        {
            LoadContent();
			// XNA's first update call has a zero elapsed time, so do one now.
			GameTime gameTime = new GameTime(new TimeSpan(0), new TimeSpan(0), new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0));
			Update(gameTime);
        }

        internal void Tick(float deltaTime)
        {
            long microseconds = (int)(deltaTime * 1000000);
			long ticks = microseconds * 10;
            totalTicks += ticks;
            GameTime gameTime = new GameTime(new TimeSpan(0), new TimeSpan(0), new TimeSpan(totalTicks), new TimeSpan(ticks));
            Update(gameTime);
            Draw(gameTime);
        }

       
    }
}
