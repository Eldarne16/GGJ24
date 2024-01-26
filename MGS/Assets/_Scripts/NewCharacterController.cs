using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacterController : MonoBehaviour
{
    Rigidbody2D RB;
    public GameObject Planet;
    Vector2 attractorPosition;
    Vector2 gravityDirection;
    Vector2 horizontalInputDirection;
    void Start()
    {
        attractorPosition = Planet.transform.position;
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gravityDirection = (Vector2)transform.position - attractorPosition.normalized;
        
        RB.AddForce(new Vector2(Mathf.Cos(Input.GetAxis("Horizontal")),0));
    }
}
