using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThis : MonoBehaviour
{

    public bool killFromStart;
    // Start is called before the first frame update
    void Start()
    {
        if (killFromStart)
            KillThisObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillThisObject() {
        Destroy(this.gameObject);
    }
}
