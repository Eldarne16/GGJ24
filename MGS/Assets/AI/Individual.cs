using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Individual : MonoBehaviour
{
    float minValues;
    float maxEnergy = 200;
    public float energy;
    float maxForce = 50;
    public float force;
    float maxEmpathy = 50;
    public float Empathy;
    float maxResilience = 50;
    public float resilience;
    [SerializeField]
    AnimationCurve curve;
    [SerializeField]
    float threshold;

    [SerializeField]
    private LayerMask detectAgents;
    [SerializeField]
    private LayerMask detectObstacles;


    float input00;
    float input01;
    float input02;

    private float timeFactor;
    public float TimeFactor { get { return timeFactor; } set { timeFactor = value; } }

      

    void Start()
    {
        TimeFactor = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = TimeFactor;
        for (int i = 1; i <33; i++)
        {
            //Debug.Log((float)(i * (360 / 32)));
            // Debug.Log(new Vector3(Mathf.Cos((i * (360 / 32))) * Mathf.Deg2Rad, Mathf.Sin((i * (360 / 32)) * Mathf.Deg2Rad), 0));
            //Debug.Log(transform.TransformDirection(new Vector3(Mathf.Cos((i * (360 / 32))) * Mathf.Deg2Rad, Mathf.Sin((i * (360 / 32)) * Mathf.Deg2Rad), 0)));

      
               // gameObject.transform.rotation.eulerAngles = new Vector3(Mathf.Cos((i * (360 / 32))) * Mathf.Deg2Rad, Mathf.Sin(i * (360 / 32)) * Mathf.Deg2Rad, 0, Space.World));
            
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            //gameObject.transform.Rotate(new Vector3(0, i, 0));
            
            if (!Physics.Raycast(transform.position + new Vector3(0, -0.6f, 0), Vector3.forward, out hit, 20, detectObstacles))
            {
                if (Physics.Raycast(transform.position + new Vector3(0, -0.6f, 0), Vector3.forward, out hit, 20, detectAgents))
                {

                    if(hit.collider.gameObject.tag=="resource")
                    {
                        input00 = Vector3.Distance(gameObject.transform.position, hit.collider.gameObject.transform.position);
                        Debug.Log("hit00");
                    }

                    if (hit.collider.gameObject.tag == "individual")
                    {
                        input01 = Vector3.Distance(gameObject.transform.position, hit.collider.gameObject.transform.position);
                        Debug.Log("hit01");
                    }

                    if (hit.collider.gameObject.tag == "bed")
                    {
                        input02 = Vector3.Distance(gameObject.transform.position, hit.collider.gameObject.transform.position);
                        Debug.Log("hit02");
                    }



                    // Debug.Log("Did Hit");
                }

            }
            else if (Physics.Raycast(transform.position + new Vector3(0, -0.6f, 0), Vector3.forward, out hit, 20, detectObstacles))
            {
                Debug.DrawRay(transform.position + new Vector3(0, -0.6f, 0), this.transform.TransformDirection(Vector3.up + (new Vector3(360/i, 0, 0))) * hit.distance, Color.green);
                //Debug.Log("Did not Hit");
            }



            // }

        }
    }

    void DebugLogList(List<float> list)
    {
        for (int i = 0; i < list.Count;i++)
        {
            Debug.Log("Node" + i.ToString() + " : " + list[i]);
        }
        
    }
    
    float NodeIO(float i)
    {
        if (curve.Evaluate(i) < threshold)
        { return i; }
        else return 0;
    }

    List<float> GetRandomArray(int index)
    {
        List<float> newArray = new List<float>();
        for (int i = 0; i<index;)
        {
            newArray.Add(NodeIO(Random.Range(0f,1f)));
            i++;
        }
        return newArray;
    }

    List<float> GetArray(int index)
    {
        List<float> newArray = new List<float>();
        for (int i = 0; i < index;)
        {
            newArray.Add(NodeIO(Random.Range(0f, 1f)));
            i++;
        }
        return newArray;
    }


    void SearchResources()
    {

    }

    void GoToBed()
    {

    }

    IEnumerator isSleeping(bool isIt)
    {
        int i = 0;
        while (isIt==true)
        {
            i++;
            energy += (resilience * 0.1f);
            yield return null;
        }
    }

}
