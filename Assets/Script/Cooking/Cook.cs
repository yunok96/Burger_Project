using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cook : MonoBehaviour
{
    private FoodStack foodStack;
    private PlayerMovement playerMovement;

    public GameObject[] foodButton2; //손에 들려줄 스프라이트
    public GameObject[] foodInHerHand;//주인공 손에 들려줄 스프라이트 스택
    public bool isTheCharacterOn = false; //캐릭터가 조리타일에 있는지
    public int whichFood; //어떤 음식을 생산하는지 1, 2, 3
    private int maxFood; //최대 소지 가능 음식 숫자. 활기에 따라 달라짐.

    void Start()
    {
        foodStack = GameObject.FindGameObjectWithTag("Player").GetComponent<FoodStack>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)//캐릭터가 조리 타일 위에 있다면
    {
        if (other.CompareTag("Player"))
        {
            isTheCharacterOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isTheCharacterOn = false;
        }
    }

    private void maxFoodCount()//최대 음식수 설정
    {
        if (playerMovement.hwalgiCount < 20)
        {
            maxFood = 1;
        }
        else if (playerMovement.hwalgiCount >= 20 && playerMovement.hwalgiCount < 40)
        {
            maxFood = 2;
        }
        else if (playerMovement.hwalgiCount >= 40 && playerMovement.hwalgiCount < 60)
        {
            maxFood = 3;
        }
        else if (playerMovement.hwalgiCount >= 60 && playerMovement.hwalgiCount < 80)
        {
            maxFood = 4;
        }
        else if (playerMovement.hwalgiCount >= 80)
        {
            maxFood = 5;
        }
    }

    private void GenerateFood() //음식 만들기. int 1 감튀, 2 아이스, 3 음료, 4 햄버거
    {
        if (isTheCharacterOn == true && Input.GetKeyDown(KeyCode.Return) && StatVar.instance.Movable == true)//음식 미니게임
        {
            for (int i = 0; i < maxFood; i++)//손에 비어있는 자리가 있나 확인
            {
                if (foodStack.dishes[i] == 0)//비어있다면
                {
                    StatVar.instance.Movable = false;
                    switch (whichFood)
                    {
                        case 1:
                            {
                                SceneManager.LoadScene("FryGame", LoadSceneMode.Additive);
                            }   
                            break;
                        case 2:
                            {
                                SceneManager.LoadScene("IceGame", LoadSceneMode.Additive);
                            }
                            break;
                        case 3:
                            {
                                SceneManager.LoadScene("ColaGame", LoadSceneMode.Additive);
                            }
                            break;
                        case 4:
                            {
                                SceneManager.LoadScene("BurgerGame", LoadSceneMode.Additive);
                            }
                            break;
                    }
                    break;
                }
                else
                    Debug.Log("손이 한가득이야...");
            }
        }
        if((StatVar.instance.FrySuc) || (StatVar.instance.ColaSuc) || (StatVar.instance.BurSuc)||(StatVar.instance.IceSuc))
        {
            if (StatVar.instance.FrySuc)
            {
                for (int i = 0; i < maxFood; i++)//음식 어디에 들지 결정
                {
                    if (foodStack.dishes[i] == 0)
                    {
                        foodStack.dishes[i] = 1;//요리 번호. 손에 들고있는 것의 실질적인 종류
                        StatVar.instance.FrySuc = false;
                        Instantiate(foodButton2[0], foodInHerHand[i].transform, false);//손에 요리 스프라이트 생성
                        break;
                    }
                }
            } else if (StatVar.instance.ColaSuc)
            {
                for (int i = 0; i < maxFood; i++)
                {
                    if (foodStack.dishes[i] == 0)
                    {
                        foodStack.dishes[i] = 3;
                        StatVar.instance.ColaSuc = false;
                        Instantiate(foodButton2[2], foodInHerHand[i].transform, false);
                        break;
                    }
                }
            }
            else if (StatVar.instance.BurSuc)
            {
                for (int i = 0; i < maxFood; i++)
                {
                    if (foodStack.dishes[i] == 0)
                    {
                        foodStack.dishes[i] = 4;
                        StatVar.instance.BurSuc = false;
                        Instantiate(foodButton2[3], foodInHerHand[i].transform, false);
                        break;
                    }
                }
            }
            else if (StatVar.instance.IceSuc)
            {
                for (int i = 0; i < maxFood; i++)
                {
                    if (foodStack.dishes[i] == 0)
                    {
                        foodStack.dishes[i] = 2;
                        StatVar.instance.IceSuc = false;
                        Instantiate(foodButton2[1], foodInHerHand[i].transform, false);
                        break;
                    }
                }
            }
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
