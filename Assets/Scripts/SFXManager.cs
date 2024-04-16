using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource crunchSound;
    AudioSource petSound;
    AudioSource clickSound;

    public static bool happyPet = false;
    public static bool goodSoup = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        var SFXs = GetComponents(typeof(AudioSource)).Cast<AudioSource>().ToArray();
        crunchSound = SFXs[0];
        petSound = SFXs[1];
        clickSound = SFXs[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (happyPet == true)
        {
            petSound.Play();
            happyPet = false;
        }
        if (goodSoup == true)
        {
            crunchSound.Play();
            goodSoup = false;
        }
    }
}
