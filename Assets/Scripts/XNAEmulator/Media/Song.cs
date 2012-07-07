using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework.Media
{
    public class Song : IDisposable
    {
        public void Dispose()
        { }

        public UnityEngine.AudioClip Clip { get; set; }
    }
}
