using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update
    public int money;
    public int moneyToAdd;
    void Start()
    {
        money = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }

    public void subtractMoney(int moneyToSubstract)
    {
        if (money - moneyToSubstract < 0)
        {
            Debug.Log("We don't have enough money");
        }
        else
        {
            money -= moneyToSubstract;
            Debug.Log($"Now I have {money} moneys");
        }
        
    }
}
