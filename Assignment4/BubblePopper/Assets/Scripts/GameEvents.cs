using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

using Random=UnityEngine.Random; //Solves ambiguous reference issue

//TODO:
//1. Raycasting to delete a bubble on click
//2. Make the spawn frequency increase over time (frequency number needs to decrease)
//3. Save the score to a playerpref if its greater than the playerprefs current highscore on game end
//4. Add a back button to go back to the main menu

public class GameEvents : MonoBehaviour
{
    public GameObject bubble; //Bubble prefab
    public Text stats; //Text object for stats
    public Vector3[] spawnpoints = new Vector3[8]; //Holds all potential spawn points to be chosen from randomly (4 corners, middle of 4 edges)
    private int popped = 0; //Number missed
    private int missed = 0; //Number popped
    private float frequency = 3f; //Frequency in seconds
    private float starttime;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bubble, spawnpoints[Random.Range(0, 8)], Quaternion.identity);
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the game should be ended, else do the spawning and such
        if(missed >= 10){

        } else {
            if(starttime + frequency < Time.time){
                starttime = Time.time;
                Instantiate(bubble, spawnpoints[Random.Range(0, 8)], Quaternion.identity);
            }
        }
        stats.text = "Time: " + Math.Round(Time.time, 2) + "\nPopped: " + popped + "\nMissed: " + missed;
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

}
