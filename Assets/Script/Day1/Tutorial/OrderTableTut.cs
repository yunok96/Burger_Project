using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OrderTableTut : MonoBehaviour
{
    public GameObject[] orderTables;//set to 6

    public int[] orderRequested = { 0, 0, 0, 0, 0, 0 }; //각 테이블 슬롯에 어떤 요리가 있는지 알려줌; 0은 없음
    public int[] orderStatus = new int[6]; //주문의 상황을 알려줌; 0은 없음, 1은 있음, 2는 시간만료됨, 3은 전달완료됨
    public GameObject orderUIBackground;
    public GameObject orderUIFood;
    public GameObject orderTableSorted;
    public int deliveryCount = 0;
    public DMTut dm;

    //전달완료 후 유아이 제거
    private GameObject[] objectToDestroy;

    bool isOnDeliveryTile = false;

    //다른 스크립트 불러오기
    FoodStack foodStack;
    BurgerTut onhand;

    public bool[] ActivedOrderList;

    //타이머
    //오더 스타트랑 중간에 밀려들어오는 오더 시간 다르게 하려면 변수 선언 추가.
    public GameObject orderTimeSlotUIBackground; //유아이 이미지 프리팹
    public GameObject orderTimeSlotTextMesh;

    void orderConfirm()//주문에 맞는 요리가 스택에 있는지
    {
        for (int i = 0; i < foodStack.dishes.Length; i++)
        {
            for (int y = 0; y < orderRequested.Length; y++)
            {
                if (foodStack.dishes[i] != 0 && orderRequested[y] != 0 && foodStack.dishes[i] == orderRequested[y]/* && orderStatus[i] != 0*/)
                {
                    ActivedOrderList[y] = false;//성공시 해당 주문 시간 카운트 해제.
                    deliveryCount++;//다음 이벤트로 가는 트리거
                    foodStack.dishes[i] = 0;
                    orderStatus[y] = 3;
                    Destroy(orderTableSorted.transform.GetChild(0).gameObject, 0.1f);
                    Destroy(orderTableSorted.transform.GetChild(1).gameObject, 0.1f);
                    Destroy(objectToDestroy[i].transform.GetChild(0).gameObject, 0.1f);
                    break;
                }
            }
        }
    }

    private void sortTheStackAgain()//푸드 스택: 빠른 순번 스택이 비었을때 늦은 순번 스택을 가져옴
    {
        for (int y = 1; y < foodStack.dishes.Length; y++)
        {
            if (foodStack.dishes[y] != 0 && foodStack.dishes[y - 1] == 0)
            {
                //들고 있는 음식의 identification 바꾸기
                foodStack.dishes[y - 1] = foodStack.dishes[y];
                foodStack.dishes[y] = 0;

                //리스트 안의 칠드런 값을 바꿔줘야 하는데 리스트 자체를 지워버림 오더 투 디스트로이 재검토 필요
                //전달 엔터가 여러번 눌려서 오류 일어나는듯
                Instantiate(objectToDestroy[y].transform.GetChild(0).gameObject, objectToDestroy[y - 1].transform);
                Destroy(objectToDestroy[y].transform.GetChild(0).gameObject);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) //캐릭터가 전달 타일 위에 있다면
    {
        if (other.CompareTag("orderTable"))
            isOnDeliveryTile = true;
    }

    void OnTriggerExit2D(Collider2D other) //캐릭터가 전달 타일을 떠난다면
    {
        if (other.CompareTag("orderTable"))
            isOnDeliveryTile = false;
    }

    public void orderCreate()
    {
        for (int i = 0; i < orderRequested.Length; i++)
        {
            if (orderRequested[i] == 0 && orderStatus[i] == 0)
            {
                orderRequested[i] = 4;
                orderStatus[i] = 1;
                ActivedOrderList[i] = true;//주문이 들어오면 해당 주문의 시간 카운트 시작
                Instantiate(orderUIBackground, orderTableSorted.transform, false);
                Instantiate(orderUIFood, orderTableSorted.transform, false);
                break;
            }
        }
    }

    void Start()
    {
        foodStack = GameObject.FindGameObjectWithTag("Player").GetComponent<FoodStack>();
        onhand = GameObject.FindGameObjectWithTag("CookPlace").GetComponent<BurgerTut>();
        //objectToDestroy = onhand.foodInHerHand;
    }

    void Update()
    {
        if (deliveryCount == 1)
        {
            deliveryCount = 0;
            dm.id = 600;
            dm.Action();
        }
        sortTheStackAgain(); //손에든 음식 순서 정리
        if (isOnDeliveryTile == true && Input.GetKeyDown(KeyCode.Return))
            orderConfirm();
    }
}
