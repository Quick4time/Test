using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIAudioController : MonoBehaviour {
    [SerializeField]
    private settingPoupAudio popupAudio;
    public AudioMixer TestAudioMixer;
    public AudioMixerSnapshot paused; // snapshot test.
    public AudioMixerSnapshot unpaused;
    bool test;
    Canvas canvas;

	void Start () {
        //popupAudio = GetComponent<settingPoupAudio>();
        popupAudio.gameObject.SetActive(false);
        canvas = GetComponent<Canvas>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.M))
        {
            //Pause();
            bool isShowing = popupAudio.gameObject.activeSelf;
            popupAudio.gameObject.SetActive(!isShowing);
            Pause();

            if (isShowing) // скрываем курсор при закрытии и наоборот.
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
	}
    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        LowPass();
    }
    void LowPass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(0.01f);
        }
        else
        {
            unpaused.TransitionTo(0.01f);
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
