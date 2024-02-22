using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAnimal : MonoBehaviour
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
                // M��rit� sormen sijainti maailmatilassa
                Vector3 kosketusSijainti = Camera.main.ScreenToWorldPoint(kosketus.position);

                // Tarkista, onko kosketus osunut t�h�n GameObjectiin (el�imeen)
                Collider2D osuttuCollider = Physics2D.OverlapPoint(kosketusSijainti);

                if (osuttuCollider != null && osuttuCollider.CompareTag("Animal"))
                {
                    // Lataa seuraava scene
                    SceneManager.LoadScene("Forest_animal_view");
                }
            }
        }
    }
}
