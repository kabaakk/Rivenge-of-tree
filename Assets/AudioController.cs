using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioController : Singleton<AudioController>
{
    private AudioSource _audioSource;
    public enum SoundTypes
    {
        fireball,
        acornFly,
        grow,
        seedThrow,
        playerDeath,
        playerHit,
        monsterHit
        
        
        
    }

    [Serializable]
    public class SoundAndAudio
    {
        public SoundTypes type;
        public List<AudioClip> audioClips;


    }
  
    
    [SerializeField] private List<SoundAndAudio> soundAndAudios;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(SoundTypes type)
    {
        AudioClip clip = GetRandomClip(type);
        if (clip != null)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
    
    private AudioClip GetRandomClip(SoundTypes type)
    {
        foreach (SoundAndAudio soundAndAudio in soundAndAudios)
        {
            if (soundAndAudio.type == type)
            {
                return soundAndAudio.audioClips[Random.Range(0, soundAndAudio.audioClips.Count)];
            }
        }

        return null;
    }
}
