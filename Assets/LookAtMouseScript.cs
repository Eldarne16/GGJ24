using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouseScript : MonoBehaviour
{
    Camera mainCam;
    public GameObject mainCamObj;
    private void Start()
    {
        mainCam = mainCamObj.GetComponent<Camera>();
    }
    private void Update()
    {

        transform.LookAt(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.down);

    }
}
