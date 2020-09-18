using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerTrigger : MonoBehaviour
{
    Cook ck;
    void Awake()
    {
        ck = transform.GetComponentInParent<Cook>();
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
