using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Microsoft.Xna.Framework.Input
{
    public static class Keyboard
    {
		static KeyCode[] keyMapping;
		
		static Keyboard()
		{
			keyMapping = new KeyCode[256];
			
			// Alphabet
			keyMapping[(int)Keys.A] = KeyCode.A;
			keyMapping[(int)Keys.B] = KeyCode.B;
			keyMapping[(int)Keys.C] = KeyCode.C;
			keyMapping[(int)Keys.D] = KeyCode.D;
			keyMapping[(int)Keys.E] = KeyCode.E;
			keyMapping[(int)Keys.F] = KeyCode.F;
			keyMapping[(int)Keys.G] = KeyCode.G;
			keyMapping[(int)Keys.H] = KeyCode.H;
			keyMapping[(int)Keys.I] = KeyCode.I;
			keyMapping[(int)Keys.J] = KeyCode.J;
			keyMapping[(int)Keys.K] = KeyCode.K;
			keyMapping[(int)Keys.L] = KeyCode.L;
			keyMapping[(int)Keys.M] = KeyCode.M;
			keyMapping[(int)Keys.N] = KeyCode.N;
			keyMapping[(int)Keys.O] = KeyCode.O;
			keyMapping[(int)Keys.P] = KeyCode.P;
			keyMapping[(int)Keys.Q] = KeyCode.Q;
			keyMapping[(int)Keys.R] = KeyCode.R;
			keyMapping[(int)Keys.S] = KeyCode.S;
			keyMapping[(int)Keys.T] = KeyCode.T;
			keyMapping[(int)Keys.U] = KeyCode.U;
			keyMapping[(int)Keys.V] = KeyCode.V;
			keyMapping[(int)Keys.W] = KeyCode.W;
			keyMapping[(int)Keys.X] = KeyCode.X;
			keyMapping[(int)Keys.Y] = KeyCode.Y;
			keyMapping[(int)Keys.Z] = KeyCode.Z;
			
			// Main number keys
			keyMapping[(int)Keys.D0] = KeyCode.Keypad0;
			keyMapping[(int)Keys.D1] = KeyCode.Keypad1;
			keyMapping[(int)Keys.D2] = KeyCode.Keypad2;
			keyMapping[(int)Keys.D3] = KeyCode.Keypad3;
			keyMapping[(int)Keys.D4] = KeyCode.Keypad4;
			keyMapping[(int)Keys.D5] = KeyCode.Keypad5;
			keyMapping[(int)Keys.D6] = KeyCode.Keypad6;
			keyMapping[(int)Keys.D7] = KeyCode.Keypad7;
			keyMapping[(int)Keys.D8] = KeyCode.Keypad8;
			keyMapping[(int)Keys.D9] = KeyCode.Keypad9;
			
			// Others
			keyMapping[(int)Keys.Enter] = KeyCode.Return;
			keyMapping[(int)Keys.Delete] = KeyCode.Delete;
            keyMapping[(int)Keys.Space] = KeyCode.Space;
            keyMapping[(int)Keys.Left] = KeyCode.LeftArrow;
            keyMapping[(int)Keys.Right] = KeyCode.RightArrow;
            keyMapping[(int)Keys.Up] = KeyCode.UpArrow;
            keyMapping[(int)Keys.Down] = KeyCode.DownArrow;
				
			// TODO: More key code conversions
		}
		
        internal static KeyboardState GetState()
        {
			bool[] keyStates = new bool[256];
			
			for (int i = 0; i < keyStates.Length; i++)
			{
				if(keyMapping[i] != null)
				{
					keyStates[i] = UnityEngine.Input.GetKey(keyMapping[i]);
				}
			}
			
            return new KeyboardState(keyStates);
        }
    }
}