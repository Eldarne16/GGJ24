using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontFallToYourDeathController : MonoBehaviour
{
    private SceneHandler _sceneHandler;
    private void Awake()
    {
        _sceneHandler = Infos.instance.GetHandler<SceneHandler>();
    }

    public void End()
    {
        StartCoroutine(WaitForEnd());
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitForSeconds(3f);
        _sceneHandler.NextLevel(false);
    }



}
