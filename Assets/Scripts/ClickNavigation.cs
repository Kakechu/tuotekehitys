using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickNavigation : MonoBehaviour
{

    private float touchArea = 0.1f;


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
                    SFXManager.clickHappened = true;

                    if (osuttuCollider.CompareTag("Squirrel"))
                    {
                        SceneManager.LoadScene("squirrelView");
                    }

                    if (osuttuCollider.CompareTag("Bunny"))
                    {
                        SceneManager.LoadScene("bunnyView");
                    }

                    else if (osuttuCollider.CompareTag("Hedgehog"))
                    {
                        SceneManager.LoadScene("hedgehogView");
                    }

                    else if (osuttuCollider.CompareTag("Shop"))
                    {
                        SceneManager.LoadScene("shopScene");
                    }

                    else if (osuttuCollider.CompareTag("ExitSign"))
                    {
                        SceneManager.LoadScene("forestView");
                    }

                    else if (osuttuCollider.CompareTag("Exit"))
                    {
                        SceneManager.LoadScene("Minigame");
                    }

                    else if (osuttuCollider.CompareTag("ExitToBunny"))
                    {
                        SceneManager.LoadScene("MinigameBunny");
                    }

                    else if (osuttuCollider.CompareTag("ExitToHedgehog"))
                    {
                        SceneManager.LoadScene("MinigameHedgehog");
                    }

                    else if (osuttuCollider.CompareTag("ExitToBiome"))
                    {
                        SceneManager.LoadScene("forestView");
                    }

                }
            }
        }
    }
}