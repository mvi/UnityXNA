#region License

/*
MIT License
Copyright ? 2006 The Mono.Xna Team

All rights reserved.

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

using System.Text;

namespace Microsoft.Xna.Framework.Input
{
    public struct GamePadButtons
    {
        #region Private Fields

        ButtonState a;
        ButtonState b;
        ButtonState back;
        ButtonState bigbutton;
        ButtonState leftShoulder;
        ButtonState rightShoulder;
        ButtonState leftStick;
        ButtonState rightStick;
        ButtonState start;
        ButtonState x;
        ButtonState y;

        #endregion Private Fields

        #region Public Properties

        public ButtonState A
        {
            get { return a; }
            internal set { a = value; }
        }

        public ButtonState B
        {
            get { return b; }
            internal set { b = value; }
        }

        public ButtonState Back
        {
            get { return back; }
            internal set { back = value; }
        }

        public ButtonState BigButton
        {
            get { return bigbutton; }
            internal set { bigbutton = value; }
        }

        public ButtonState LeftShoulder
        {
            get { return leftShoulder; }
            internal set { leftShoulder = value; }
        }

        public ButtonState RightShoulder
        {
            get { return rightShoulder; }
            internal set { rightShoulder = value; }
        }

        public ButtonState LeftStick
        {
            get { return leftStick; }
            internal set { leftStick = value; }
        }

        public ButtonState RightStick
        {
            get { return rightStick; }
            internal set { rightStick = value; }
        }

        public ButtonState Start
        {
            get { return start; }
            internal set { start = value; }
        }

        public ButtonState X
        {
            get { return x; }
            internal set { x = value; }
        }

        public ButtonState Y
        {
            get { return y; }
            internal set { y = value; }
        }

        #endregion

        #region Public Methods

        public GamePadButtons(Buttons buttons)
        {
            throw new System.NotImplementedException();
        }

        public static bool operator !=(GamePadButtons left, GamePadButtons right)
        {
            return !(left == right);
        }

        public static bool operator ==(GamePadButtons left, GamePadButtons right)
        {
            return (left.a == right.a)
                   && (left.b == right.b)
                   && (left.back == right.back)
                   && (left.leftShoulder == right.leftShoulder)
                   && (left.leftStick == right.leftStick)
                   && (left.rightShoulder == right.rightShoulder)
                   && (left.rightStick == right.rightStick)
                   && (left.start == right.start)
                   && (left.x == right.x)
                   && (left.y == right.y);
        }

        public override bool Equals(object obj)
        {
            return (obj is GamePadButtons) ? ((GamePadButtons)obj) == this : false;
        }

        public override int GetHashCode()
        {
            // TODO: Is this even worth doing? They're just bools...
            return a.GetHashCode()
                   ^ b.GetHashCode()
                   ^ back.GetHashCode()
                   ^ leftShoulder.GetHashCode()
                   ^ leftStick.GetHashCode()
                   ^ rightShoulder.GetHashCode()
                   ^ rightStick.GetHashCode()
                   ^ start.GetHashCode()
                   ^ x.GetHashCode()
                   ^ y.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(64);

            output.Append("{{Buttons:");
            if (a == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "A" : " A");

            if (b == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "B" : " B");

            if (x == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "X" : " X");

            if (y == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Y" : " Y");

            if (leftShoulder == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "LeftShoulder" : " LeftShoulder");

            if (rightShoulder == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "RightShoulder" : " RightShoulder");

            if (leftStick == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "LeftStick" : " LeftStick");

            if (rightStick == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "RightStick" : " RightStick");

            if (start == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Start" : " Start");

            if (back == ButtonState.Pressed)
                output.Append((output.Length == 0) ? "Back" : " Back");

            if (output.Length == 10)
                output.Append("None");

            output.Append("}}");
            return output.ToString();
        }

        #endregion Public Methods
    }
}