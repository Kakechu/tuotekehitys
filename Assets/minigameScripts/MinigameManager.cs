using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    // VARIABLES:

    // reference to Obstacle Object
    public GameObject obstacle;
    // reference to Collectible Object
    public GameObject collectible;
    // x coordinate limit to which falling objects can be spawned
    public float maxX;
    // reference to Spawn Point
    public Transform spawnPoint;
    // how often obstacles are spawned
    public float spawnRateObstacle;
    // how often collectibles are spawned
    public float spawnRateCollectible;
    //float spawnRate = 1.0f;

    bool gameStarted = false;

    // reference to "tap to start text"
    //public GameObject startText;
    // reference to score count text
    public TextMeshProUGUI scoreText;
    // variable for score
    int score = 0;
    // variable for time passed
    //float timePassed = 0f;
    // highscore
    public TextMeshProUGUI highScoreText;
    // collectible counter
    public TextMeshProUGUI collectibleScoreText;


    void Start()
    {
        highScoreText.text = "Your record: " + PlayerPrefs.GetInt("highScore", 0).ToString();

        collectibleScoreText.text = "Hearts: " + "heart count here";
    }


    // Update is called once per frame
    void Update()
    {
        // when screen is clicked for the first time, game starts
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            // adding seconds to timer
            //timePassed += Time.deltaTime;

            // spawnauksen nopeutus
            // EI TOIMI !!!!! mut miksiiii :(
            //if(timePassed > 5f)
            //{
            // make spawnRate smaller?
            //spawnRate = spawnRate * 0.5f;


            // resetting the timer
            //timePassed = 0f;
            //}

            //starts spawning falling objects
            StartSpawning();

            gameStarted = true;


            // removes "tap to start" text when game starts
            //startText.SetActive(false);

        }


    }

    // OBSTACLE SPAWNER

    private void StartSpawning()
    {
        // calls function again and again at a certain rate
        // InvokeRepeating(function name, when it starts to call function, spawnrate)
        //spawnRate = 0.3f;
        // spawnrate 
        //if (Time.time % 5 == 0)
        //{
        //    spawnRate = spawnRate * 0.5f;
        //}

        // EI TOIMI :(
        //if (timePassed > 5f)
        //{
            // make spawnRate smaller?
          //  spawnRate = 0.3f;

            // resetting the timer
            //timePassed = 0f;
        //}

        InvokeRepeating("SpawnObstacle", 0.5f, spawnRateObstacle);

        InvokeRepeating("SpawnCollectible", 1.0f, spawnRateCollectible);

    }

    private void SpawnObstacle()
    {

        // creating a spawn position
        Vector3 spawnPos = spawnPoint.position;

        // creating a random x position for spawn position
        spawnPos.x = Random.Range(-maxX, maxX);

        // instantiating the obstacle at the random spawn position
        // Instantiate(object, position, rotation)
        // default rotation = Quaternion.identity, because we don't need any external rotations
        Instantiate(obstacle, spawnPos, Quaternion.identity);

        // increments score value
        score++;
        // stores score value to scoreText (=the UI element) so it changes when needed
        scoreText.text = score.ToString();

        // highscore
        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "Your record: " + score.ToString();
        }



    }

    private void SpawnCollectible()
    {
        // creating a spawn position
        Vector3 spawnPos = spawnPoint.position;

        // creating a random x position for spawn position
        spawnPos.x = Random.Range(-maxX, maxX);

        // instantiating the collectible at the random spawn position
        Instantiate(collectible, spawnPos, Quaternion.identity);

    }







}

