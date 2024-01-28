using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTASCRIPT : MonoBehaviour
{

    Infos _infos;
    SceneHandler _sceneHandler;

    public GameObject buttonObject;

    UnityEngine.UI.Text text;


    bool _hasWon;

    private void Awake()
    {
        _infos = Infos.instance;
        _sceneHandler = _infos.GetHandler<SceneHandler>();

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
            text.color = Color.red * 0.8f;
            text.text = "WHAT DID I TOLD YOU !!??";
        }

        yield return new WaitForSeconds(2);
        _sceneHandler.NextLevel(_hasWon);

    }


    float elapsedTime = 0;
    
    bool _hasClicked = false;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= 30)
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

    public void DONTCLICK()
    {
        Debug.Log("Clicked");
        _hasClicked = true;
        buttonObject.transform.Translate(0, 0, -0.2f,Space.Self); 
    }
}
