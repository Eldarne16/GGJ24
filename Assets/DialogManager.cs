using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text dialogText;
    public float typingSpeed = 0.05f;

    private string[] pages;
    private int currentPage;
    private bool isTyping;
    private bool _hasWon = true;

    private Infos _infos;
    private SceneHandler _sceneHandler;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _infos = Infos.instance;
        _sceneHandler = _infos.GetHandler<SceneHandler>();
    }
    
    private void Start()
    {
        pages = new string[]
        {
            "There are actually two Bells of Awakening.", "One's up above, in the Undead Church.", "The other is far, far below, in the ruins."
        };

        currentPage = 0;
        isTyping = false;

        //ShowCurrentPage();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ShowCurrentPage();
        }
    }

    public void Next()
    {
        if(isTyping)
        {
            isTyping=false;
            _hasWon = false;
        }
        currentPage++;

        if (currentPage < pages.Length)
        {
            StopCoroutine(_currentCoroutine);
            ShowCurrentPage();
        }
        else
        {
            _sceneHandler.NextLevel(_hasWon);
        }

    }

    private void ShowCurrentPage()
    {
        dialogText.text = "";
        _currentCoroutine = StartCoroutine(TypeText(pages[currentPage]));
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;

        for (int i = 0; i < text.Length; i++)
        {
            dialogText.text += text[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}
