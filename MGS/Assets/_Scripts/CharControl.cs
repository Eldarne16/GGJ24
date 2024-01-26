using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharControl : MonoBehaviour
{
    public float TimeValue;
    public int FrameCount;

    [SerializeField]
    float addForce;
    [SerializeField]
    float maxForce;

    CursorScript CS;
    Vector2 addedForce;
    Vector2 myPosition;
    Vector2 previousForce;

    Rigidbody2D RB;

    bool isCharging = false;
    float initDrag;

    int i = 0;


    bool isHit = false;

    [SerializeField]
    AnimationCurve timeSlowDownCurve;

    [SerializeField]
    AnimationCurve timeSpeedUpCurve;

    SpriteRenderer vignette;
    Color defaultColor;
    Color hitColor;

    Transform cameraZPosition;
    FauxGravityBody2D gravityBody;

    void Start()
    {
        gravityBody = GetComponent<FauxGravityBody2D>();
        FrameCount = 0;
        TimeValue = 1*Time.deltaTime;
        myPosition = gameObject.transform.position;
        CS = GameObject.Find("Cursor").GetComponent<CursorScript>();
        RB = GetComponent<Rigidbody2D>();
        initDrag = RB.drag;

        vignette = GameObject.Find("Vignette").GetComponent<SpriteRenderer>();
        defaultColor = new Color(0, 0, 0, 0.3f);
        hitColor = new Color(0.85f, 0.15f, 0, 0.5f);

        cameraZPosition = Camera.main.transform;
    }

    
    void Update()
    {
        cameraZPosition.Translate(0,0,Input.GetAxis("Mouse ScrollWheel"));
        if(Input.GetMouseButton(2))
        { cameraZPosition.Translate(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"),0); }
        FrameCount++;
        Debug.Log(FrameCount*TimeValue);
    }
    void LateUpdate()
    {
      
        myPosition = gameObject.transform.position;
       
    if (Input.GetMouseButtonDown(0))
        {
            isCharging = true;
            i = 20;
        }

        if (Input.GetMouseButton(0))
        {
            
                Time.timeScale = 0.3f;
            if (isCharging)
            {
                if (i >= maxForce)
                {
                    i = (int)maxForce;
                }
                else { i++; }

                // Debug.Log("MouseDown");
                //addedForce += new Vector2(addForce, addForce);

                addedForce = (myPosition - ((Vector2)Input.mousePosition) + new Vector2(Screen.width / 2, Screen.height / 2)).normalized;
            }
            //Debug.Log(addedForce);
        }
       

            if (Input.GetMouseButtonUp(0))
         {
            RB.drag = 500;
            Time.timeScale = 1.0f;
                
             Debug.Log("MouseUp" + addedForce + " || i : " + i);
            RB.drag = initDrag;
            RB.AddForce(addedForce*(i*addForce));
            previousForce = addedForce * (i * addForce);


            isCharging = false;
        }
            if(!isCharging)
        {

            addedForce = new Vector2(0, 0);
            i = 0;
        }
        
    
        

    }
    /* void OnMouseDown()
      {

          isCharging = true;
          Debug.Log("MouseDown");
          addedForce += new Vector2(addForce, addForce);


          Debug.Log("MouseDown");
          addedForce = (CS.hotspot - myPosition).normalized;
          isCharging = true;
      }

      void OnMouseUp()
      {

          isCharging = false;
          Debug.Log("MouseUp" + addedForce);
          RB.AddForce(addedForce);


          isCharging = false;
          Debug.Log("MouseUp  : " + addedForce);
          RB.AddForce(addedForce);



      }*/



    void OnCollisionEnter2D(Collision2D col)
    {
      
        if(col.gameObject.tag == "Badguy")
        {
            RB.drag = 5000;
            RB.freezeRotation = true;
            RB.freezeRotation = false;
            isHit = true;
            vignette.color = hitColor;
            Time.timeScale = 0.1f;
            StartCoroutine("WaitCoroutine");
            
        }
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Planet")
        {
            gravityBody.attractor = col.gameObject.GetComponent<FauxGravityAttractor2D>();
        }
    }

    IEnumerator WaitCoroutine()
    {
        for (int i = 0;i<7; i++)
        {
            vignette.color = Color.Lerp(hitColor, defaultColor, (float)i/12);
           // Time.timeScale = Mathf.Lerp(0.05f, 1, timeSpeedUpCurve.Evaluate(i / 12));
            // yield return new WaitForSeconds(0.15f);
           //timeSpeedUpCurve.Evaluate(112/i);
            
        }
        yield return isHit = false;
       
        //yield return Time.timeScale = 1.0f;
        yield return vignette.color = defaultColor;
    }


}
