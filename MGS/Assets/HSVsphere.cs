using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSVsphere : MonoBehaviour
{
    public List<GameObject> L = new List<GameObject>();
    List<Vector3> O = new List<Vector3>();
    List<MeshRenderer> MRL = new List<MeshRenderer>();
    List<Vector3> D = new List<Vector3>();
    Vector3 C;
     [SerializeField]
    float MD;
    [SerializeField]
    float RCMD;
    [SerializeField]
    LayerMask LM;

    public bool isThereArray = true;
    public bool move = false;
    public GameObject part;
    public int maxParts;

    public float mouseSensitivity;
    public Transform Cam;
    public Transform centerCam;

    List<Color> AC = new List<Color>();
    private Shader shader;

    void Start()
    {

        C = this.gameObject.transform.position;
   
        if(isThereArray)
        {
            L.Clear();
            for(int i = 0;i<maxParts;i++)
            {
                for(int j = 0;j<maxParts;j++)
                {
                    for(int k = 0; k<maxParts;k++)
                    {
                        Vector3 newPos = new Vector3(i-(maxParts/2)+0.05f, j- (maxParts / 2), k- (maxParts / 2));
                        GameObject newObject = Instantiate(part, newPos, new Quaternion(), this.gameObject.transform);
                        L.Add(newObject);
                        O.Add(newObject.transform.position);
                        MRL.Add(newObject.GetComponent<MeshRenderer>());
                        
                        if(move)
                        {
                            newObject.AddComponent<Rigidbody>();
                            newObject.GetComponent<Rigidbody>().useGravity = false;
                           
                            newObject.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f)));
                            newObject.AddComponent<SphereCollider>();
                            newObject.GetComponent<SphereCollider>().radius = 0.6f;
                        }
                    }
                }
            }
        } else
        {
            for (int i = 0; i < L.Count; i++)
            {
                O.Add(L[i].transform.position);
                MRL.Add(L[i].GetComponent<MeshRenderer>());
            }
        }
        shader = MRL[0].material.shader;
    }

    // Update is called once per frame
    void LateUpdate()
    {


        UpdateO();


    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        { Application.Quit(); }

        Cam.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel"));
        if (Input.GetMouseButton(2))
        {
            centerCam.Rotate(Input.GetAxis("Mouse Y") * mouseSensitivity, 0, 0, Space.Self);
            centerCam.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0, Space.World);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UpdateO();
        }
    }

        void CheckColor()
        {
        AC.Clear();
        for (int i = 0; i < O.Count; i++)
           {
            
            //Debug.Log(O[i]);
                RaycastHit H = new RaycastHit();
                if (Physics.Raycast(O[i], -O[i].normalized, out H, MD,LM))
                {
                //O.Add(L[i].transform.position);
            
                   Vector2 pixelUV = H.textureCoord;
                   Texture2D T = H.collider.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
                   AC.Add(T.GetPixelBilinear(pixelUV.x, pixelUV.y));

                   MRL[i].material.SetColor("_Color", AC[i]) /* * new Color(Vector3.Distance(O[i],C), Vector3.Distance(O[i], C), Vector3.Distance(O[i], C))*/;
                 

                }


            }


        }

    void UpdateO()
    {
        O.Clear();
        for (int i = 0; i < L.Count; i++)
        {
            O.Add(L[i].gameObject.transform.position);
        }
        CheckColor();
    }
}
