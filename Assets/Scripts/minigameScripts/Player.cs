using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    //reference to player's speed
    public float moveSpeed;
    // reference to rigidbody of player
    Rigidbody2D rigidBody;
    // tracking collectables
    public int collectCount;
    // collectible score tracker text
    public TextMeshProUGUI collectibleScoreText;

    // Start is called before the first frame update
    void Start()
    {
        // getting access to rigidbody component
        rigidBody = GetComponent<Rigidbody2D>();

        // adding score text
        collectibleScoreText.text = "Hearts: " + "heart count here";
    }

    // Update is called once per frame
    void Update()
    {
        // if touching screen, adding velocity to Player
        // Input.GetMouseButton(0) should also work with touchscreen on mobile 
        if (Input.GetMouseButton(0))
        {
            // world point means center is 0, left is negative and right is positive
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                // if pressing on left side of the screen, player moves left
                rigidBody.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                // if pressing on right side of the screen, player moves right
                rigidBody.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            // if not touching screen, velocity is zero
            rigidBody.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log(collision.gameObject.tag);
            SceneManager.LoadScene("Minigame");
        }

        if (collision.gameObject.tag == "Collectible")
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
            collectCount++;
            Debug.Log(collectCount);
            collectibleScoreText.text = collectCount.ToString();
            //Debug.Log(collision.gameObject.name);
        }

    }

}

