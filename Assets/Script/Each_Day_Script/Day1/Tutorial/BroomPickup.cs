using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroomPickup : MonoBehaviour
{
    public DMTut dm;
    Inventory inventory;//플레이어의 인벤토리 스크립트 불러옴
    public bool kikiKanri = false;
    int doIt = 0;
    bool playerisOn = false;
    public GameObject itemButton;//추가할 아이템 UI
    public GameObject block;
    int dialnum = 0;
    public GameManager gm;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
    
    void Update()
    {
        if (kikiKanri)
        {
            if (doIt<3)
            {
                doIt++;
            }
            if (doIt == 1)
            {
                Destroy(block);
                dm.id = 800;
                dm.Action();
            }
        }
        if (playerisOn && Input.GetKeyDown(KeyCode.Return) && gm.plyrMovable)
        {
            dialnum++;
            switch (dialnum) {
                case 1:
                    dm.id = 4;
                    break;
                case 2:
                    dm.id = 5;
                    break;
                case 3:
                    dm.id = 6;
                    break;
                case 4:
                    dm.id = 7;
                    break;
                case 5:
                    dm.id = 8;
                    break;
            }
            if (dialnum > 5)
                dm.id = 9;
        }
    }
    void OnDestroy()
    {
        dm.id = 900;
        dm.Action();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerisOn = true;
            if (kikiKanri)
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        Instantiate(itemButton, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerisOn = false;
        }
    }
}
