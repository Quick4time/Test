using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingPoupAudio : MonoBehaviour {

    [SerializeField]
    AudioMixer mixer;
    [SerializeField]
    private Image content;
    private float maxVolume = 20.0f;
    public float Soundlvl
    {
        get { return _soundlvl; }
        set { _soundlvl = Mathf.Clamp(value, -80.0f, 20.0f);
            content.fillAmount = Map(_soundlvl, -80.0f, 20.0f, 0, 1);
            OnSoundValue(_soundlvl);
        }
    }
    private float _soundlvl;

    private void Awake()
    {
        //Soundlvl = -20.0f; // пренести в AudioManager.// еще смотреть вторую реализацию ch10/multiplatforma/
    }
    private void Start()
    {
        Soundlvl = 0.0f;
    }

    public void OnSoundToggle()
    {
        Managers.Audio.soundMute = !Managers.Audio.soundMute;
    }

    public void OnSoundValue(float value)
    {
        mixer.SetFloat("Soundlvl", value);
    }
    public void OnSfxValue(float value)
    {
        mixer.SetFloat("Sfxlvl", value);
    }
    public void OnMusicValue(float value)
    {
        mixer.SetFloat("Musiclvl", value);
    }
    public void Minus()
    {
        Soundlvl -= 5.0f;
    }
    public void Plus()
    {
        Soundlvl += 5.0f;
    }


    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

}

/*
 * Скрипт с case и switch для преключения музыки.
    public void OnPlayMusic(int selector) {
		Managers.Audio.PlaySound(sound);

		switch (selector) {
		case 1:
			Managers.Audio.PlayIntroMusic();
			break;
		case 2:
			Managers.Audio.PlayLevelMusic();
			break;
		default:
			Managers.Audio.StopMusic();
			break;
		}
	} 
*/
