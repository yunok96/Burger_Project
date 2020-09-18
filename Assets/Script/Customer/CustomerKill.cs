using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerKill : MonoBehaviour
{
    public bool isWorking = false;
    private CustomerSpawn cSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            cSpawn.isSonDeadYet = true;
        }
    }

    void Start()
    {
        cSpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CustomerSpawn>();
    }
}
