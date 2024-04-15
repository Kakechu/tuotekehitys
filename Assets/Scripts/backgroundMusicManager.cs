using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class backgroundMusicManager : MonoBehaviour
{

    public AudioSource bgMusic;

    public static bool musicStart = true;

    void Start()
    {
        playBGMusic();
    }

    
    void Update()
    {
        if (musicStart == false)
        {
            bgMusic.Stop();
        }
    } 

    void playBGMusic()
    {
        bgMusic.Play();
        DontDestroyOnLoad(bgMusic);
    }
    

}
