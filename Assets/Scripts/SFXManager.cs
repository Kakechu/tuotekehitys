using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource crunchSound;
    AudioSource petSound;
    AudioSource clickSound;

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
        
    }
}
