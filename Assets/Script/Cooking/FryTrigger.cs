using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryTrigger : MonoBehaviour
{
    Cook ck;
    void Awake()
    {
        ck = transform.GetComponentInParent<Cook>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ck.whichFood = 1;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            ck.whichFood = 0;
    }
}
