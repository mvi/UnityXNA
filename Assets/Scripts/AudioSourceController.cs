using System.Collections;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    IEnumerator Start()
    {
        // Wait for the audio clip to finish playing, then delete the game object
        yield return new WaitForSeconds(audio.clip.length);
        Destroy(this.gameObject);
    }
}
