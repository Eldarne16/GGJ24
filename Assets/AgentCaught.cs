using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCaught : MonoBehaviour
{

    public bool collisionEntered = false;
    private void OnCollisionEnter(Collision collision)
    {


        if(collision.collider.gameObject.tag == "MAN")
        {
            collisionEntered = true;
            MissionScript ms = FindObjectOfType<MissionScript>();
            ms.WinOrLose(false);
           
        }
                
    }

 
}
