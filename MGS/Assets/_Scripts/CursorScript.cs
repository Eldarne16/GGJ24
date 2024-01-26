using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class CursorScript : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 screenPoint;
    private Vector3 offset;
    public Vector2 hotspot;

    public Texture2D cursorT;


    public GameObject handedGO;
    public Image handedDraw;

    public GameObject infoPanel;
    public Text[] panelText;
    bool isPanelSet = false;


    void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        hotspot = new Vector2(offset.x, offset.y);
        Cursor.SetCursor(cursorT, hotspot, CursorMode.ForceSoftware);
        
        
        
        
            panelText[0] = infoPanel.GetComponentInChildren<Text>();
        panelText[1] = GameObject.Find("Info").GetComponent<Text>();

    }


    void Update()
    {


        if (handedGO != null && Input.GetButtonDown("LMB"))
        {

            //handedDraw.material.SetTexture ("_MainTex",handedGO.GetComponent<TileProperties>().icon);
            handedDraw.sprite = handedGO.GetComponent<TileProperties>().Icon;
            //if (Input.GetButtonDown("RMB")) { isRotating = !isRotating; }
        }
       
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            TileProperties TS = hit.collider.gameObject.GetComponent<TileProperties>();
           // Debug.Log(hit.point);
          
                setPanel(hit, TS);
            
        }
      
         

    }
    void setPanel(RaycastHit hit, TileProperties TS)
    {
        
        panelText[0].text = TS.tileName;
        panelText[1].text = "Bien bien bien " + TS.pos;

    }
}