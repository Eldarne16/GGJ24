using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicHandler : MonoBehaviour
{
    AudioSource musicSource;
    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}
