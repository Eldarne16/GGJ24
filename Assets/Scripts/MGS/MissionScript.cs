using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MissionScript : MonoBehaviour
{

    Infos _infos;
    SceneHandler _sceneHandler;

    bool _hasWon;

    public void WinOrLose(bool hasWon)
    {
        _hasWon = hasWon;
        StartCoroutine(LevelEnd());

    }

    private void Awake()
    {
        _infos = Infos.instance;
        _sceneHandler = _infos.GetHandler<SceneHandler>();
    }

    [SerializeField]
    FullScreenMode fullScreenMode;
    [SerializeField]
    private float TimeValue;
    [SerializeField]
    private int FrameCount;
    [SerializeField]
    private float timeSpent;

    Camera mainCam;
    Transform cameraZPosition;
    Transform centerPosition;
    Vector3 targetDirection;
    bool isCamMoving = false;
    

    [SerializeField]
    float mouseSensitivity;
    float elapsedTime = 0;

 
    public bool followAgent = true;

    public int nbrAgents;
    public List<GameObject> AgentPrefabs = new List<GameObject>();

    List<NavMeshAgent> agentsList = new List<NavMeshAgent>();
    int agentsListIndex = 0;
    int previousAgentsListIndex;

    private int fingerID;
    public EventSystem eventSystem;

    Vector3 mousePos;

    float camOrthPos = 7f;
    void Start()
    {
        mainCam = GameObject.Find("Camera").GetComponent<Camera>();
        Screen.SetResolution(1920, 1080, fullScreenMode);
        FrameCount = 0;
        TimeValue = 1 * Time.deltaTime;
        cameraZPosition = mainCam.transform;
        centerPosition = GameObject.Find("SpawnPoint0").transform;
        targetDirection = new Vector3(0, 0, 0) - cameraZPosition.position;




        for (int i = 0; i < nbrAgents; i++)
        {
            GameObject newAgent = Instantiate(AgentPrefabs[i], GameObject.Find("SpawnPoint" + i.ToString()).transform.position, Quaternion.LookRotation(new Vector3(0,0,1)));
            newAgent.name = "Agent" + i.ToString();
           // newAgent.transform.position = GameObject.Find("SpawnPoint" + i.ToString()).transform.position;
            agentsList.Add(newAgent.GetComponent<NavMeshAgent>());

        }

        //textName = GameObject.Find("Name").GetComponent<Text>();
        //UIIcon = GameObject.Find("Icon").GetComponent<Image>();
        //textDesc = GameObject.Find("Description").GetComponent<Text>();
        //textStats = GameObject.Find("Stats").GetComponent<Text>();

        //followToggle = GameObject.Find("FollowToggle").GetComponent<Toggle>();

        //eventSystem = GameObject.Find("Canvas").GetComponent<EventSystem>();

        //Invoke("ChangePanelContent", 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        camOrthPos += Input.GetAxis("Mouse ScrollWheel");
        camOrthPos = Mathf.Clamp(3, 10, camOrthPos);
        //cameraZPosition.Translate(0, 0,Input.GetAxis("Mouse ScrollWheel"));
        mainCam.orthographicSize = camOrthPos;
            if(cameraZPosition.transform.position.y>=50)
                {
            float camZ = cameraZPosition.position.y;
                camZ = 50; }
            else if(cameraZPosition.transform.position.y <=5)
        { float camZ = cameraZPosition.position.y;
            camZ = 5;
        } else

        if (Input.GetMouseButton(2))
        {

            //followToggle.isOn = false;
            centerPosition.Translate(-Input.GetAxis("Mouse X"), 0, -Input.GetAxis("Mouse Y"), Space.Self);

            Debug.DrawLine(centerPosition.position, new Vector3(0, 0, 0));

        }

        if (Input.GetMouseButton(1))
        {
            centerPosition.Rotate(Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0, Space.Self);
            centerPosition.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0, Space.World);
        }

        
            CameraFollow();
        
        if(elapsedTime >= 30)
        {
            WinOrLose(true);
        }
        //if (Input.GetKeyDown(KeyCode.C) && isCamMoving ==false)
        //{
        //    previousAgentsListIndex = agentsListIndex;
        //    agentsListIndex++;


        //    if (agentsListIndex > agentsList.Count - 1)
        //    { agentsListIndex = 0; }
        //    // ChangePanelContent();
        //    this.StartCoroutine(this.MoveCamera());
        //}

        //if (Input.GetKeyDown(KeyCode.Keypad1) && isCamMoving == false )
        //{
        //    previousAgentsListIndex = agentsListIndex;
        //    agentsListIndex = 0;
        //    ChangePanelContent();
        //    this.StartCoroutine(this.MoveCamera());
        //    //MoveCamera(Mathf.Lerp(agentsList[previousAgentsListIndex].transform.position, agentsList[agentsListIndex].transform.position,);

        //}
        //if (Input.GetKeyDown(KeyCode.Keypad2) && isCamMoving == false )
        //{
        //    previousAgentsListIndex = agentsListIndex;
        //    agentsListIndex = 1;
        //    ChangePanelContent();
        //    this.StartCoroutine(this.MoveCamera());
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad3) && isCamMoving == false )
        //{
        //    previousAgentsListIndex = agentsListIndex;
        //    agentsListIndex = 2;
        //    ChangePanelContent();
        //    this.StartCoroutine(this.MoveCamera());
        //}
        //if (Input.GetKeyDown(KeyCode.Keypad4) && isCamMoving == false )
        //{
        //    previousAgentsListIndex = agentsListIndex;
        //    agentsListIndex = 3;
        //    ChangePanelContent();
        //    this.StartCoroutine(this.MoveCamera());
        //}



        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (!eventSystem.IsPointerOverGameObject())
                {
                    mousePos = hit.point;

                    agentsList[0].destination = mousePos;
                }

            }
        }





        FrameCount++;
    }

    //void ChangePanelContent()
    //{
    //    textName.text = agentsList[agentsListIndex].GetComponent<agentProperties>().agentName;
    //    UIIcon.sprite = agentsList[agentsListIndex].GetComponent<agentProperties>().icon;
    //    textDesc.text = agentsList[agentsListIndex].GetComponent<agentProperties>().description;
    //    textStats.text = "Speed : " + agentsList[agentsListIndex].GetComponent<agentProperties>().speed.ToString() + "\n" + "Agility : " + agentsList[agentsListIndex].GetComponent<agentProperties>().agility.ToString() + "\n" + "Strength : " + agentsList[agentsListIndex].GetComponent<agentProperties>().strength.ToString() + "\n" + "Stamina : " + agentsList[agentsListIndex].GetComponent<agentProperties>().stamina.ToString();
    //}

 

    void CameraFollow()
    {
        Vector3 camPos = new Vector3(agentsList[0].transform.position.x, mainCam.transform.position.y, agentsList[0].transform.position.z);

        mainCam.transform.position = camPos;
    }


    //IEnumerator MoveCamera()
    //{
    //    float lerpTime = 0.0f;
    //    float waitTime = 0.25f;
       
        
    //    while(lerpTime <waitTime)
    //        {
    //        isCamMoving = true;
    //        centerPosition.position = Vector3.Lerp(agentsList[previousAgentsListIndex].transform.position, agentsList[0].transform.position, camCurve.Evaluate(lerpTime/waitTime));
    //        lerpTime += Time.deltaTime;
            
    //       yield return null;
    //    }
    //    isCamMoving = false;
        
    //    yield return null;
    //}


    IEnumerator LevelEnd()
    {

        Debug.Log("has won : " + _hasWon);
        yield return new WaitForSeconds(2);
        _sceneHandler.NextLevel(_hasWon);

    }

}
