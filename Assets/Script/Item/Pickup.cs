using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Inventory inventory;//플레이어의 인벤토리 스크립트 불러옴
    public GameObject itemButton;//추가할 아이템 UI

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();//플레이어의 인벤토리 컴포넌트 불러옴
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//플레이어에 부딪히면
        {
            for (int i = 0; i < inventory.slots.Length; i++)//아이템 열을 1번부터 찾아봄
            {
                if (inventory.isFull[i] == false)
                {
                    //템 추가
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
