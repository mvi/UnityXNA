#define ALT_MODE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;

namespace Microsoft.Xna.Framework
{
    public class TitleContainer
    {
        internal static System.IO.Stream OpenStream(string path)
        {
            // TODO: Improve
			
#if ALT_MODE
			path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
			path = path.Replace("\\","/");
			TextAsset textAsset = (TextAsset)Resources.Load(path);
			MemoryStream ms = new MemoryStream();
			
			System.Text.UTF8Encoding encoding =new System.Text.UTF8Encoding();
			byte[] bytes = encoding.GetBytes(textAsset.text);
			
			ms.Write(bytes, 0, bytes.Length);
			ms.Position = 0;
			
			return ms;
#else
            return new FileStream(path, FileMode.Open);
#endif
        }
    }
}
