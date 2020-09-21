using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTriTut : MonoBehaviour
{
    CookTut ck;
    void Awake()
    {
        ck = transform.GetComponentInParent<CookTut>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ck.whichFood = 2;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ck.whichFood = 0;
    }
}
