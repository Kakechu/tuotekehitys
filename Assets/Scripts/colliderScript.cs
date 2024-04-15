using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colliderScript : MonoBehaviour
{
    //public string foxView;
    //public string goatView;

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
                    if (osuttuCollider.CompareTag("pupumodel"))
                    {
                        Debug.Log("modelilla on collider");
                        //SceneManager.LoadScene("squirrelView");
                    }

                    //else if (osuttuCollider.CompareTag("Bunny"))
                    {
                        //SceneManager.LoadScene("bunnyView");
                    }
                    //else if (osuttuCollider.CompareTag("Hedgehog"))
                    {
                        //SceneManager.LoadScene("hedgehogView");
                    }
                }
            }
        }
    }
}

