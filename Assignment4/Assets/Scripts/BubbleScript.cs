using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    
    private GameObject target;
    private GameEvents gameevents;
    private Rigidbody rb;
    private float thrust = 300;
    private float startTime;
    private float angleoffset = 20;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target"); //Prefabs can't remember public objects
        gameevents = target.GetComponent<GameEvents>(); //GameEvents script reference
        rb = gameObject.GetComponent<Rigidbody>(); //RigidBody reference
        startTime = Time.time; //Time created for each bubble
        //Make sure the bubble is always going to the middle
        transform.LookAt(target.transform); //point toward the center
        transform.Rotate(Random.Range(-angleoffset, angleoffset), 0f, 0f); //some variance on initial direction
        rb.AddForce(transform.forward*thrust); //off she goes
    }

    // Update is called once per frame
    void Update()
    {
        //despawns bubble after 10 seconds
        if(startTime+10f < Time.time)
            Despawn();
    }
    
    //Differentiate between destroyed from despawning and clicking

    //Will count up the "missed" property in the GameEvents Script
    void Despawn(){
        gameevents.AddMissed();
        Destroy(gameObject);
    }

    //Will count up the "popped" property in the GameEvents Script (Maybe useful, if needed can be changed to public)
    void Clicked(){
        Destroy(gameObject);
    }
}
