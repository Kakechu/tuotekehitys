using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyManager : MonoBehaviour
{

    private float touchArea = 0.1f;
    public int minHappiness = 0;
    public static int currentBunnyHappiness;
    public HappinessManager happinessManager;





    void Start()
    {
        happinessManager.SetHappiness(currentBunnyHappiness);
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
                    if (osuttuCollider.CompareTag("BunnyView"))
                    {
                        addHappiness(1);
                    }

                }

                void addHappiness(int happiness)
                {
                    currentBunnyHappiness += happiness;

                    happinessManager.SetHappiness(currentBunnyHappiness);
                }

            }
        }

    }
}
