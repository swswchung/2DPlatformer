using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CSoundManager : MonoBehaviour {
    
    public AudioClip[] _bgm;
    AudioSource _audioSource;

    public float _effectSoundVol = 1f;   //효과음

    public GameObject _soundConfigPanel;

    public AudioSource _bgmAudioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _bgmAudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        SoundConfigLoad();
    }

    public void PlayBgm(int num)
    {
        _audioSource.clip = _bgm[num];
        _audioSource.Play();

        //스테이지배경음만 저장...

        if(2 <= num)
        {
            return;
        }
        PlayerPrefs.SetInt("BGMNUM", num);
    }

    public void Boss()
    {
        PlayBgm(2);
    }

    public void PlayOnSound(AudioClip clip)
    {
        //즉흥적으로 사운드를 재생(스스로 소멸)
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, _effectSoundVol);
    }

    //사운드 설정 버튼을 클릭함.
    public void OnOpenSoundConfigPanel()
    {
        _soundConfigPanel.SetActive(true);
    }

    //사운드 설정창 종료
    public void OnCloseSoundConfigPanel()
    {
        SoundConfigSave();
        _soundConfigPanel.SetActive(false);
    }

    public void OnChangeBgmVolume(Slider volslider)//배경음 조절
    {
        //조절한 슬라이더의 값을 배경음의 볼륨에 적용함.
        _bgmAudioSource.volume = volslider.value;
    }

    public void OnChangeEffectVolume(Slider volslider)//효과음 조절
    {
        _effectSoundVol = volslider.value;
    }

    public void OnOffBgmSound(Toggle toggle)
    {
        _bgmAudioSource.mute = toggle.isOn;
    }

    public void SoundConfigSave()
    {
        //배경음 볼륨 저장
        PlayerPrefs.SetFloat("BGM_VOL", _bgmAudioSource.volume);
        //효과음 볼륨 저장
        PlayerPrefs.SetFloat("EFFECT_VOL", _effectSoundVol);

        PlayerPrefs.SetString("BGM_MUTE", _bgmAudioSource.mute.ToString());

        PlayerPrefs.Save();
    }

    public void SoundConfigLoad()
    {
        _bgmAudioSource.volume = PlayerPrefs.GetFloat("BGM_VOL", 1f);

        _effectSoundVol = PlayerPrefs.GetFloat("EFFECT_VOL", 1f);

        string strmute = PlayerPrefs.GetString("BGM_MUTE", "false");

        _bgmAudioSource.mute = bool.Parse(strmute);
    }
}