using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerTrapHandler : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _groundToDelete = new List<GameObject>();
    [SerializeField]
    DontFallToYourDeathController _dontFallToYourDeathController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "GrupContener")
        {
            foreach(GameObject go in _groundToDelete)
            {
                Destroy(go);
            }
            _dontFallToYourDeathController.End();
        }
    }
}
