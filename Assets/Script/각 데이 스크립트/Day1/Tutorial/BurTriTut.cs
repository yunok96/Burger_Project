using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurTriTut : MonoBehaviour
{
    CookTut ck;
    void Awake()
    {
        ck = transform.GetComponentInParent<CookTut>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ck.whichFood = 4;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ck.whichFood = 0;
    }
}
