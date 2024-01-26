using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{

    Camera mainCam;
    Rigidbody rb;
    public ForceMode forceMode;
    Vector3 EulerRot;
    public float mouseSensitivity;
    GameObject targetHolder;
    Transform target;

    Vector3 V3up;

    float yPos;

    public Texture2D cursorTexture;
    public Vector2 cursorHotspot;
    public CursorMode cursorCursorMode;

    // Start is called before the first frame update
    void Start()
    {
        targetHolder = new GameObject();
        target = targetHolder.transform;
        targetHolder.transform.SetParent(gameObject.transform);
        targetHolder.transform.localPosition = new Vector3(0, 0, 0);
        targetHolder.transform.name = "Target";
        Cursor.visible = false;
        yPos = gameObject.transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
    

        gameObject.transform.Translate(0, 0, Input.GetAxis("Vertical")*0.06f, Space.Self);
        gameObject.transform.Translate(Input.GetAxis("Horizontal") * 0.06f, 0, 0, Space.Self);


        gameObject.transform.Rotate(0,- Input.GetAxis("Mouse X") * mouseSensitivity,0, Space.Self);


        if (Input.GetKey("escape")) { Cursor.visible = true; };
    }
}
