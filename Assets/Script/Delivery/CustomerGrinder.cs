using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGrinder : MonoBehaviour
{
    public NewOrder ord;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Customer")
        {
            Destroy(collision.gameObject);
            ord.isTableOnOrder[collision.transform.GetComponent<CustomerMove>().whoIsMe] = false;
        }
    }
}
