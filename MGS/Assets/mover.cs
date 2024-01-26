using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{

    public float speed;
    public float lifespan;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = -transform.right * 2*(speed);

        Destroy(gameObject, lifespan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
