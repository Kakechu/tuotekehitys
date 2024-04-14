using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static int money;

    public static MoneyManager instance;

    //testi
    // Start is called before the first frame update
    void Start()
    {
        money = 0;

    }


    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        else
        {
            Destroy(gameObject);
        }
        
    }

}
