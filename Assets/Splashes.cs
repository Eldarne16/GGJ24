using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splashes : MonoBehaviour
{
    public Image IMMATURE;
    public Image NOAI;
    bool isRunning = false;
    float elapsedTime;
    Color ImmatureColor;
    Color NOAIColor;
    public Camera cam;

    [SerializeField]
    AudioSource _audioSource;
    [SerializeField]
    AudioClip _ratedI;
    [SerializeField]
    AudioClip _noAI;

    enum State { start, immature, immatureFade, ai, aiFade }
    State _state = State.start;
    private void Start()
    {
        
        
        
        
        isRunning = true;
        IMMATURE.color = Color.clear;
        NOAI.color = Color.clear;
        elapsedTime = 0;
        ImmatureColor = new Color(0.9f, 0.3f, 0.75f);
        NOAIColor = new Color(34f/255f, 32f/255f, 43f/255f);
        cam.backgroundColor = NOAIColor;
    }

    private void Update()
    {
        if(isRunning)
        {
            elapsedTime += Time.deltaTime;
        }

        if(elapsedTime > 0.6f && _state == State.start)
        {
            _state = State.immature;
            StartCoroutine(WaitAndPlaySound(_ratedI));
            StartCoroutine(ColorLerp(NOAIColor, ImmatureColor));
            StartCoroutine(FadeIn(IMMATURE));
        }
        if(elapsedTime > 3.6f && _state == State.immature)
        {
            _state = State.immatureFade;
            StartCoroutine(FadeOut(IMMATURE));
        }
        if (elapsedTime > 7.6f && _state == State.immatureFade)
        {
            _state = State.ai;
            StartCoroutine(WaitAndPlaySound(_noAI));
            StartCoroutine(ColorLerp(ImmatureColor, NOAIColor));
            StartCoroutine(FadeIn(NOAI));
        }
        if (elapsedTime > 10.6f && _state == State.ai)
        {
            _state = State.aiFade;
            StartCoroutine(FadeOut(NOAI));
        }
        if(elapsedTime>14)
        {

            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator FadeIn(Image _image)
    {
        for (float ft = 0f; ft < 3; ft += 0.05f)
        {

            _image.color = new Color(1, 1, 1, ft/3);
            yield return null;
        }
    }
    IEnumerator FadeOut(Image _image)
    {
        for (float ft = 1f; ft >= 3; ft -= 0.05f)
        {

            _image.color = new Color(1, 1, 1, ft/3);
            yield return null;
        }
    }

    IEnumerator WaitAndPlaySound(AudioClip clip)
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("yo");
        _audioSource.clip = clip;
        _audioSource.Play();
        yield return null;
    }

    IEnumerator ColorLerp(Color _startColor, Color _endColor)
    {
        for (float ft = 0f; ft < 3; ft += 0.05f)
        {

            cam.backgroundColor = Color.Lerp(_startColor,_endColor,ft/3);
            yield return null;
        }
    }
}
