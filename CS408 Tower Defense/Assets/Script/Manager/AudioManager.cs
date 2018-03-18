using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager> {

    public AudioClip[] SFX;
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(int i)
    {
       // source.PlayOneShot(SFX[i], 1f);
    }

}