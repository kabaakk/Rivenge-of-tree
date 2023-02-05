using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    bool isMuted = false;
    [SerializeField] private static MusicController music = null;
    [SerializeField] private Slider musicSlider;

    private void Awake()
    {
        if (music == null)
        {
            music = this;
            DontDestroyOnLoad(this);
        } else if (this != music)
        {
            Destroy(music);
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

    public void ChangeVolume() 
    {
        AudioListener.volume = musicSlider.value;
        Save();
    }

    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
}
