#define ALT_MODE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Microsoft.Xna.Framework.Content
{
	public class ContentManager
	{
		private IServiceProvider serviceProvider;
		private string p;

		public ContentManager(IServiceProvider serviceProvider, string p)
		{
			// TODO: Complete member initialization
			this.serviceProvider = serviceProvider;
			this.p = p;
		}
		internal T1 Load<T1>(string asset) where T1 : IDisposable
		{
			Type type = typeof(T1);
			
#if ALT_MODE	
			asset = Path.Combine("Content", asset);
			asset = asset.Replace("\\","/");
#else
			asset = Path.Combine(Directory.GetCurrentDirectory(), Path.Combine("Content", asset));
			string filename;
			string directoryName = Path.GetDirectoryName(asset);
			string smallFilename = Path.GetFileName(asset);
			string[] fileResults = Directory.GetFiles(directoryName, smallFilename + "*");
			asset = fileResults[0];
#endif		
			// TODO: Do cache check

			if(type == typeof(Texture2D))
			{
				Texture2D texture = LoadTexture2D(asset);
				return (T1)Convert.ChangeType(texture, type);
			}
			else if (type == typeof(SpriteFont))
			{
				SpriteFont spriteFont = LoadSpriteFont(asset);
				return (T1)Convert.ChangeType(spriteFont, type);
			}
			else if (type == typeof(SoundEffect))
			{
                SoundEffect soundEffect = LoadSoundEffect(asset);
                return (T1)Convert.ChangeType(soundEffect, type);
			}
			else if (type == typeof(Song))
			{
                Song song = LoadSong(asset);
                return (T1)Convert.ChangeType(song, type);
			}

			
			// TODO: Improve
			return default(T1);            
		}

		private Texture2D LoadTexture2D(string asset)
		{
			UnityEngine.Texture2D unityTexture = new UnityEngine.Texture2D(2, 2);
			
#if ALT_MODE		
			unityTexture = (UnityEngine.Texture2D)UnityEngine.Resources.Load(asset);
#else		
			byte[] bytes = File.ReadAllBytes(asset);
			unityTexture.LoadImage(bytes);
#endif
			
			return new Texture2D(unityTexture);
		}
		
		private SpriteFont LoadSpriteFont(string asset)
		{
			UnityEngine.TextAsset spriteFontText = (UnityEngine.TextAsset)UnityEngine.Resources.Load(asset, typeof(UnityEngine.TextAsset));
			
			Dictionary<string, string> fontSettings = new Dictionary<string, string>();
			
			StringReader stringReader = new StringReader(spriteFontText.text);

#if UNITY_3_0 || UNITY_3_0_0 || UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5
			stringReader.Read(); // Skip the byte order mark on Unity 3.x - note that this seems to work as of Unity 4
#endif
			
			XmlTextReader xmlReader = new XmlTextReader(stringReader);
			
			XmlDocument document = new XmlDocument();
			document.Load(xmlReader);
			
			foreach(XmlNode childNode in document.DocumentElement.ChildNodes[0].ChildNodes)//[0].ChildNodes)
			{
				// Ignore comments
				if(!childNode.Name.StartsWith("#"))
				{
					fontSettings.Add(childNode.Name, childNode.InnerText);
				}
			}

			xmlReader.Close();
			stringReader.Close();
			
			if(fontSettings.ContainsKey("FontName") 
				&& fontSettings.ContainsKey("Size") 
				&& fontSettings.ContainsKey("Spacing") 
				&& fontSettings.ContainsKey("UseKerning") 
				&& fontSettings.ContainsKey("Style"))
			{
				SpriteFont spriteFont = new SpriteFont(fontSettings["FontName"], float.Parse(fontSettings["Size"]), float.Parse(fontSettings["Spacing"]), bool.Parse(fontSettings["UseKerning"]), fontSettings["Style"]);
			
				return spriteFont;
			}
			else
			{
				return null;
			}
		}

        private SoundEffect LoadSoundEffect(string asset)
        {
            SoundEffect soundEffect = new SoundEffect();
            soundEffect.Clip = (UnityEngine.AudioClip)UnityEngine.Resources.Load(asset);

            return soundEffect;
        }

        private Song LoadSong(string asset)
        {
            Song song = new Song();
            song.Clip = (UnityEngine.AudioClip)UnityEngine.Resources.Load(asset);
            
            return song;
        }

		internal void Unload()
		{
			// TODO
		}

		public string RootDirectory { get; set; }
	}
}
