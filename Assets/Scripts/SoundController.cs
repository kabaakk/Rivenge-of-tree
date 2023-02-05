using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    bool isMuted = false;
    [SerializeField] private static SoundController sound = null;
    [SerializeField] private Slider soundSlider;

    private void Awake()
    {
        if (sound == null)
        {
            sound = this;
            DontDestroyOnLoad(this);
        } else if (sound != null)
        {
            Destroy(sound);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        } else
        {
            Load();
        }
    }

    public void changeSoundVolume()
    {
        AudioListener.volume = soundSlider.value;
        Save();
    }

    private void Load()
    {
        soundSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", soundSlider.value);
    }
}
