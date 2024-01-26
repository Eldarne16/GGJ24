using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour
{
    public GameObject barrel;
    public GameObject bullet;
    public GameObject projectile;
    public GameObject hull;
    Vector3 barrelPos;
    Quaternion barrelRot;

    public float loadTime;
    float loading;

    bool isLoaded = true;


    void Start()
    {
        barrelPos = barrel.transform.position;
        barrelRot = barrel.transform.rotation;
    }

    void WeaponLoading()
    {
        loading += Time.deltaTime;
        if (loadTime <= loading) { loading = loadTime; isLoaded = true; }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && isLoaded == true)
        {
            
            barrelPos = barrel.transform.position;
            barrelRot = barrel.transform.rotation;
            Instantiate(projectile, barrelPos, barrelRot);
            isLoaded = false;
            loading = 0;
            WeaponLoading();
        }

    }
}
