using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimalClick : MonoBehaviour
{
    private float touchArea = 0.1f;


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

                // Tarkista, onko kosketus osunut t�h�n GameObjectiin (el�imeen)
                Collider2D osuttuCollider = Physics2D.OverlapPoint(kosketusSijainti);

                if (osuttuCollider != null)
                {
                    if (osuttuCollider.CompareTag("Back"))
                    {
                        SFXManager.clickHappened = true;
                        SceneManager.LoadScene("forestView");
                    }

                    else if (osuttuCollider.CompareTag("PlayMiniGame"))
                    {
                        SFXManager.clickHappened = true;
                        SceneManager.LoadScene("Minigame");
                    }

                    else if (osuttuCollider.CompareTag("PlayBunny"))
                    {
                        SFXManager.clickHappened = true;
                        SceneManager.LoadScene("MinigameBunny");
                    }

                    else if (osuttuCollider.CompareTag("PlayHedgehog"))
                    {
                        SFXManager.clickHappened = true;
                        SceneManager.LoadScene("MinigameHedgehog");
                    }


                }
            }
        }
    }
}
