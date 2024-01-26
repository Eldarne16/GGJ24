using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    Transform tgt;
    // Start is called before the first frame update
    void Start()
    {
        tgt = GameObject.Find("Main Camera").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(tgt);
        

    }
}
