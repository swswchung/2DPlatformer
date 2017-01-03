using UnityEngine;
using System.Collections;

public class CPlayerSound : MonoBehaviour {

    public AudioClip[] _sound;
    public float _voiceSoundVol = 1f;
    
    public void EffectSound(int num)
    {
        PlayOnSound(_sound[num]);
    }

    public void PlayOnSound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, _voiceSoundVol);
    }
}
