using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MoneyDisplay : MonoBehaviour
{

    //public Text moneyText;
    public TextMeshProUGUI moneyText;

    void Update()
    {
        moneyText.text = MoneyManager.money.ToString();
    }

}
