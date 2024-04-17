using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private static Animator animalAnim;
    private float touchArea = 0.1f;
    public static TimerScript timer;
    public static SquirrelManager squirrelmanager;
    public static bool food = false;
    public static bool hearts = false;
    public static AnimationScript instance;
    //private GameObject selfChar;
    // Start is called before the first frame update
    void Start()
    {
        //charAnim = GetComponent<Animator>();
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
                

                if (osuttuCollider != null)
                {
                    animalAnim = GetComponent<Animator>();
                    if (osuttuCollider.CompareTag("SquirrelView")
                       |osuttuCollider.CompareTag("HedgehogView")
                       |osuttuCollider.CompareTag("BunnyView"))
                    {
                        //charAnim = GetComponent<Animator>();
                        Debug.Log("hearts");
                        if (hearts == true)
                        {
                            Debug.Log("HEEEAAAAAARTTSSS!!!");
                            animalAnim.SetTrigger("TrHeart");
                            hearts = false;
                        }
                        
                    }
                    if (osuttuCollider.CompareTag("Left"))
                    {
                        //charAnim = GetComponent<Animator>();
                        animalAnim.SetTrigger("TrR");
                    }
                    if (osuttuCollider.CompareTag("Right"))
                    {
                        //charAnim = GetComponent<Animator>();
                        animalAnim.SetTrigger("TrL");
                    }
                    if (osuttuCollider.CompareTag("Feed"))
                    {
                        Debug.Log("Food!!");
                        if (food == true)
                        {
                            Debug.Log("FOOOOOOOOOOOOD");
                            //charAnim = GetComponent<Animator>();
                            animalAnim.SetTrigger("TrFood");
                            food = false;
                        }

                      
                    }
                }
            }
        }
    }
  
   
}