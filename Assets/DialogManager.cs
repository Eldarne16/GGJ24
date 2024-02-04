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

        ShowCurrentPage();
    }
<<<<<<< HEAD
=======

   
    
>>>>>>> 29632e9bf62f2a77de90d7b5035a1d686a256089

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
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
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
