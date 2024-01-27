using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerTrapHandler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _groundToDelete = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Hero")
        {
            foreach(GameObject go in _groundToDelete)
            {
                Destroy(go);
            }
        }
    }
}
