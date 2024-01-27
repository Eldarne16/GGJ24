using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class guardScript : MonoBehaviour
{
    NavMeshAgent guardAgent;
    public List<string> Orders = new List<string>();
    int orderIndex = 0;
    [SerializeField]
    bool hasCompletedOrder = false;
    [SerializeField]
    private LayerMask detectAgents;
    [SerializeField]
    private LayerMask detectObstacles;
    [SerializeField]
    private bool isCivilian;

    private bool hasDetectedIntruder = false;

    GameObject target;

    float guardStoppingDistance = 0.5f;

    void Start()
    {

        guardAgent = this.gameObject.GetComponent<NavMeshAgent>();
        Invoke("readCurrentOrder", 0);
    }


    void readCurrentOrder()
    {
        hasCompletedOrder = false;
        string currentOrder = this.Orders[orderIndex].Substring(0, 4);
        //string currentOrderParams = this.Orders[orderIndex].Substring(5);
        //Debug.Log(currentOrder + currentOrderParams);

        StartCoroutine(currentOrder);

        //incrementOrderIndex();

    }

    void incrementOrderIndex()
    {
        orderIndex++;
        if (orderIndex >= Orders.Count)
        {
            orderIndex = 0;
        }
    }

    void nextOrder()
    {
        this.StopAllCoroutines();
        if (hasCompletedOrder == true)
        {
            incrementOrderIndex();
            readCurrentOrder();
        }
    }
    IEnumerator GOTO()
    {
        Vector3 GOTOPos;
        GOTOPos = new Vector3(GameObject.Find(Orders[orderIndex].Substring(5)).transform.position.x, 0, GameObject.Find(Orders[orderIndex].Substring(5)).transform.position.z);
        float distanceToWaypoint;
        guardAgent.destination = GOTOPos;
        distanceToWaypoint = Vector3.Distance(new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z), GOTOPos);

        while (distanceToWaypoint > guardStoppingDistance)
        {
            distanceToWaypoint = Vector3.Distance(gameObject.transform.position, GOTOPos);
            //Debug.Log(distanceToWaypoint + " ||| " + guardStoppingDistance);
            if (distanceToWaypoint < guardStoppingDistance)
            {
                hasCompletedOrder = true;
                nextOrder();
            }
            yield return null;
        }
        /* {

             distanceToWaypoint = Vector3.Distance(this.gameObject.transform.position, GOTOPos);
             
             yield return new WaitWhile(distanceToWaypoint >= guardAgent.stoppingDistance);
             if (distanceToWaypoint < guardAgent.stoppingDistance)
             {
                 yield return hasCompletedOrder = true;
             }
             yield return null;
         }*/

        yield return null;


    }

    IEnumerator WAIT()
    {
        float waitTime = 1.0f;
        float elapsedTime = 0.0f;

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            gameObject.transform.Rotate(Vector3.up, Mathf.Lerp(0.0f, Mathf.Sin(8), waitTime / elapsedTime));

            yield return null;
        }
        if (elapsedTime >= waitTime)
        {
            hasCompletedOrder = true;
            nextOrder();
        }
        yield return null;
    }

    void IntruderDetected(GameObject intruder)
    {
        
        hasDetectedIntruder = true;
        if (isCivilian == false)
        {
           
            StartCoroutine(Chasing(intruder));
        }

        if(isCivilian)
        {
            StartCoroutine("CallGuards");
        }

    }

    IEnumerator Chasing(GameObject intruder)

    {
        GameObject chasedIntruder = intruder;
        //StopAllCoroutines();
        Debug.Log("yepyepyep");
        while (Vector3.Distance(gameObject.transform.position, chasedIntruder.transform.position) >= 1.6f)
        {
            guardAgent.destination = chasedIntruder.transform.position;
            yield return null;
        }
        readCurrentOrder();
        
        
    }
    void Update()
    {
        Debug.Log(System.DateTime.Now);

        //if (isActivated == true)
        //{

        for (int i = -16; i < 32; i++)
            {
                Debug.DrawRay(transform.position + new Vector3(0, 0.4f, 0), this.transform.TransformDirection(Vector3.forward + (new Vector3(i - 4, 0, 0) / 20)) * 20, Color.yellow);
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                //gameObject.transform.Rotate(new Vector3(0, i, 0));
                if (!Physics.Raycast(transform.position + new Vector3(0, 0.4f, 0), transform.TransformDirection(Vector3.forward + (new Vector3(i - 4, 0, 0) / 20)), out hit, 20, detectObstacles))
                {
                    if (Physics.Raycast(transform.position + new Vector3(0, 0.4f, 0), transform.TransformDirection(Vector3.forward + (new Vector3(i - 4, 0, 0) / 20)), out hit, 20, detectAgents))
                    {

                        target = hit.collider.gameObject;
                        Debug.DrawRay(transform.position + new Vector3(0, 0.4f, 0), this.transform.TransformDirection(Vector3.forward + (new Vector3(i - 4, 0, 0) / 20)) * hit.distance, Color.red);

                        IntruderDetected(hit.collider.gameObject);

                        // Debug.Log("Did Hit");
                    }

                }
                else if (Physics.Raycast(transform.position + new Vector3(0, 0.4f, 0), transform.TransformDirection(Vector3.forward + (new Vector3(i - 4, 0, 0) / 20)), out hit, 20, detectObstacles))
                {
                    Debug.DrawRay(transform.position + new Vector3(0, 0.4f, 0), this.transform.TransformDirection(Vector3.forward + (new Vector3(i - 4, 0, 0) / 20)) * hit.distance, Color.green);
                    //Debug.Log("Did not Hit");
                }



                // }
            
        }

    }
}
