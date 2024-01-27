using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AddGuizmo : MonoBehaviour
{
    public float radius;
    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnDrawGizmos()
    {
        
        Gizmos.color = color;
        Gizmos.DrawSphere(gameObject.transform.position, radius);
        
    }
}
