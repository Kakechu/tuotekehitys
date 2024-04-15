using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class HedgehogManager : MonoBehaviour
{

    private float touchArea = 0.1f;
    public int minHappiness = 0;
    public static int currentHedgehogHappiness;
    public HappinessManager happinessManager;
    public static TimerScript timer;
    public bool osuttu = false;
    public bool eiosuttu = true;





    void Start()
    {
        happinessManager.SetHappiness(currentHedgehogHappiness);
        timer = GameObject.FindObjectOfType<TimerScript>();
    }


    void Update()
    {
        // Tarkista, onko näyttöä kosketettu
        if (Input.touchCount > 0)
        {
            // Otetaan ensimmäinen kosketus
            Touch kosketus = Input.GetTouch(0);

            // Tarkista, onko kosketus liian lyhyt (klikkaus)
            if (kosketus.phase == TouchPhase.Began && kosketus.deltaTime < touchArea)
            {
                // Määritä sormen sijainti
                Vector3 kosketusSijainti = Camera.main.ScreenToWorldPoint(kosketus.position);

                // Tarkista, onko kosketus osunut tähän eläimeen
                Collider2D osuttuCollider = Physics2D.OverlapPoint(kosketusSijainti);

                if (osuttuCollider != null)
                {
                    if (osuttuCollider.CompareTag("HedgehogView"))
                    {
                        collisionFunction();
                    }

                }
            }
        }

    }// Käynnistää piste-ehdot ja timerin
    void collisionFunction()
    {
        collisionHedgehog();
        timer.StartTimer();
    }
    void collisionHedgehog()
    {
        eiosuttu = false;
        if (eiosuttu == false)
        {
            Debug.Log("OSUMA");
            osuttu = true;
            if (osuttu == true && TimerScript.timerRunning == false)
            {
                // Lisätään tyytyväisyyspiste
                addHappiness(1);
                Debug.Log("+1 SIILI");
                osuttu = false;
                if (osuttu == false && TimerScript.timerRunning == false)
                {
                    Debug.Log("eiosuttu true taas");
                    eiosuttu = true;

                    // Palautetaan timer alkutilaan
                    timer.timeLeft = 7;
                }

            }


        }
    }
    void addHappiness(int happiness)
    {
        Debug.Log("PISTE");
        currentHedgehogHappiness += happiness;

        happinessManager.SetHappiness(currentHedgehogHappiness);
    }
}

