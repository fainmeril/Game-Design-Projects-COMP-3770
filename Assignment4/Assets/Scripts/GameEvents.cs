using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Random=UnityEngine.Random; //Solves ambiguous reference issue

//TODO:
//1. Raycasting to delete a bubble on click -- DONE
//2. Make the spawn frequency increase over time (frequency number needs to decrease) -- DONE
//3. Save the score to a playerpref if its greater than the playerprefs current highscore on game end
//4. Add a back button to go back to the main menu -- implemented but not functioning properly

public class GameEvents : MonoBehaviour
{
    public GameObject bubble; //Bubble prefab
    public Button back;
    public Text stats; //Text object for stats
    public Vector3[] spawnpoints = new Vector3[8]; //Holds all potential spawn points to be chosen from randomly (4 corners, middle of 4 edges)
    private int popped = 0; //Number missed
    private int missed = 0; //Number popped
    private float frequency = 3f; //Frequency in seconds
    private float starttime;

    private float timer = 0f;
    private float gameTime = 0f;
    private float gameLoadTime = 0f;

    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bubble, spawnpoints[Random.Range(0, 8)], Quaternion.identity);
        starttime = Time.time;
        gameLoadTime = Time.time;
        back.onClick.AddListener(TaskOnClick);
        back.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        timer += Time.deltaTime;
        if (timer >= 3) { //decrease frequency of spawns every 3 seconds.
            frequency -= 0.1f;
            timer = 0;
        }
        //Check if the game should be ended, else do the spawning and such
        if (missed >= 10){
            //Setting Highscore
            if(PlayerPrefs.GetInt("BubblePopper_HighScore", 0) < popped)
                PlayerPrefs.SetInt("BubblePopper_HighScore", popped);
            back.gameObject.SetActive(true);
        } 
        else {
            gameTime = Time.time; //Only count time during game
            deleteOnClick(); //function to delete/pop bubbles
            if(starttime + frequency < Time.time){
                starttime = Time.time;
                Instantiate(bubble, spawnpoints[Random.Range(0, 8)], Quaternion.identity);
            }
        }
        stats.text = "Time: " + Math.Round(gameTime- gameLoadTime, 2) + "\nPopped: " + popped + "\nMissed: " + missed;
    }

    //Incrementer for missed
    public void AddMissed() {
        if(missed < 10) //Stops overcounting leftover bubbles
            missed++;
    }

    //Incrementer for popped (this one may not be needed, but if the ray casting is done in a different script then use this)
    public void AddPopped() {
        if(missed < 10) //Stops user from clicking after the game has ended
            popped++;
    }

    public void deleteOnClick() {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                SphereCollider sc = hit.collider as SphereCollider;
                if (sc != null)
                {
                    Destroy(sc.gameObject);
                    popped++;
                }
            }
        }
    }
    void TaskOnClick() //Button currently not working, not sure why
    {
        //Load the main menu (commented out for now)
        Debug.Log("back to main menu");
        SceneManager.LoadScene("MainMenu");
    }

}
