using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource crunchSound;
    AudioSource petSound;
    AudioSource clickSound;

    // boolean rapsutukselle
    public static bool happyPet = false;
    // boolean ruokinnalle
    public static bool goodSoup = false;
    // boolean napin painallukselle
    public static bool clickHappened = false;

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
        // jos eläintä rapsutettu
        if (happyPet == true)
        {
            petSound.Play();
            happyPet = false;
        }
        // jos eläin ruokittu
        if (goodSoup == true)
        {
            crunchSound.Play();
            goodSoup = false;
        }
        // jos nappulaa painettu
        if (clickHappened == true)
        {
            clickSound.Play();
            clickHappened = false;
        }
    }
}
