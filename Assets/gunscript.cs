using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    Infos _infos;


    public GameObject GunPoint;

    bool _hasWon;

    enum State { initial, woman, man, nothing }

    private State _state = State.initial;
    private State _lastState = State.initial;

    [SerializeField]
    private AudioClip[] _woman;
    [SerializeField]
    private AudioClip[] _man;
    [SerializeField]
    private AudioClip[] _nothing;

    private void Awake()
    {
        _infos = Infos.instance;

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        Vector3 direction = transform.parent.position - GunPoint.transform.position;
        Debug.DrawRay(GunPoint.transform.position, direction, Color.green);

        CheckGunCollision();

        if(_state != State.initial && _state != _lastState) 
        {
            StateChanged();
        }












        _lastState = _state;
    }

    void Fire()

    {

        Vector3 direction =  GunPoint.transform.position - transform.parent.position;
        RaycastHit2D hit = Physics2D.Raycast(GunPoint.transform.position, direction, 100f);
        
            if(hit.transform.gameObject.tag == "WOMAN")
            {

                _hasWon = false;
                StartCoroutine(LevelEnd());

            }

            if(hit.transform.gameObject.tag == "MAN")
            {

                _hasWon = true;
                StartCoroutine(LevelEnd());

            }
        
    }

    void CheckGunCollision()
    {
        Vector3 direction = GunPoint.transform.position - transform.parent.position;
        RaycastHit2D hit = Physics2D.Raycast(GunPoint.transform.position, direction, 100f);

        if(hit.transform == null)
        {
            //Debug.Log("Nothing");
            if(_state != State.initial)
            {
                _state = State.nothing;
            }
            else if(_state != State.nothing)
            {
                _state = State.nothing;
            }
        }
        else if (hit.transform.gameObject.tag == "WOMAN")
        {
            if (_state != State.initial)
            {
                _state = State.woman;
            }
            else if (_state != State.woman)
            {
                _state = State.woman;
            }
            //Debug.Log("Woman");

        }
        else if (hit.transform.gameObject.tag == "MAN")
        {
            if (_state != State.initial)
            {
                _state = State.man;
            }
            else if (_state != State.man)
            {
                _state = State.man;
            }
            //Debug.Log("Man");

        }
        else
        {
            Debug.Log("shouldn't happen");
        }
    }

    void StateChanged()
    {
        Debug.Log("changed");
    }

    IEnumerator LevelEnd()
    {
        yield return new WaitForSeconds(2);
        _infos.GetHandler<SceneHandler>().NextLevel(_hasWon);
    }

}
