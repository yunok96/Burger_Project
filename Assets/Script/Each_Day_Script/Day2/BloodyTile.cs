using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodyTile : MonoBehaviour
{
    public DM_Day2_RouteA_Outro dm;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dm.id = 2301;
            dm.Action();
        }
    }
}
