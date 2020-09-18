using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerDelete : MonoBehaviour
{
    public GameObject EnemyObj;
    void Update()
    {
        if (EnemyObj == null)
        {
            Destroy(gameObject);
        }
    }
}
