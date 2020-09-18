using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutCustomerKill : MonoBehaviour
{
    public bool isWorking = false;
    private CustomerSpawn cSpawn;

    public Transform AllDM;
    DControl dc;
    DialogueManager dm;

    void Awake()
    {
        dc = AllDM.GetComponent<DControl>();
        dm = AllDM.GetComponent<DialogueManager>();
    }

    void Start()
    {
        cSpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CustomerSpawn>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            cSpawn.isSonDeadYet = true;
            dc.id = 700;
            dm.Action();
        }
    }

    
    
}
