using UnityEngine;
using System.Collections;

public class CSonicAnimationSound : MonoBehaviour {

    public AudioClip[] _sound;
    public float _voiceSoundVol = 1f;

    public void Voice(int num)
    {
        PlayOnSound(_sound[num]);
    }

    public void PlayOnSound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, _voiceSoundVol);
    }
}
