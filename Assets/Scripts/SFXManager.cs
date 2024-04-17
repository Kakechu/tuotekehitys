using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource crunchSound;
    AudioSource petSound;
    AudioSource clickSound;
    AudioSource swipeSound;

    // boolean rapsutukselle
    public static bool happyPet = false;
    // boolean ruokinnalle
    public static bool goodSoup = false;
    // boolean napin painallukselle
    public static bool clickHappened = false;
    // boolean swaippaukselle
    public static bool swipeHappened = false;

    // Start is called before the first frame update
    void Start()
    {
        // peliobjekti ei tuhoudu scenen vaihtuessa
        DontDestroyOnLoad(gameObject);
        // löytää audiosourcet
        var SFXs = GetComponents(typeof(AudioSource)).Cast<AudioSource>().ToArray();
        crunchSound = SFXs[0];
        petSound = SFXs[1];
        clickSound = SFXs[2];
        swipeSound = SFXs[3];
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

        if (swipeHappened == true)
        {
            swipeSound.Play();
            swipeHappened = false;
        }

    }
}
