using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cook : MonoBehaviour
{
    public GameObject player;
    FoodStack foodStack;
    PlayerMovement playerMovement;

    public GameObject[] foodButton2; //손에 들려줄 스프라이트
    public GameObject[] foodInHerHand;//주인공 손에 들려줄 스프라이트 스택
    public int whichFood;
    public int resultFood;
    int maxFood;
    public GameObject[] minigame = new GameObject[4];
    public GameManager gm;

    void Awake()
    {
        foodStack = player.GetComponent<FoodStack>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void maxFoodCount()
    {
        if (playerMovement.hwalgiCount < 20)
            maxFood = 1;
        else if (playerMovement.hwalgiCount >= 20 && playerMovement.hwalgiCount < 40)
            maxFood = 2;
        else if (playerMovement.hwalgiCount >= 40 && playerMovement.hwalgiCount < 60)
            maxFood = 3;
        else if (playerMovement.hwalgiCount >= 60 && playerMovement.hwalgiCount < 80)
            maxFood = 4;
        else if (playerMovement.hwalgiCount >= 80)
            maxFood = 5;
    }

    void GenerateFood() //음식 만들기. int 1 감튀, 2 아이스, 3 음료, 4 햄버거
    {
        if (whichFood!=0 && Input.GetKeyDown(KeyCode.Return) && gm.plyrMovable)//음식 미니게임
        {
            for (int i = 0; i < maxFood; i++)//손에 비어있는 자리가 있나 확인
            {
                if (foodStack.dishes[i] == 0)//비어있다면
                {
                    gm.plyrMovable = false;
                    minigame[whichFood - 1].SetActive(true);
                    break;
                }
            }
            playerMovement.vigorCookTime = 0;
        }
        if (resultFood != 0)
        {
            if (resultFood == 5)
            {
                gm.plyrMovable = true;
                resultFood = 0;
            }
            else
            {
                for (int i = 0; i < maxFood; i++)//음식 어디에 들지 결정
                {
                    if (foodStack.dishes[i] == 0)
                    {
                        gm.plyrMovable = true;
                        foodStack.dishes[i] = resultFood;//요리 번호. 손에 들고있는 것의 실질적인 종류
                        Instantiate(foodButton2[resultFood - 1], foodInHerHand[i].transform, false);//손에 요리 스프라이트 생성
                        resultFood = 0;
                        break;
                    }
                }
            }
            playerMovement.vigorCookTime = 1;
        }
    }

    void Update()
    {
        maxFoodCount();
        GenerateFood();
    }
}
