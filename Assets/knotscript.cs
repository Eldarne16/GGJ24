using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knotscript : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField]
    Vector2 addedForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void EJECT()
    {

        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddForce(addedForce, ForceMode2D.Impulse);
    }
}
