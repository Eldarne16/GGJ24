using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class agentProperties : MonoBehaviour
{
    [SerializeField]
    private string Nam;
    [SerializeField]
    private string Des;
    [SerializeField]
    private Sprite Ico;
    [SerializeField]
    private float Spe;
    [SerializeField]
    private float Agi;
    [SerializeField]
    private float Str;
    [SerializeField]
    private float Sta;

    private string Name;
    private string Description;
    private Sprite Icon;
    private float Speed;
    private float Agility;
    private float Strength;
    private float Stamina;

    void Start()
    {
      Name = Nam;
      Description = Des;
      Icon = Ico;
      Speed = Spe;
      Agility = Agi;
      Strength = Str;
      Stamina = Sta;
    }
    public string agentName
    {
        get { return Name; }
    }

    public string description
    {
        get { return Description; }
    }

    public Sprite icon
    {
        get { return Icon; }
    }

    public float speed
     {
        get { return Speed; }
    }
    public float agility
{
        get { return Agility; }
    }
    public float strength
{
        get { return Strength; }
    }
    public float stamina
{
        get { return Stamina; }
    }
}