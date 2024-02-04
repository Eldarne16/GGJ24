using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatThePussyHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _picture;

    public void HasWon()
    {
        StartCoroutine(WaitForEnd(true));
    }

    public void HasLost()
    {
        StartCoroutine(WaitForEnd(false));
    }

    IEnumerator WaitForEnd(bool hasWon)
    {
        if(hasWon) {
            GetComponent<AudioSource>().Play();
            _picture.SetActive(true);
            yield return new WaitForSeconds(3);
            Infos.instance.GetHandler<SceneHandler>().NextLevel(true);
        }
        else
        {
            Infos.instance.GetHandler<SceneHandler>().NextLevel(false);
        }
    }
}
