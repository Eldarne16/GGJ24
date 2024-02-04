using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    bool _destroy = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        if(_destroy)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(3f);
        _destroy = true;
    }
}
