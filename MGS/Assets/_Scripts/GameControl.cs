using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class GameControl : MonoBehaviour
{
    [SerializeField]
    FullScreenMode fullScreenMode;
    [SerializeField]
    private float TimeValue;
    [SerializeField]
    private int FrameCount;

    Transform cameraZPosition;
    Transform centerPosition;
    Vector3 targetDirection;

    [SerializeField]
    float mouseSensitivity;

    MissionScript MS;

    void Start()
    {
        Screen.SetResolution(1920, 1080, fullScreenMode);
        FrameCount = 0;
        TimeValue = 1*Time.deltaTime;
        cameraZPosition = Camera.main.transform;
        centerPosition = GameObject.Find("Center").transform;
        InvokeRepeating("TimeSpent", 0, 1);
        targetDirection = new Vector3(0,0,0) - cameraZPosition.position;

        MS = GetComponent<MissionScript>();

    }


    public void MoveCamera(Vector3 pos)
    {
        centerPosition.position = pos;
    }

    void Update()
    {
     

        cameraZPosition.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel"));
            if (Input.GetMouseButton(2))
            {
            MS.followAgent = false;
                centerPosition.Translate(-Input.GetAxis("Mouse X"),0, -Input.GetAxis("Mouse Y"),Space.Self);

                Debug.DrawLine(centerPosition.position, new Vector3(0,0,0));

            }

            if (Input.GetMouseButton(1))
        {
            centerPosition.Rotate(Input.GetAxis("Mouse Y")*mouseSensitivity, 0, 0,Space.Self);
            centerPosition.Rotate(0, Input.GetAxis("Mouse X")*mouseSensitivity, 0, Space.World);
        }


            FrameCount++;


    }





    void TimeSpent()
    {
        Debug.Log(FrameCount * TimeValue);
    }






    
    





}
