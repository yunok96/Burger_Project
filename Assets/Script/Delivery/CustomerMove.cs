using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    public bool isGetFood = false;
    public Vector3 targetTable;
    public int whoIsMe;

    void Update()
    {
        transform.position = (isGetFood) ? Vector3.MoveTowards(transform.position, new Vector3(-17, transform.position.y, 0), 0.02f) : Vector3.MoveTowards(transform.position, targetTable, 0.02f);
    }
}
