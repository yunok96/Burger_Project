using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayOrder : MonoBehaviour
{
    public GameObject order;
    public GameObject findOrder;
    public bool failed = false;
    public NewOrder ord;

    void Update()
    {
        if (failed)
            ord.damage();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Customer")
        {
            findOrder = Instantiate(order, transform);
        }        
    }
}
