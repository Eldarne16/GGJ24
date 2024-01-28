using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatThePussyHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _pictures;
    public void HasWon()
    {
        Infos.instance.GetHandler<SceneHandler>().NextLevel(true);
    }

    public void HasLost()
    {
        Infos.instance.GetHandler<SceneHandler>().NextLevel(false);
    }

    IEnumerator WaitForEnd(bool hasWon)
    {
        yield return new WaitForSeconds(3);
    }
}
