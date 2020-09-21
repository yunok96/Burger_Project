using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CookTut : MonoBehaviour
{
    FoodStack foodStack;
    PlayerMovement playerMovement;

    public DMTut dm;
    public GameObject invisibleBlock;
    bool AlreadyCooked;

    public GameObject foodButton2; //손에 들려줄 스프라이트
    public GameObject foodInHerHand;//주인공 손에 들려줄 스프라이트 스택
    public GameObject minigame;
    public int whichFood;
    public int resultFood;
    
    public GameManager gm;
    int DialCount = 0;

    void Start()
    {
        foodStack = GameObject.FindGameObjectWithTag("Player").GetComponent<FoodStack>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && gm.plyrMovable && whichFood != 0)//음식 미니게임
        {
            gm.plyrMovable = false;

            switch (whichFood)
            {
                case 1:
                    dm.id = 10;
                    break;
                case 2:
                    dm.id = 20;
                    break;
                case 3:
                    {
                        DialCount++;
                        if (DialCount > 7)
                        {
                            if (DialCount == 8)
                                dm.id = 31;
                            else if (DialCount == 9)
                                dm.id = 32;
                            else
                                dm.id = 33;
                        }
                        else
                            dm.id = 30;
                    }
                    break;
                case 4:
                    {
                        if (!AlreadyCooked)
                            minigame.SetActive(true);
                        else
                            dm.id = 50;
                    }
                    break;
            }
        }
        if (resultFood == 4)
        {
            resultFood = 0;
            AlreadyCooked = true;
            foodStack.dishes[0] = 4;
            Instantiate(foodButton2, foodInHerHand.transform, false);
            Destroy(invisibleBlock);
            dm.id = 500;
            dm.Action();
        }
        else if (resultFood == 5)
        {
            resultFood = 0;
            dm.id = 40;
            dm.Action();
        }
    }
}
