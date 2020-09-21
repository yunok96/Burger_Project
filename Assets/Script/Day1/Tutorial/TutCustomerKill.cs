using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCustomerKill : MonoBehaviour
{
    public bool isWorking = false;
    CustomerSpawnTut cSpawn;
    public DMTut dm;

    void Start()
    {
        cSpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CustomerSpawnTut>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            cSpawn.isSonDeadYet = true;
            dm.id = 700;
            dm.Action();
        }
    }

    
    
}
