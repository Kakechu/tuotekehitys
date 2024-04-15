using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
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

    //lisäys

    public GameObject cam;


    // AUDIO 
    AudioSource sparkleSound;
    AudioSource bonkSound;

    public static bool bonk = false;

    public static bool exterminate; 

    // MIKÄÄN EI TOIMIIIIII
    // get gamemanager script ?? maybe ??
    //public MinigameManager minigameScript;
    //MinigameManager script = gameObject.GetComponent<MinigameManager>();
    //public MinigameManager minigameScript;
    //public minigameScript script;
    //MinigameManager script = gameObject.AddComponent<MinigameManager>() as minigamescript;
    //GameObject MinigameManager;
    //MinigameManager.refScript;
    //minigamemanager.GetComponent<MinigameManager>();

    // Start is called before the first frame update
    void Start()
    {
        // getting access to rigidbody component
        rigidBody = GetComponent<Rigidbody2D>();


        //AudioSource[] audios = GetComponents<AudioSource>();
        var audios = GetComponents(typeof(AudioSource)).Cast<AudioSource>().ToArray();
        sparkleSound = audios[0];
        bonkSound = audios[1];


        // adding score text
        //collectibleScoreText.text = "Stars: " + collectCount.ToString();
        //collectibleScoreText.text = "<sprite name=\"spritesheet_0\"> " + collectCount.ToString();

        // get script
        //MinigameManager script = gameObject.GetComponent<MinigameManager>();
        //minigameScript = FindObjectOfType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStarted == true)
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

            // adding score text
            //collectibleScoreText.text = "Stars: " + collectCount.ToString();
            collectibleScoreText.text = "<sprite name=\"spritesheet_0\"> " + collectCount.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Obstacle")
        {
            bonkSound.Play();
            bonk = true;
            Debug.Log(collision.gameObject.tag);
            //bonkSound.Play();
            //SceneManager.LoadScene("Minigame");
            //GameManager.gameStarted = false;
            //bonkSound.Play();
            Debug.Log("bonk is true");

            if (bonk == true)
            {
                SomeMethod();
            }

        }

        if (collision.gameObject.tag == "Collectible")
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(collision.gameObject);
            collectCount++;
            MoneyManager.money += 1;
            //Debug.Log("money" + MoneyManager.money);

            Debug.Log(collectCount);
            collectibleScoreText.text = collectCount.ToString();

            sparkleSound.Play();
            Debug.Log("sparkle");

            //Debug.Log(collision.gameObject.name);
        }

    }

    public void SomeMethod()
    {
        StartCoroutine(SomeCoroutine());
        //DontDestroyOnLoad(bonkSound);
        //bonkSound.Play();
        //SceneManager.LoadScene("Minigame");
        //GameManager.gameStarted = false;
        //backgroundMusicManager.plsPlay = true;
    }

    
    private IEnumerator SomeCoroutine()
    {
        bonkSound.Play();
        exterminate = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Minigame");
        GameManager.gameStarted = false;
        backgroundMusicManager.plsPlay = true;
        exterminate = false;
    }  
    
}
