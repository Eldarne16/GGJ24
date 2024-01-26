using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPoint : MonoBehaviour
{

    public GameObject currentWeapon;
    public GameObject handeldWeapon;
    // Start is called before the first frame update
    void Start()
    {
        var handeldWeapon = Instantiate(currentWeapon, transform.position, transform.rotation);
        handeldWeapon.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
