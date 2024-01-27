using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private static SceneHandler _instance;

    //Scenes
    private string[] _sceneNames = new string[] { "DontFallToYourDeath_SCENE"/*"HeyListen_SCENE", "DontFallToYourDeath_SCENE", "GunGame_Scene"*/ };
    private List<string> _currentSceneNamesList = new List<string>();

    private string _finalScene = "FinalScene_SCENE";
    private string _gameOverScene = "GameOver_SCENE";

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

    public void StartGame()
    {
        ShuffleArray(_sceneNames);
        LoadScene();
    }

    public void ShuffleArray(string[] array)
    {
        System.Random random = new System.Random();
        List<string> shuffledList = new List<string>(array);

        // Fisher-Yates shuffle algorithm
        int n = shuffledList.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            string temp = shuffledList[i];
            shuffledList[i] = shuffledList[j];
            shuffledList[j] = temp;
        }
        foreach (string s in shuffledList)
        {
            Debug.Log(s);
        }
        _currentSceneNamesList = shuffledList;
    }

    public void LoadScene()
    {
        if(_currentSceneNamesList.Count == 0)
        {
            SceneManager.LoadScene(_finalScene);
        }
        else
        {
            // Load the scene with the given name
            SceneManager.LoadScene(_currentSceneNamesList[0]);
            _currentSceneNamesList.RemoveAt(0);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StartGame();
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
            LoadScene();
        }
        else
        {
            SceneManager.LoadScene(_gameOverScene);
            Debug.Log("You Loose !!!");
        }
    }

    IEnumerator TransitionToNextLevel()
    {
        yield return null;
    }

    IEnumerator TransitionToGameOver()
    {
        yield return null;
    }


}
