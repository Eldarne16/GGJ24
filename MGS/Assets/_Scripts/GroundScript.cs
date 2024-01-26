using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{

    [SerializeField]
    float HorizontalScrollCull;

    GameObject mainCam;
    

    Vector2 objectPosition;
    Vector2 camPosition;

    float distanceFromCam;

    SpriteRenderer spriteRenderer;


    /*void Start()
    {
        mainCam = GameObject.Find("Main Camera");
        camPosition = mainCam.transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectPosition = gameObject.transform.position;
    }

   
    void Update()
    {
        //distanceFromCam = Vector2.Distance(gameObject.transform.position, camPosition);
        distanceFromCam = objectPosition.x - camPosition.x;
        Debug.Log(distanceFromCam);
        if (distanceFromCam >= HorizontalScrollCull)
        {
            spriteRenderer.enabled = false;
        }
        else spriteRenderer.enabled = true;
    }*/

    void OnBecameInvisible()
    {
        enabled = false;
    }

    void OnBecameVisible()
    {
        enabled = true;
    }
}
