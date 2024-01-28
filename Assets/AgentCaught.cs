using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCaught : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {


        if(collision.gameObject.tag == "MAN")
        {
            MissionScript ms = FindObjectOfType<MissionScript>();
            Debug.Log("JE SUIS LAAAAA");
            StartCoroutine("ms.WinOrLose", false);
        }
                
    }
}
