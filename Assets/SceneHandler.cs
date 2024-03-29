using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private static SceneHandler _instance;
    private string[] _sceneNames = new string[] { "HeyListen_SCENE", "GunGame_Scene", "Password_SCENE"/*, "MGS_SCENE"*/, "DTA_SCENE" };
    private string[][] _orderedScene = new string[][] { new string[] { "DontFallToYourDeath_SCENE", "PlatformerSpike_SCENE", "GrupUnderwater_SCENE" }, new string[] { "EatThePussy_SCENE", "EatThePussy_SCENE 1" } };
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

        foreach (string[] orderedList in _orderedScene)
        {
            MergeLists(new List<string>(orderedList), shuffledList);
        }


        foreach (string sceneName in shuffledList)
        {
            Debug.Log($"{sceneName}");
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

    public void LoadTransition()
    {
        SceneManager.LoadScene("Transition_SCENE");
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
            if (_currentSceneNamesList.Count == 0)
            {
                SceneManager.LoadScene(_finalScene);
            }
            else
            {
                SceneManager.LoadScene("Transition_SCENE");
            }
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

    public static List<T> MergeLists<T>(List<T> orderedList, List<T> randomList)
    {
        System.Random random = new System.Random();
        int insertIndex = 0;

        foreach (T item in orderedList)
        {
            insertIndex = random.Next(insertIndex, randomList.Count + 1);
            randomList.Insert(insertIndex, item);
            insertIndex++;
        }

        return randomList;
    }


}
