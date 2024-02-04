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
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip[] _woman;
    [SerializeField]
    private AudioClip[] _man;
    [SerializeField]
    private AudioClip[] _nothing;

    [SerializeField]
    private AudioClip _gunFire;

    private bool _isPlaying = false;

    enum StateWoman {initial, Jenny1, Johnny1, Jenny2, Johnny2, Jenny3, Johnny3, end}
    StateWoman _stateWoman = StateWoman.initial;
    enum StateMan { initial, Johnny4, Johnny5, end }
    StateMan _stateMan = StateMan.initial;

    enum StateNothing { initial, Jenny4, end }
    StateNothing _stateNothing = StateNothing.initial;


    private void Awake()
    {
        _infos = Infos.instance;

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
            _audioSource.clip = _gunFire;
            _audioSource.Play();
        }
        Vector3 direction = transform.parent.position - GunPoint.transform.position;
        Debug.DrawRay(GunPoint.transform.position, direction, Color.green);

        CheckGunCollision();

        if(_state != State.initial && _state != _lastState) 
        {
            StateChanged();
            PlaySound(_state);
        }

        if (_isPlaying == true)
        {
            if(_audioSource.isPlaying == false)
            {
                PlaySound(_state);
            }
        }










        _lastState = _state;
    }

    void Fire()

    {

        Vector3 direction =  GunPoint.transform.position - transform.parent.position;
        RaycastHit2D hit = Physics2D.Raycast(GunPoint.transform.position, direction, 100f);

        if (hit.transform == null)
        {
            return;
        }
        else if (hit.transform.gameObject.tag == "WOMAN")
        {

            _hasWon = false;
            StartCoroutine(LevelEnd());

        }
        else if(hit.transform.gameObject.tag == "MAN")
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
        Debug.Log(_state);
    }

    IEnumerator LevelEnd()
    {
        yield return new WaitForSeconds(2);
        _infos.GetHandler<SceneHandler>().NextLevel(_hasWon);
    }

    void PlaySound(State state)
    {
        switch(state)
        {
            case State.woman:
                switch(_stateWoman)
                {
                    case StateWoman.initial:
                        _audioSource.clip = _woman[(int)StateWoman.initial];
                        _stateWoman = StateWoman.Jenny1;
                        _isPlaying = true;
                        break;
                    case StateWoman.Jenny1:
                        _audioSource.clip = _woman[(int)StateWoman.Jenny1];
                        _stateWoman = StateWoman.Johnny1;
                        _isPlaying = true;
                        break;
                    case StateWoman.Johnny1:
                        _audioSource.clip = _woman[(int)StateWoman.Johnny1];
                        _stateWoman = StateWoman.Jenny2;
                        _isPlaying = true;
                        break;
                    case StateWoman.Jenny2:
                        _audioSource.clip = _woman[(int)StateWoman.Jenny2];
                        _stateWoman = StateWoman.Johnny2;
                        _isPlaying = true;
                        break;
                    case StateWoman.Johnny2:
                        _audioSource.clip = _woman[(int)StateWoman.Johnny2];
                        _stateWoman = StateWoman.Jenny3;
                        _isPlaying = true;
                        break;
                    case StateWoman.Jenny3:
                        _audioSource.clip = _woman[(int)StateWoman.Jenny3];
                        _stateWoman = StateWoman.Johnny3;
                        _isPlaying = true;
                        break;
                    case StateWoman.Johnny3:
                        _audioSource.clip = null;
                        _isPlaying = false;
                        break;
                }
                break;
            case State.nothing:
                switch(_stateNothing)
                {
                    case StateNothing.initial:
                        _audioSource.clip = _nothing[(int)StateNothing.initial];
                        _stateNothing = StateNothing.Jenny4;
                        _isPlaying = true;
                        break;
                    case StateNothing.Jenny4:
                        _audioSource.clip = null;
                        _isPlaying = false;
                        break;
                }
                break;
            case State.man:
                switch (_stateMan)
                {
                    case StateMan.initial:
                        _audioSource.clip = _man[(int)StateMan.initial];
                        _stateMan = StateMan.Johnny4;
                        _isPlaying = true;
                        break;
                    case StateMan.Johnny4:
                        _audioSource.clip = _man[(int)StateMan.Johnny4];
                        _stateMan = StateMan.Johnny5;
                        _isPlaying = true;
                        break;
                    case StateMan.Johnny5:
                        _audioSource.clip = null;
                        _isPlaying = false;
                        break;
                }
                break;
        }
        _audioSource.Play();
    }
}
