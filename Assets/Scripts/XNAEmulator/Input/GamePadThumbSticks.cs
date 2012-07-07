#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

Authors: Rob Loach (http://www.robloach.net)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadThumbSticks
    {
        #region Private Fields

        internal Vector2 left;
        internal Vector2 right;

        #endregion Private Fields

        #region Public Properties

        public Vector2 Left
        {
            get { return this.left; }
        }


        public Vector2 Right
        {
            get { return this.right; }
        }

        #endregion


        #region Public methods

        public static bool operator !=(GamePadThumbSticks left, GamePadThumbSticks right)
        {
            return !(left == right);
        }

        public static bool operator ==(GamePadThumbSticks left, GamePadThumbSticks right)
        {
            return ((left.left == right.left) && (left.right == right.right));
        }

        public override bool Equals(object obj)
        {
            return (obj is GamePadThumbSticks) ? ((GamePadThumbSticks)obj) == this : false;
        }

        public override int GetHashCode()
        {
            return this.left.GetHashCode() ^ this.right.GetHashCode();
        }

        public GamePadThumbSticks(Microsoft.Xna.Framework.Vector2 leftThumbstick, Microsoft.Xna.Framework.Vector2 rightThumbstick)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return string.Format("{{Left:{0} Right:{1}}}", left, right);
        }

        #endregion Public Methods
    }
}