using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }


    public AudioSource audioSource;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this);
    }
    public float GetVolume()
    {
        return audioSource.volume;
    }
    public void Volume(float volume)
    {
        audioSource.volume = volume;
    }
}
