using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTASCRIPT : MonoBehaviour
{

    Infos _infos;


    public GameObject REDbutton;
    public GameObject YELLOWbutton;
    public GameObject GREENbutton;
    public GameObject BLUEbutton;
    public GameObject PURPLEbutton;

    public Button RED;
    public Button YELLOW;
    public Button GREEN;
    public Button BLUE;
    public Button PURPLE;

    public Image SAYMONSI;
    TripleOscillator TO;

    UnityEngine.UI.Text text;


    bool _hasWon;

    private void Awake()
    {
        _infos = Infos.instance;

        text = FindObjectOfType<UnityEngine.UI.Text>();
        TO = FindObjectOfType<TripleOscillator>();

        RED.onClick.AddListener(DONTCLICKRED);
        YELLOW.onClick.AddListener(DONTCLICKYELLOW);
        GREEN.onClick.AddListener(DONTCLICKGREEN);
        BLUE.onClick.AddListener(DONTCLICKBLUE);
        PURPLE.onClick.AddListener(DONTCLICKPURPLE);
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

    public void DONTCLICKRED()
    {
        if (SAYMONSISTARTED != true)
        {
            if (_hasClicked != true)
            {
                Debug.Log("Clicked RED");
                elapsedTime = 17;
                _hasClicked = true;
                StartCoroutine(ButtonPressed(REDbutton,0));
                //UnityEngine.UI.Button[] buttons = FindObjectsOfType<UnityEngine.UI.Button>();
                //foreach(UnityEngine.UI.Button b in buttons)
                //{
                //    b.interactable = false;
                //}
            }
        }
        else
        {
            currentValue = 0;
            StartCoroutine(ButtonPressed(REDbutton,0));
        }
    }

    public void DONTCLICKYELLOW()
    {
        if (SAYMONSISTARTED != true)
        {
            if (_hasClicked != true)
            {
                Debug.Log("Clicked YELLOW");
                elapsedTime = 17;
                _hasClicked = true;
                StartCoroutine(ButtonPressed(YELLOWbutton,1));
            }
        }
        else
        {
            currentValue = 1;
            StartCoroutine(ButtonPressed(YELLOWbutton,1));
        }

    }

    public void DONTCLICKGREEN()
    {
        if (SAYMONSISTARTED != true)
        {
            if (_hasClicked != true)
            {
                Debug.Log("Clicked GREEN");
                elapsedTime = 17;
                _hasClicked = true;
                StartCoroutine(ButtonPressed(GREENbutton,2));

            }
        }
        else
        {
            currentValue = 2;
            StartCoroutine(ButtonPressed(GREENbutton,2));
        }
    }

    public void DONTCLICKBLUE()

    {
        if (SAYMONSISTARTED != true)
        {
            if (_hasClicked != true)
            {

                elapsedTime = 17;
                _hasClicked = true;
                StartCoroutine(ButtonPressed(BLUEbutton,3));
            }
        }
        else
        {
            currentValue = 3;
            StartCoroutine(ButtonPressed(BLUEbutton,3));
        }
    }

    public void DONTCLICKPURPLE()
    {
        if (SAYMONSISTARTED != true)
        {
            if (_hasClicked != true)
            {
                _hasClicked = true;
                SAYMONSISTARTED = true;

                elapsedTime = -300;
                _hasClicked = true;
                StartCoroutine(ButtonPressed(PURPLEbutton,4));
                List<int> indices = new List<int>();
                indices.Add((int)Random.Range(0, 5));
                SAYMONSIGAME(indices);
            }
        }
        else
        {
            currentValue = 4;
            StartCoroutine(ButtonPressed(PURPLEbutton,4));
        }
    }
  
    int currentValue;
    bool SAYMONSISTARTED = false;
    bool LOSTSAYMONSI = false;
    List<int> SAYMONSIINDICES = new List<int>();
    float SAYMONSISPEED = 1.6f;
    void SAYMONSIGAME(List<int> indices)
    {
     
        

        StartCoroutine(SimonSequence(SAYMONSISPEED));
        //for(int i = 0;i<indices.Count;i++)
        //{
        //    StartCoroutine(LIGHTBUTTON((ColorSAYMONSI)indices[i], SAYMONSISPEED));
        //}
        
        SAYMONSISPEED -= 0.05f;
    }
    IEnumerator ButtonPressed(GameObject button, int buttonIndex)
    {
        StartCoroutine(TO.PLAYSOUND(buttonIndex, 0.2f));
        button.transform.Translate(0, 0, -0.2f, Space.Self);
        yield return new WaitForSeconds(0.2f);
        button.transform.Translate(0, 0, 0.2f, Space.Self);


    }

    IEnumerator SimonSequence(float duration)
    {
        while (true)
        {
            // Generate a random color index and add it to the sequence
            text.text = "I SAY :";
            int randomIndex = Random.Range(0, System.Enum.GetValues(typeof(ColorSAYMONSI)).Length);
            SAYMONSIINDICES.Add(randomIndex);

            // Show the sequence to the player
            foreach (int index in SAYMONSIINDICES)
            {
                StartCoroutine(LIGHTBUTTON((ColorSAYMONSI)index,SAYMONSISPEED));
                yield return new WaitForSeconds(duration);
            }
            text.text = "YOU SAY :";
            // Wait for player input
            yield return StartCoroutine(PlayerInput());
        }
    }

    IEnumerator PlayerInput()
    {
        int currentIndex = 0;
        while (currentIndex < SAYMONSIINDICES.Count)
        {
            // Check if player input matches the current color in the sequence
            if (currentValue == 0 && SAYMONSIINDICES[currentIndex] == (int)ColorSAYMONSI.RED ||
                currentValue == 1 && SAYMONSIINDICES[currentIndex] == (int)ColorSAYMONSI.YELLOW ||
                currentValue == 2 && SAYMONSIINDICES[currentIndex] == (int)ColorSAYMONSI.GREEN ||
                currentValue == 3 && SAYMONSIINDICES[currentIndex] == (int)ColorSAYMONSI.BLUE ||
                currentValue == 4 && SAYMONSIINDICES[currentIndex] == (int)ColorSAYMONSI.PURPLE)
            {
                text.text = "Correct!";
                currentIndex++;
            }
            else
            {
                text.text = "Incorrect!";
                // Handle incorrect input (e.g., game over logic)
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator LIGHTBUTTON(ColorSAYMONSI color, float duration)
    {
        Color initColor = Color.clear;
        Color actualColor = new Color();
        switch(color)
        {
            case ColorSAYMONSI.RED:
                actualColor = Color.red;
                break;
            case ColorSAYMONSI.YELLOW:
                actualColor = Color.yellow;
                break;
            case ColorSAYMONSI.GREEN:
                actualColor = Color.green;
                break;
            case ColorSAYMONSI.BLUE:
                actualColor = Color.blue;
                break;
            case ColorSAYMONSI.PURPLE:
                actualColor = Color.magenta;
                break;
        }
        SAYMONSI.color = actualColor;
        StartCoroutine(TO.PLAYSOUND((int)color, duration));
        yield return new WaitForSeconds(duration);
        SAYMONSI.color = initColor;
    }

    public enum ColorSAYMONSI
    {
        RED = 0,
        YELLOW = 1,
        GREEN = 2,
        BLUE = 3,
        PURPLE = 4

    }
}


