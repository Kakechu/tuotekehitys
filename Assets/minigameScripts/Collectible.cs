using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{

    void Update()
    {

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }

        
    }

   
}
