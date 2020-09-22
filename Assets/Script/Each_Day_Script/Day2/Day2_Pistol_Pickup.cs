using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day2_Pistol_Pickup : MonoBehaviour
{
    Inventory inventory;//플레이어의 인벤토리 스크립트 불러옴
    public GameObject itemButton;//추가할 아이템 UI
    Day2_StageControl day2;

    void Start()
    {
        day2 = GameObject.FindWithTag("GM").GetComponent<Day2_StageControl>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            day2.iGotAGun++;
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
