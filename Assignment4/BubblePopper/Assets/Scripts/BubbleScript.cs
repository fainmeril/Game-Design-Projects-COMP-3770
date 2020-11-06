using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    
    private GameObject target;
    private Rigidbody rb;
    private float thrust = 200;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Target"); //Prefabs can't remember public objects
        rb = gameObject.GetComponent<Rigidbody>();
        startTime = Time.time;
        //Make sure the bubble is always going to the middle
        transform.LookAt(target.transform);
        rb.AddForce(transform.forward*thrust);
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime+10f < Time.time)
            Despawn();
    }
    
    //Differentiate between destroyed from despawning and clicking
    void Despawn(){
        Destroy(gameObject);
    }

    void Clicked(){
        Destroy(gameObject);
    }
}
