using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // Reference to the target GameObject
    [SerializeField]
    private GameObject targetObject;

    // Serialized fields for offsets
    [SerializeField] private float offX;
    [SerializeField] private float offY;
    [SerializeField] private float offZ;

    void Update()
    {
        if (targetObject != null)
        {
            // Follow the target's X and Y position with the specified offsets
            transform.position = new Vector3(targetObject.transform.position.x + offX,
                                             offY,
                                             offZ); // Keeps its own Z position with offset
        }
    }
}
