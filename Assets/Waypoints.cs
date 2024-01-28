using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Vector3[] waypoints;
    void Start()
    {
        waypoints = new Vector3[24];
        Transform[] t = GetComponentsInChildren<Transform>();
        for(int i = 0; i<waypoints.Length;i++)
            {
            waypoints[i] = t[i].position;

            t[i].gameObject.AddComponent<SphereCollider>();
        }
    }

    public static Vector3 GetWaypoints(int index)
    {
        return waypoints[index];
    }
}
