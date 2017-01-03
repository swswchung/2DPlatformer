using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CSoundManagerUI : MonoBehaviour {

    public float _effectSoundVol = 1f;   //효과음

    public GameObject _soundConfigPanel;

    public AudioSource _bgmAudioSource;

    void Awake()
    {
        _bgmAudioSource = GetComponent<AudioSource>();
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
