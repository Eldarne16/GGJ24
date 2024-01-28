using System.Collections;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // Reference to the target GameObject
    [SerializeField]
    private GameObject _targetObject;

    // Serialized fields for offsets
    [SerializeField] private float offX;
    [SerializeField] private float offY;
    [SerializeField] private float offZ;

    bool NoMoreUpdate = false;

    void Update()
    {
        if (_targetObject != null && NoMoreUpdate == false)
        {
            // Follow the target's X and Y position with the specified offsets
            transform.position = new Vector3(_targetObject.transform.position.x + offX,
                                             offY,
                                             offZ); // Keeps its own Z position with offset
        }
    }

    public void StartChangeOffset()
    {
        Debug.Log("yo");
        NoMoreUpdate = true;
        StartCoroutine(ChangeYOffset());
    }

    IEnumerator ChangeYOffset()
    {
        float originalOffY = offY;
        while(true)
        {
            float originalY = _targetObject.transform.position.y;
            float currentDiff = originalY - _targetObject.transform.position.y;
            float newOffY = originalOffY - currentDiff;
            Debug.Log(newOffY);
            transform.position = new Vector3(_targetObject.transform.position.x + offX,
                                             newOffY,
                                             offZ);
            yield return null;

        }
        yield return null;
    }
}
