using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStack : MonoBehaviour
{
    public int[] dishes = { 0, 0, 0, 0, 0 }; //스택에 요리 유무. 0이면 없음,
    public Transform[] onHerHands = new Transform[5];

    public void Delivery()
    {
        for(int i = 0; i < dishes.Length-1; i++)
        {
            if (dishes[i] == 0)
            {
                if (dishes[i + 1] == 0)
                {
                    break;
                }
                dishes[i] = dishes[i + 1];
                dishes[i + 1] = 0;
                Instantiate(onHerHands[i + 1].GetChild(0).gameObject, onHerHands[i], false);
                Destroy(onHerHands[i + 1].GetChild(0).gameObject);
            }
        }
    }
}
