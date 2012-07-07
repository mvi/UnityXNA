using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Microsoft.Xna.Framework.Audio
{
    public class SoundEffect : IDisposable
    {
        public UnityEngine.AudioClip Clip { get; set; }

        public void Play()
        {
            GameObject gameObject = new GameObject("SoundEffectAudioClip");
            gameObject.AddComponent<AudioSource>();
            gameObject.audio.clip = Clip;
            gameObject.audio.Play();
            gameObject.AddComponent<AudioSourceController>();
            // TODO
        }

        public void Dispose()
        { }
    }
}
