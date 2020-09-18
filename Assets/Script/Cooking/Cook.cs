using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cook : MonoBehaviour
{
    FoodStack foodStack;
    PlayerMovement playerMovement;

    public GameObject[] foodButton2; //손에 들려줄 스프라이트
    public GameObject[] foodInHerHand;//주인공 손에 들려줄 스프라이트 스택
    public int whichFood;
    public int resultFood;
    int maxFood;
    public GameObject[] minigame = new GameObject[4];

    void Start()
    {
        foodStack = GameObject.FindGameObjectWithTag("Player").GetComponent<FoodStack>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
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
        if (whichFood!=0 && Input.GetKeyDown(KeyCode.Return) && StatVar.instance.Movable == true)//음식 미니게임
        {
            for (int i = 0; i < maxFood; i++)//손에 비어있는 자리가 있나 확인
            {
                if (foodStack.dishes[i] == 0)//비어있다면
                {
                    StatVar.instance.Movable = false;
                    switch (whichFood)
                    {
                        case 1:
                            minigame[0].SetActive(true);
                            break;
                        case 2:
                            minigame[1].SetActive(true);
                            break;
                        case 3:
                            minigame[2].SetActive(true);
                            break;
                        case 4:
                            minigame[3].SetActive(true);
                            break;
                    }
                    break;
                }
            }
        }
        switch (resultFood)
        {
            case 1:
                {
                    for (int i = 0; i < maxFood; i++)//음식 어디에 들지 결정
                    {
                        if (foodStack.dishes[i] == 0)
                        {
                            resultFood = 0;
                            foodStack.dishes[i] = 1;//요리 번호. 손에 들고있는 것의 실질적인 종류
                            Instantiate(foodButton2[0], foodInHerHand[i].transform, false);//손에 요리 스프라이트 생성
                            break;
                        }
                    }
                }
                break;
            case 2:
                {
                    for (int i = 0; i < maxFood; i++)//음식 어디에 들지 결정
                    {
                        if (foodStack.dishes[i] == 0)
                        {
                            resultFood = 0;
                            foodStack.dishes[i] = 2;//요리 번호. 손에 들고있는 것의 실질적인 종류
                            Instantiate(foodButton2[1], foodInHerHand[i].transform, false);//손에 요리 스프라이트 생성
                            break;
                        }
                    }
                }
                break;
            case 3:
                {
                    for (int i = 0; i < maxFood; i++)//음식 어디에 들지 결정
                    {
                        if (foodStack.dishes[i] == 0)
                        {
                            resultFood = 0;
                            foodStack.dishes[i] = 3;//요리 번호. 손에 들고있는 것의 실질적인 종류
                            Instantiate(foodButton2[2], foodInHerHand[i].transform, false);//손에 요리 스프라이트 생성
                            break;
                        }
                    }
                }
                break;
            case 4:
                {
                    for (int i = 0; i < maxFood; i++)//음식 어디에 들지 결정
                    {
                        if (foodStack.dishes[i] == 0)
                        {
                            resultFood = 0;
                            foodStack.dishes[i] = 4;//요리 번호. 손에 들고있는 것의 실질적인 종류
                            Instantiate(foodButton2[3], foodInHerHand[i].transform, false);//손에 요리 스프라이트 생성
                            break;
                        }
                    }
                }
                break;
        }
    }

    void Update()
    {
        maxFoodCount();
        GenerateFood();
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerMovement.hwalgiCount += 10;
        }
    }
}
