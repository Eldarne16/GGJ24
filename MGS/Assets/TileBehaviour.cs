using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class TileBehaviour : MonoBehaviour
{
    public TileProperties TP;
    private Color mouseOverColor = Color.cyan;
    private Color originalColor;


    byte VH;
    byte H;
    byte M;
    byte L;
    byte VL;
    byte R;
    byte O;

    List<byte> ore = new List<byte>();
    List<byte> wood = new List<byte>();
    List<byte> water = new List<byte>();
    List<byte> food = new List<byte>();

    List<byte> oil = new List<byte>();
    List<byte> sulfur = new List<byte>();
    List<byte> cement = new List<byte>();
    List<byte> rare = new List<byte>();



    void Start()
	{

        
       
        VH = (byte)Random.Range(180, 250);
        H = (byte)Random.Range(140, 230);
        M = (byte)Random.Range(100, 170);
        L = (byte)Random.Range(50, 120);
        VL = (byte)Random.Range(10, 60);
        R = (byte)Random.Range(3, 5);
        O = 0;
        TP = GetComponent<TileProperties>();
		originalColor = gameObject.GetComponent<MeshRenderer>().material.color;

        /*
        AddToStats(ore, H, VL, VL, VL, O, L, VL, R);
        AddToStats(wood, L, VH, M, M, VL, O, O, R);
        AddToStats(water, VL, VL, VH, L, VL, O, L, R);
        AddToStats(food, L, L, L, H, L, VL, VL, R);

        AddToStats(oil, L, O, VL, O, H, O, M, R);
        AddToStats(sulfur, M, O, VL, VL, O, H, VL, R);
        AddToStats(cement, L, VL, VL, O, L, VL, H, R);
        AddToStats(rare, L, L, H, M, L, VL, O, L);
        */
        InitTile(Random.Range(0,100));
    }

    void InitTile(int RND)
    {
        Debug.Log("yepyepyep");
        if (100 >= RND && RND > 55)
        {
            AddToStats(food, L, L, L, H, L, VL, VL, R);
        }
        else
        if (55 >= RND && RND > 40)
        {
            AddToStats(wood, L, VH, M, M, VL, O, O, R);
        }
        else if (40 >= RND && RND > 32)
        {
            AddToStats(ore, H, VL, VL, VL, O, L, VL, R);
        }
        else if (32 >= RND && RND > 20)
        {
            AddToStats(water, VL, VL, VH, L, VL, O, L, R);
        }
        else if (20 >= RND && RND > 12)
        {
            AddToStats(cement, L, VL, VL, O, L, VL, H, R);
        }
        else
        if (12 >= RND && RND > 6)
        {
            AddToStats(sulfur, M, O, VL, VL, O, H, VL, R);
        }
        else
        if (6 >= RND && RND > 1)
        {
            AddToStats(oil, L, O, VL, O, H, O, M, R);
        }
        else
        if (1 >= RND && RND >= 0)
        {
            AddToStats(rare, L, L, H, M, L, VL, O, L);
        }
        InvokeRepeating("SetColor", 0, 5.0f);
    }

    void AddToStats(List<byte> type, params byte[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            type.Add(list[i]);
        }
        SetStats(type);
    }

    /*-----DO : Additionnal randomz to set------*/

    void SetStats(List<byte> type)
    {
        TP.RessourceData1 = new Color32( type[0] ,  type[1]   ,  type[2]   ,  type[3]   );
        TP.RessourceData2 = new Color32( type[4]   ,  type[5]   ,  type[6]   ,  type[7]   );
    }

  void SetColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = (Color)TP.RessourceData2 + (Color)TP.RessourceData1;
    }
    void OnMouseEnter()
    {
        
       
			//gameObject.GetComponent<MeshRenderer> ().material.color = mouseOverColor;


    }
    void OnMouseDown()
    {
        
        Debug.Log(TP.RessourceData1 + "  " + TP.RessourceData2);
    }
    void OnMouseExit()
    {
        //gameObject.GetComponent<MeshRenderer>().material.color = originalColor;
    }


}