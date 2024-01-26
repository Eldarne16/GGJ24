using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody2D : MonoBehaviour
{
    public FauxGravityAttractor2D attractor;
    private Transform myTransform;

    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        myTransform = transform;
    }

    
    void Update()
    {
        attractor.Attract(myTransform);
    }
}
