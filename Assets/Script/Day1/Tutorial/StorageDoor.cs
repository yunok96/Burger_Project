using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageDoor : MonoBehaviour
{
    public DMTut dm;
    public GameManager gm;
    int DialCount = 0;
    bool isTheCharacterOn = false;


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
        if(isTheCharacterOn == true && Input.GetKeyDown(KeyCode.Return) && gm.plyrMovable)
        {
            DialCount++;
            if (DialCount > 1)
            {
                if (DialCount == 8)
                    dm.id = 3;
                else
                    dm.id = 2;
            }
            else
                dm.id = 1;
        }
    }
}
