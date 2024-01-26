using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileProperties : MonoBehaviour {

    public string tileName;
    public string tileType;
    public Vector2 pos;

    
    private Sprite icon;
    private Color32 Ressources1;
    private Color32 Ressources2;
   
    private bool isBuildable;
    
    public TileProperties(Color32 Data1, Color32 Data2, bool isItBuildable, Sprite Ycon)
    {
        Data1 = RessourceData1;
        Data2 = RessourceData2;

        isItBuildable = Buildable;
        Ycon = Icon;
    }
    public List<TileProperties> TileState = new List<TileProperties>();
    void Start()

    {
        tileType = gameObject.name.Substring(0, 3);
        pos = (Vector2)gameObject.transform.position;

    }

    public bool Buildable
    {
        get { return isBuildable; }
        set { isBuildable = value; }
    }

    public Color32 RessourceData1
    {
        get { return Ressources1; }
        set { Ressources1 = value; }
    }
    public Color32 RessourceData2
    {
        get { return Ressources2; }
        set { Ressources2 = value; }
    }


    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    /*
    public void SetProperties(bool newIsBuildable, Sprite newIcon)
    {
        isBuildable = newIsBuildable;
        icon = newIcon;
    }
    public void SetRessources(Color32 newRessources1, Color32 newRessources2)
    {
        Ressources1 = newRessources1;
        Ressources2 = newRessources2;
    }
    public void GetProperties()
    {
        isBuildable.CompareTo(true);
    }

    public void GetRessources()
    {
        
    }*/
}
