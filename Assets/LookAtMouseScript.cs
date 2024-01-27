using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouseScript : MonoBehaviour
{
    Camera mainCam;
    public GameObject mainCamObj;

    public GameObject gunObject;
    private void Start()
    {
        mainCam = mainCamObj.GetComponent<Camera>();
    }

    //Vector3 direction =  mainCam.ScreenToWorldPoint(Input.mousePosition) - gunObject.transform.position;
    //gameObject.transform.rotation = Quaternion.Euler(direction);

    //Vector3 mousePos = Input.mousePosition;
    //Vector3 aim = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCam.nearClipPlane));
    //gameObject.transform.LookAt(aim, -Vector3.up);


    void Update()
    {
        Vector3 mousePosition;
        mousePosition = mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));
        Vector3 direction = mousePosition - new Vector3(-2.03f,-0.01f,0);
        direction.z = 0; // Ensure the sprite stays in the 2D plane.

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }




}
