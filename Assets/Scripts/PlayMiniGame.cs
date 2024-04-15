using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMiniGame : MonoBehaviour
{
    public string MiniGame = "Minigame";

    private float touchArea = 0.1f;


    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch kosketus = Input.GetTouch(0);

            if (kosketus.phase == TouchPhase.Began && kosketus.deltaTime < touchArea)
            {
                Vector3 kosketusSijainti = Camera.main.ScreenToWorldPoint(kosketus.position);

                Collider2D osuttuCollider = Physics2D.OverlapPoint(kosketusSijainti);

                if (osuttuCollider != null)
                {
                    if (osuttuCollider.CompareTag("PlayMiniGame"))
                    {
                        SceneManager.LoadScene(MiniGame);
                    }

                    else if (osuttuCollider.CompareTag("PlayBunny"))
                    {
                        SceneManager.LoadScene("MinigameBunny");
                    }

                    else if (osuttuCollider.CompareTag("PlayHedgehog"))
                    {
                        SceneManager.LoadScene("MinigameHedgehog");
                    }



                }
            }
        }
    }
}

