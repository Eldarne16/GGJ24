using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTASCRIPT : MonoBehaviour
{

    Infos _infos;


    public GameObject REDbutton;
    public GameObject YELLOWbutton;
    public GameObject GREENbutton;
    public GameObject BLUEbutton;
    public GameObject PURPLEbutton;

    UnityEngine.UI.Text text;


    bool _hasWon;

    private void Awake()
    {
        _infos = Infos.instance;

        text = FindObjectOfType<UnityEngine.UI.Text>();
    }


    IEnumerator LevelEnd()
    {

        if(_hasWon == true)
        {
            text.color = Color.cyan + (Color.blue * 0.5f);
            text.text = "Well Done !";
        }
        else
        {
            elapsedTime = 27;
            text.color = Color.red * 0.8f;
            text.text = "WHAT DID I TOLD YOU !!??";
        }

        yield return new WaitForSeconds(2);
        _infos.GetHandler<SceneHandler>().NextLevel(_hasWon);

    }
    

    float elapsedTime = 0;
    
    bool _hasClicked = false;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 20)
        {
            if(_hasClicked == true)
            {
                _hasWon = false ;

            }
            else
            {
                _hasWon = true;
            }


            StartCoroutine("LevelEnd");
        }
    }

    public void DONTCLICKRED()
    {
        Debug.Log("Clicked RED");
        elapsedTime = 17;
        _hasClicked = true;
        REDbutton.transform.Translate(0, 0, -0.2f,Space.Self); 
    }

    public void DONTCLICKYELLOW()
    {
        Debug.Log("Clicked YELLOW");
        elapsedTime = 17;
        _hasClicked = true;
        YELLOWbutton.transform.Translate(0, 0, -0.2f, Space.Self);
    }

    public void DONTCLICKGREEN()
    {
        Debug.Log("Clicked GREEN");
        elapsedTime = 17;
        _hasClicked = true;
        GREENbutton.transform.Translate(0, 0, -0.2f, Space.Self);
    }

    public void DONTCLICKPURPLE()
    {
        Debug.Log("Clicked PURPLE");
        elapsedTime = 17;
        _hasClicked = true;
        PURPLEbutton.transform.Translate(0, 0, -0.2f, Space.Self);
    }
    public void DONTCLICKBLUE()
       
    {
        Debug.Log("Clicked BLUE");
        elapsedTime = 17;
        _hasClicked = true;
        BLUEbutton.transform.Translate(0, 0, -0.2f, Space.Self);
    }
}
