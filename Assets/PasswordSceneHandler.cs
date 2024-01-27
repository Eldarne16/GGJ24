using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PasswordSceneHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject infoBubble;
    [SerializeField]
    TMP_InputField _passwordInputField;
    Infos infos;
    private void Awake()
    {
        infos = Infos.instance;
        infos.SetHandler(this);
    }

    private void Start()
    {
        if (infoBubble != null)
        {
            infoBubble.SetActive(false);
        }

        if (_passwordInputField != null)
        {
            // Subscribe to the onSubmit event
            _passwordInputField.onEndEdit.AddListener(HandleSubmit);

            // Optionally, subscribe to the onValueChanged event to detect every keystroke
            // inputField.onValueChanged.AddListener(HandleChange);
        }
    }

    private void OnDestroy()
    {
        infos.UnSetHandler(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("zazr");
        if (eventData.pointerEnter == _passwordInputField.gameObject)
        {
            Debug.Log("zazr2");
            // Show the info bubble when the mouse pointer enters the input field
            infoBubble.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("zazr");
        // Hide the info bubble when the mouse pointer exits the input field
        infoBubble.SetActive(false);
    }

    private void HandleSubmit(string text)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Enter pressed, input field value: " + text);
            // Your submit logic here
        }
    }

    private void HandleChange(string text)
    {
        Debug.Log("Current input field value: " + text);
        // Your change logic here
    }
}
