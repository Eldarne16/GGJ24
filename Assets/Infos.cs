using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Infos : MonoBehaviour
{
#region Private Variables
    private static Infos _instance;

    //Global Variables
    private double _playTime;
    //Maybe we should make a simple multiplayer features where people can compare their preformances
    private int _deathCount;


    //Handlers
    private List<object> _handlers = new List<object>();
    
    //Getters
    public double playTime { get => _playTime;}
    
    public int deathCount { get => _deathCount;}
    #endregion Private Variables

#region Variables Setters

#endregion Variables Setters

#region singleton
    public static Infos instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Infos>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<Infos>();
                    singletonObject.name = typeof(Infos).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }
#endregion singleton

#region handler handling Oo
    public void SetHandler(object handler)
    {
        _handlers.Add(handler);
    }

    public void UnSetHandler(object handler)
    {
        _handlers.Remove(handler);
    }

    public T GetHandler<T>() where T : MonoBehaviour
    {
        foreach (var handler in _handlers)
        {
            if (handler is T)
            {
                return handler as T;
            }
        }

        Debug.LogWarning($"Handler of type {typeof(T)} not found.");
        return null;
    }
#endregion handler handling Oo

#region Monobehavior stuffs
    private void Awake()
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
    }
    #endregion Monobehavior stuffs

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Your code here. This method will be called after a scene is loaded.
        Debug.Log("Loaded scene: " + scene.name);
        CreateHandlersAtLoad();
    }

#region Logic
    private void CreateHandlersAtLoad()
    {
        if(GetHandler<SceneHandler>() == null)
        {
            GameObject sceneHandler = new GameObject();
            sceneHandler.name = "Scene Handler";
            sceneHandler.AddComponent<SceneHandler>();
        }
    }

#endregion Logic
}

