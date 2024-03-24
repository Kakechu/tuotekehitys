using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static int money;
    public Text moneyText;
    public static MoneyManager instance;
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + money;
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
