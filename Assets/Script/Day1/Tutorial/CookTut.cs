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

    public Transform AllDM;
    DControl dc;
    DialogueManager dm;
    public GameObject invisibleBlock;
    public bool AlreadyCooked;

    public GameObject foodButton2; //손에 들려줄 스프라이트
    public GameObject[] foodInHerHand;//주인공 손에 들려줄 스프라이트 스택
    public GameObject minigame;
    public int whichFood;
    public int resultFood;
    
    public GameManager gm;

    void Start()
    {
        dc = AllDM.GetComponent<DControl>();
        dm = AllDM.GetComponent<DialogueManager>();
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
                    dc.id = 10;
                    break;
                case 2:
                    dc.id = 20;
                    break;
                case 3:
                    dc.id = 30;
                    break;
                case 4:
                    {
                        if (!AlreadyCooked)
                            minigame.SetActive(true);
                        else
                        {
                            dc.id = 50;
                            dm.Action();
                        }
                    }
                    break;
            }
        }
        if (resultFood == 4)
        {
            resultFood = 0;
            AlreadyCooked = true;
            foodStack.dishes[0] = 4;
            Instantiate(foodButton2, foodInHerHand[0].transform, false);
            Destroy(invisibleBlock);
            dc.id = 500;
            dm.Action();
        }
        else if (resultFood == 5)
        {
            resultFood = 0;
            dc.id = 40;
            dm.Action();
        }
    }
}
