using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerFlagHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _flag;
    [SerializeField]
    GameObject _camera;

    public Transform waypoint; // Assign the waypoint in the inspector
    public Transform _waypointFlag;
    public float speed = 1.0f; // Speed of movement

    Infos infos;

    private void Awake()
    {
        infos = Infos.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Hero")
        {
            _flag.SetActive(true);
            StartCoroutine(MoveObject());
        }
    }

    IEnumerator MoveObject()
    {
        while (Vector3.Distance(_camera.transform.position, waypoint.position) > 0.001f)
        {
            float step = speed * Time.deltaTime; // Calculate the step size
            _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, waypoint.position, step);
            yield return null; // Wait for the next frame
        }

        while(Vector3.Distance(_flag.transform.position, _waypointFlag.transform.position) > 0.001f)
        {
            float step = speed * Time.deltaTime; // Calculate the step size
            _flag.transform.position = Vector3.MoveTowards(_flag.transform.position, _waypointFlag.position, step);
            yield return null; // Wait for the next frame
        }
        yield return new WaitForSeconds(3f);
        infos.GetHandler<SceneHandler>().NextLevel(true);
    }
}
