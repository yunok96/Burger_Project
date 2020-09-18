using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDoor : MonoBehaviour
{
    public Transform AllDM;
    public int DialCount = 0;
    DControl dc;
    bool isTheCharacterOn = false;

    void Awake()
    {
        dc = AllDM.GetComponent<DControl>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isTheCharacterOn = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isTheCharacterOn = false;
    }
    void Update()
    {
        if(isTheCharacterOn == true && Input.GetKeyDown(KeyCode.Return) && StatVar.instance.Movable == true)
        {
            DialCount++;
            if (DialCount > 1)
            {
                if (DialCount == 8)
                    dc.id = 3;
                else
                    dc.id = 2;
            }
            else
                dc.id = 1;
        }
    }
}
