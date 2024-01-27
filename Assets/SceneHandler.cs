using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private static SceneHandler _instance;

    //Scenes
    private string[] _sceneName = new string[] { "HeyListen_SCENE" };

    private Infos infos;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //Subscribe to infos
        infos = Infos.instance;
        infos.SetHandler(this);
    }

    public void LoadScene(string sceneName)
    {
        // Load the scene with the given name
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene(_sceneName[0]);
        }
    }

    private void OnDestroy()
    {
        infos.UnSetHandler(this);
    }

    public void NextLevel(bool hasWon)
    {
        if(hasWon)
        {
            Debug.Log("Next Level");
        }
        else
        {
            Debug.Log("You Loose !!!");
        }
    }


}
