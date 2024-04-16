using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyNavigation : MonoBehaviour
{
    public float swipeThreshold = 50f;

    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    void Update()
    {
        CheckForSwipe();
    }

    void CheckForSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fingerDownPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            fingerUpPosition = Input.mousePosition;
            CheckSwipe();
        }
    }

    void CheckSwipe()
    {
        float swipeDistance = fingerUpPosition.x - fingerDownPosition.x;

        if (Mathf.Abs(swipeDistance) > swipeThreshold)
        {
            if (swipeDistance < 0) // Swipe left (next)
            {
                SceneManager.LoadScene("hedgehogView");
            }

            else if (swipeDistance > 0) // Swipe right (previous)
            {
                SceneManager.LoadScene("squirrelView");
            }
        }
    }

}