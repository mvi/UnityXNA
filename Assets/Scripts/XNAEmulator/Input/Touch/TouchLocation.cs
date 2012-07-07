using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Input.Touch
{
    public struct TouchLocation : IEquatable<TouchLocation>
    {
        public TouchLocationState State { get; set; }

        public bool Equals(Microsoft.Xna.Framework.Input.Touch.TouchLocation touchLocation)
        {
            throw new NotImplementedException();
        }
    }
}

