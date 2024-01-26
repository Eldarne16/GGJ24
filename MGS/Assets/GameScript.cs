using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    [SerializeField]
    FullScreenMode fullScreenMode;
    void Start()
    {
        Screen.SetResolution(1920, 1080, fullScreenMode);
    }
}
