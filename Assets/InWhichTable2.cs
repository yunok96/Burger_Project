using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWhichTable2 : MonoBehaviour
{
    public NewOrder ord;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ord.whereIsPlayer = 2;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ord.whereIsPlayer = 0;
        }
    }
}
