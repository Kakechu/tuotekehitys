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




    
    void Start()
    {
        happinessManager.SetHappiness(currentSquirrelHappiness);
    }
    

    void Update()
    {
        // Tarkista, onko n�ytt�� kosketettu
        if (Input.touchCount > 0)
        {
            // Otetaan ensimm�inen kosketus
            Touch kosketus = Input.GetTouch(0);

            // Tarkista, onko kosketus liian lyhyt (klikkaus)
            if (kosketus.phase == TouchPhase.Began && kosketus.deltaTime < touchArea)
            {
                // M��rit� sormen sijainti
                Vector3 kosketusSijainti = Camera.main.ScreenToWorldPoint(kosketus.position);

                // Tarkista, onko kosketus osunut t�h�n el�imeen
                Collider2D osuttuCollider = Physics2D.OverlapPoint(kosketusSijainti);

                if (osuttuCollider != null)
                {
                    if (osuttuCollider.CompareTag("SquirrelView"))
                    {
                        addHappiness(1);
                    }

                }

                void addHappiness(int happiness)
                {
                    currentSquirrelHappiness += happiness;

                    happinessManager.SetHappiness(currentSquirrelHappiness);
                }

            }
        }

    }
}