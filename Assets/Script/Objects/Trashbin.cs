using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trashbin : MonoBehaviour
{
    private FoodStack foodStack;
    private Cook cook;

    private bool helloBurgerGirl;
    // Start is called before the first frame update
    void Start()
    {
        foodStack = GameObject.FindGameObjectWithTag("Player").GetComponent<FoodStack>();
        cook = GameObject.FindGameObjectWithTag("CookPlace").GetComponent<Cook>();
    }

    private void OnTriggerStay2D(Collider2D other) //캐릭터가 쓰레기통 타일 위에 있다면
    {
        if (other.CompareTag("Player"))
        {
            helloBurgerGirl = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) //캐릭터가 쓰레기통 타일 위를 떠난다면
    {
        if (other.CompareTag("Player"))
        {
            helloBurgerGirl = false;
        }
    }

    private void disposeYourDishes()
    {
        if (helloBurgerGirl == true && Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < foodStack.dishes.Length; i++)
            {
                if (foodStack.dishes[i] != 0)
                {
                    Destroy(cook.foodInHerHand[i].transform.GetChild(0).gameObject, 0.1f);
                }
                foodStack.dishes[i] = 0;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        disposeYourDishes();
    }
}
