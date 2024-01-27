using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    Infos _infos;
    SceneHandler _sceneHandler;

    public GameObject GunPoint;

    bool _hasWon;

    private void Awake()
    {
        _infos = Infos.instance;
        _sceneHandler = _infos.GetHandler<SceneHandler>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        Vector3 direction = transform.parent.position - GunPoint.transform.position;
        Debug.DrawRay(GunPoint.transform.position, direction, Color.green);
    }

    void Fire()

    {

        Vector3 direction =  GunPoint.transform.position - transform.parent.position;
        RaycastHit2D hit = Physics2D.Raycast(GunPoint.transform.position, direction, 100f);
        
            if(hit.transform.gameObject.tag == "WOMAN")
            {
                Debug.Log("HIT !");
                _hasWon = false;
                _sceneHandler.NextLevel(_hasWon);
            }

            if(hit.transform.gameObject.tag == "MAN")
            {
            Debug.Log("MANHIT");
                _hasWon = true;
                _sceneHandler.NextLevel(_hasWon);
            }
        
    }
}
