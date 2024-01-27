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

    private Coroutine _currentCoroutine;

    private void Start()
    {
        pages = new string[]
        {
            "This is the first page of text. Press return to continue.",
            "This is the second page of text. Press return to continue.",
            "This is the third and final page of text. Press return to finish."
        };

        currentPage = 0;
        isTyping = false;

        ShowCurrentPage();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentPage++;

            if (currentPage < pages.Length)
            {
                StopCoroutine(_currentCoroutine);
                ShowCurrentPage();
            }
            else
            {
                // All pages displayed, you can add logic here for what to do next.
                Debug.Log("All pages displayed. Add logic for next steps.");
            }
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
