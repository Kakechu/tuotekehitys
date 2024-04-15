using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class backgroundMusicManager : MonoBehaviour
{

    public AudioSource bgMusic;

    public static bool musicStart;
    public static bool plsPlay;
    public static bool plsStop;
    

    void Start()
    {
        playBGMusic();
    }

    
    void Update()
    {
        if (plsStop == true)
        {
            bgMusic.Pause();
            plsStop = false;
        }
        if (plsPlay == true)
        {
            bgMusic.UnPause();
            plsPlay = false;
        }
    } 

    void playBGMusic()
    {
        bgMusic.Play();
        DontDestroyOnLoad(bgMusic);
    }

}
