using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class SquirrelManager : MonoBehaviour
{

    private float touchArea = 0.1f;
    public int minHappiness = 0;
    public static int currentSquirrelHappiness;
    public HappinessManager happinessManager;



    /*
    void Start()
    {
        currentSquirrelHappiness = minHappiness;
        happinessBar.SetMinHappiness(minHappiness);
    }
    */

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

                // Tarkista, onko kosketus osunut tähän GameObjectiin (eläimeen)
                Collider2D osuttuCollider = Physics2D.OverlapPoint(kosketusSijainti);

                if (osuttuCollider != null)
                {
                    if (osuttuCollider.CompareTag("SquirrelView"))
                    {
                        addHappiness(1);
                        Debug.Log("kutikuti");
                        //currentSquirrelHappiness++;
                    }
                    /*
                    else if (osuttuCollider.CompareTag("Bunny"))
                    {
                        SceneManager.LoadScene("bunnyView");
                    }
                    else if (osuttuCollider.CompareTag("Hedgehog"))
                    {
                        SceneManager.LoadScene("hedgehogView");
                    }
                    */
                }

                void addHappiness(int happiness)
                {
                    currentSquirrelHappiness += happiness;

                    happinessManager.SetHappiness(currentSquirrelHappiness);
                }

            }
        }
    }
    /*
    public void addSquirrelHappiness(int happiness)
    {
        currentSquirrelHappiness += happiness;
        happinessBar.SetHappiness(currentSquirrelHappiness);
    }
    */
}