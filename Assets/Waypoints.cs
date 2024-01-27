using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Vector3[] waypoints = new Vector3[24];
    void Start()
    {

        Transform[] t = GetComponentsInChildren<Transform>();
        for(int i = 0; i<waypoints.Length;i++)
            {
            waypoints[i] = t[i].position;
        }
    }

    public static Vector3 GetWaypoints(int index)
    {
        return waypoints[index];
    }
}
