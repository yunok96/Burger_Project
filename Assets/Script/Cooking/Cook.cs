using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class Cook : MonoBehaviour
{
    public FoodStack foodStack;
    public Vigor vigor;

    public GameObject[] foodButton2; //손에 들려줄 스프라이트
    public GameObject[] foodInHerHand;//주인공 손에 들려줄 스프라이트 스택
    public int whichFood;
    public int resultFood;
    int maxFood;
    public GameObject[] minigame = new GameObject[4];
    public GameManager gm;
    public bool chocoOn = false;

    void Update()
    {
        if (whichFood != 0 && Input.GetKeyDown(KeyCode.Return) && gm.plyrMovable)//음식 미니게임
        {
            for (int i = 0; i < maxFood; i++)//손에 비어있는 자리가 있나 확인
            {
                if (foodStack.dishes[i] == 0)//비어있다면
                {
                    gm.plyrMovable = false;
                    minigame[whichFood - 1].SetActive(true);
                    vigor.vigorCookTime = 0;
                    break;
                }
                else if (foodStack.dishes[i] != 0 && i == maxFood - 1)
                {
                    vigor.shakeVigor();//쉐킷베베
                }
            }
        }
        if (resultFood != 0)
        {
            if (resultFood == 5)
            {
                gm.plyrMovable = true;
                resultFood = 0;
                if (chocoOn)//초코 아이템 효과 취소
                    chocoOn = false;
            }
            else
            {
                for (int i = 0; i < maxFood; i++)//음식 어디에 들지 결정
                {
                    if (foodStack.dishes[i] == 0)
                    {
                        if (chocoOn && i < 4)//초코 효과로 요리 2배
                        {
                            foodStack.dishes[i] = resultFood;//요리 번호. 손에 들고있는 것의 실질적인 종류
                            foodStack.dishes[i + 1] = resultFood;
                            Instantiate(foodButton2[resultFood - 1], foodInHerHand[i].transform, false);//손에 요리 스프라이트 생성
                            Instantiate(foodButton2[resultFood - 1], foodInHerHand[i + 1].transform, false);//손에 요리 스프라이트 생성
                        }
                        else
                        {
                            foodStack.dishes[i] = resultFood;//요리 번호. 손에 들고있는 것의 실질적인 종류
                            Instantiate(foodButton2[resultFood - 1], foodInHerHand[i].transform, false);//손에 요리 스프라이트 생성
                        }
                        gm.plyrMovable = true;
                        resultFood = 0;
                        chocoOn = false;
                        break;
                    }
                }
            }
            vigor.vigorCookTime = 1;
        }

        if (vigor.vigorCount < 20)
            maxFood = 1;
        else if (vigor.vigorCount >= 20 && vigor.vigorCount < 40)
            maxFood = 2;
        else if (vigor.vigorCount >= 40 && vigor.vigorCount < 60)
            maxFood = 3;
        else if (vigor.vigorCount >= 60 && vigor.vigorCount < 80)
            maxFood = 4;
        else if (vigor.vigorCount >= 80)
            maxFood = 5;
    }
}
