using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private Animator charAnim;
    private float touchArea = 0.1f;
    //private GameObject selfChar;
    // Start is called before the first frame update
    void Start()
    {
        charAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        characterMotion();
    }
    void characterMotion()
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
                //MeshCollider osuttuMesh = Physics2D.OverlapPoint(kosketusSijainti);

                if (osuttuCollider != null)
                {
                    if (osuttuCollider.CompareTag("Hedgehog"))
                    {
                        
                        charAnim.SetTrigger("TrHeart");
                        Debug.Log("HEARTS");
                    }
                    else if (osuttuCollider.CompareTag("Left"))
                    {
                        charAnim.SetTrigger("TrVasen");
                    }
                    //else if (osuttuCollider.CompareTag("oikea"))
                    //{
                    //    charAnim.SetTrigger("TrOikea");
                    //}
                }
            }
        }
    }
}
