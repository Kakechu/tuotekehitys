using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class SquirrelManager : MonoBehaviour
{

    private float touchArea = 0.1f;
    public int minHappiness = 0;
    public static int currentSquirrelHappiness;
    public HappinessManager happinessManager;
    public static TimerScript timer;
    public static TimerScript foodtimer;
    public bool osuttu = false;
    public bool eiosuttu = true;
    public bool ruokaosuttu = false;
    public bool ruokaeiosuttu = true;





    void Start()
    {
        happinessManager.SetHappiness(currentSquirrelHappiness);
        timer = GameObject.FindObjectOfType<TimerScript>();
        foodtimer = GameObject.FindObjectOfType<TimerScript>();
        timer.timeLeft = 5;
        TimerScript.timerRunning = false;
        foodtimer.foodtimeLeft = 5;
        TimerScript.foodtimerRunning = false;
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
                    if (osuttuCollider.CompareTag("SquirrelView"))
                    {
                        collisionFunction();
                    }

                    else if (osuttuCollider.CompareTag("Feed")) // lisäys
                    {
                        collisionFeed();
                    }
                }


            }
        }

    } // Käynnistää piste-ehdot ja timerin
    void collisionFunction()
    {
        collisionSquirrel();
        timer.StartTimer();
    }
    void collisionFeed()
    {
        gotFood();
        foodtimer.StartFoodTimer();
    }


    void collisionSquirrel()
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
                // rapsutusääni
                SFXManager.happyPet = true;
                Debug.Log("+1 ORAVA");
                osuttu = false;
                if (osuttu == false && TimerScript.timerRunning == false)
                {
                    Debug.Log("eiosuttu true taas");
                    eiosuttu = true;

                    // Palautetaan timer alkutilaan
                    timer.timeLeft = 5;
                }
            }
        }
    }

    void gotFood()
    {
        ruokaeiosuttu = false;
        if (ruokaeiosuttu == false)
        {
            Debug.Log("RuokaOSUMA");
            ruokaosuttu = true;
            if (ruokaosuttu == true && TimerScript.foodtimerRunning == false)
            {
                // Lisätään tyytyväisyyspiste
                addHappiness(3);
                // rousk ääni
                SFXManager.goodSoup = true;
                Debug.Log("ORAVAHAUKS");
                ruokaosuttu = false;
                if (ruokaosuttu == false && TimerScript.foodtimerRunning == false)
                {
                    Debug.Log("eiosuttu true taas");
                    ruokaeiosuttu = true;

                    // Palautetaan timer alkutilaan
                    foodtimer.foodtimeLeft = 5;
                }
            }
        }
    }


    void addHappiness(int happiness)
    {
        Debug.Log("PISTE");
        currentSquirrelHappiness += happiness;

        happinessManager.SetHappiness(currentSquirrelHappiness);
    }
}