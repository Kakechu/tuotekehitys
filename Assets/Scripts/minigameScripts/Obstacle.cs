using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
        // destroyes objects when minigame ends
        if (Player.exterminate == true)
        {
            Destroy(gameObject);
        }

    }
}
