using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OrderTable : MonoBehaviour
{
    //전달 스코어 0으로 시작. 최저값/최대값 없음.
    /*
    public int compltedOrderCount;//전달 완료 카운트
    public Text completedOrderValue;//UI 전달 완료 값*/

    public GameObject[] orderTables;//set to 6

    Random givenOrder = new Random();//givenOrder.Next(Int32 min, Int32 max);

    //전달 스코어 0으로 시작. 최저값/최대값 없음.
    public int deliveryCount = 0;
    public Text deliveryText;

    //유니티에서 테이블 숫자만큼 설정해주고 테이블 겜오브젝트 집어넣기
    //public Animator animator;
    public int[] orderRequested = { 0, 0, 0, 0, 0, 0 }; //각 테이블 슬롯에 어떤 요리가 있는지 알려줌; 0은 없음
    public int[] orderStatus = new int[6]; //주문의 상황을 알려줌; 0은 없음, 1은 있음, 2는 시간만료됨, 3은 전달완료됨
    public GameObject hiImTemp;
    public GameObject orderUIBackground;
    public GameObject[] orderUIFood;
    public GameObject[] orderTableSorted;

    //전달완료 후 유아이 제거
    private GameObject[] objectToDestroy;

    //전달 타일 위에 있는지
    public bool isOnDeliveryTile = false;

    //다른 스크립트 불러오기
    private FoodStack foodStack;
    private Cook cook;
    private HP hp;
    private CustomerSpawn customerSpawn;

    float CurNextOrderTime;
    public bool[] ActivedOrderList;
    public GameManager gm;

    //타이머
    //오더 스타트랑 중간에 밀려들어오는 오더 시간 다르게 하려면 변수 선언 추가.
    public GameObject[] orderTimeSlots = new GameObject[6]; //시간 유아이가 들어갈 자리
    public GameObject orderTimeSlotUIBackground; //유아이 이미지 프리팹
    public GameObject orderTimeSlotTextMesh;

    /*손님
    public GameObject[] customers = new GameObject[2]; //손님종류
    public GameObject[] customersSpot = new GameObject[6]; //손님 스폰 위치와 전달끝/시간초과 시 돌아갈 타일*/

    void orderConfirm()//주문에 맞는 요리가 스택에 있는지
    {
        for (int i = 0; i < foodStack.dishes.Length; i++)
        {
            for (int y = 0; y < orderRequested.Length; y++)
            {
                if (foodStack.dishes[i] != 0 && orderRequested[y] != 0 && foodStack.dishes[i] == orderRequested[y]/* && orderStatus[i] != 0*/)
                {
                    ActivedOrderList[y] = false;//성공시 해당 주문 시간 카운트 해제.
                    deliveryCount = deliveryCount + 1;
                    foodStack.dishes[i] = 0;
                    orderStatus[y] = 3;
                    //orderRequested[y] = 0;//주문에 밀려있는 스프라이트도 destroy로 제거
                    /* 주문전달 보류중인 코드들. 손님 오브젝트가 Null reference로 들어가서 겜옵젝이 안들어가는 오류가 있음
                    Instantiate(orderUIFood[0], hiImTemp.transform, false);
                    hiImTemp.transform.parent = customerSpawn.spawnSlots[i].transform.GetChild(0).transform.GetChild(0).transform;
                    //customerSpawn.spawnSlots[i].transform.GetChild(0).transform.GetChild(0).transform
                    */
                    //
                    Destroy(orderTableSorted[y].transform.GetChild(0).gameObject, 0.1f);
                    Destroy(orderTableSorted[y].transform.GetChild(1).gameObject, 0.1f);
                    Destroy(objectToDestroy[i].transform.GetChild(0).gameObject, 0.1f);
                    Destroy(orderTimeSlots[y].transform.GetChild(0).gameObject, 0.1f);
                    Destroy(orderTimeSlots[y].transform.GetChild(1).gameObject, 0.1f);
                    //Destroy(foodStack.dishStacks[i].transform.GetChild(0).gameObject, 0.1f);

                    //손님 손에 음식 들려주기

                    

                    break;
                }
            }
        }
    }
    //주문이 다르면 체력을 깎으시오 - 기획상 들어가있지는 않지만 후에 생길 수도 있어서 남겨둠
    /*private void orderDifferent()
    {
        for (int i = 0; i < foodStack.dishes.Length; i++)
        {
            for (int y = 0; y < orderRequested.Length; y++)
            {
                if (foodStack.dishes[i] == orderRequested[y] && orderRequested[y] != 0)
                {
                    break;
                }
                else
                {
                    hp.health -= 1;
                    break;
                }
            }
        }
    }*/

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

                //작동하는 코드. 위의 코드가 불량일때 부활
                //objectToDestroy[y].transform.GetChild(0).SetParent(objectToDestroy[y - 1].transform);

                //푸드스택 UI의 순서 변경
                /*
                Instantiate(foodStack.dishStacks[y].transform.GetChild(0).gameObject, foodStack.dishStacks[y - 1].transform);
                Destroy(foodStack.dishStacks[y].transform.GetChild(0).gameObject);
                */
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) //캐릭터가 전달 타일 위에 있다면
    {
        if (other.CompareTag("orderTable"))
        {
            isOnDeliveryTile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) //캐릭터가 전달 타일을 떠난다면
    {
        if (other.CompareTag("orderTable"))
        {
            isOnDeliveryTile = false;
        }
    }

    private void orderCreate()
    {
        for (int i = 0; i < orderRequested.Length; i++)
        {
            if (orderRequested[i] == 0 && orderStatus[i] == 0)
            {
                //orderTimeLimit[i] = 5;
                //orderTimeLimitText.text = orderTimeLimit.ToString();
                //주문 랜덤 생성. 요구는 왓푸드랑 숫자 맞춰서.
                orderRequested[i] = Random.Range(1, 5);
                orderStatus[i] = 1;
                ActivedOrderList[i] = true;//주문이 들어오면 해당 주문의 시간 카운트 시작
                //foodStack.thirtySeconds[i] = Time.timeSinceLevelLoad;
                Instantiate(orderUIBackground, orderTableSorted[i].transform, false);
                Instantiate(orderTimeSlotUIBackground, orderTimeSlots[i].transform, false);
                Instantiate(orderTimeSlotTextMesh, orderTimeSlots[i].transform, false);
                switch (orderRequested[i])//유아이 만들기
                {
                    case 1:
                        Instantiate(orderUIFood[0], orderTableSorted[i].transform, false);
                        //instantiate(orderRequested[i]UI, orderTableSlots[i], null)
                        break;
                    case 2:
                        Instantiate(orderUIFood[1], orderTableSorted[i].transform, false);
                        break;
                    case 3:
                        Instantiate(orderUIFood[2], orderTableSorted[i].transform, false);
                        break;
                    case 4:
                        /* 원래코드. 케이스 안 공통함수는 스위치 밖으로 뺐는데 문제생기면 아래의 함수식으로 회귀
                        Instantiate(orderUIBackground, orderTableSorted[i].transform, false);
                        여기에 넣어 음식 스프라이트
                        Instantiate(orderTimeSlotUIBackground, orderTimeSlots[i].transform, false);
                        Instantiate(orderTimeSlotTextMesh, orderTimeSlots[i].transform, false);*/
                        Instantiate(orderUIFood[3], orderTableSorted[i].transform, false);
                        break;
                }
                break;
            }
        }
    }
    
    private void thirtySecVisual()
    {
        for (int i = 0; i < foodStack.thirtySeconds.Length; i++)
        {
            if (foodStack.thirtySeconds[i] != 0 && orderStatus[i] == 1 && orderRequested[i] != 0)
            {
                float timeshow = 30f - foodStack.thirtySeconds[i];
                orderTimeSlots[i].transform.GetChild(1).GetComponent<TextMesh>().text = ((int)timeshow).ToString();
            }
        }
    }


    //주문이 들어왔음에도 시간 내에 해결을 하지 못한 경우
    private void timeOver()
    {
        for (int i = 0; i < orderRequested.Length; i++)
        {
            if (foodStack.thirtySeconds[i] >= 30f && foodStack.thirtySeconds[i] != 0 && orderStatus[i] == 1)
            {
                ActivedOrderList[i] = false;//해당 테이블의 bool값 해제해서 타이머 멈춤.
                orderRequested[i] = 0;
                orderStatus[i] = 2;
                foodStack.thirtySeconds[i] = 0;
                Destroy(orderTableSorted[i].transform.GetChild(0).gameObject, 0.1f); //버그 고치기 **위에 조건문 조건식이 문제 있는듯. foodStack.thirtySeconds 정리 혹은 재구성
                Destroy(orderTableSorted[i].transform.GetChild(1).gameObject, 0.1f);
                Destroy(orderTimeSlots[i].transform.GetChild(0).gameObject, 0.1f);
                Destroy(orderTimeSlots[i].transform.GetChild(1).gameObject, 0.1f);
                hp.health -= 1;
                break;
            }
        }
    }

    void Start()
    {
        foodStack = GameObject.FindGameObjectWithTag("Player").GetComponent<FoodStack>();
        cook = GameObject.FindGameObjectWithTag("CookPlace").GetComponent<Cook>();
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<HP>();
        customerSpawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CustomerSpawn>();
        objectToDestroy = cook.foodInHerHand;
    }

    void Update()
    {
        for(int i = 0; i < 6; i++)//최윤호. 주문 흘러가는 시간을 deltatime으로 바꾸려면 void update에 있어야되서 각 주문 번호에 bool값 설정함. 
        {
            if (ActivedOrderList[i])
                foodStack.thirtySeconds[i] += Time.deltaTime * gm.worldTime;
            else
                foodStack.thirtySeconds[i] = 0f;
        }

        CurNextOrderTime += Time.deltaTime * gm.worldTime;
        if (CurNextOrderTime > 5f)
        {
            CurNextOrderTime = 0f;
            orderCreate(); //주문생성
        }
        
        sortTheStackAgain(); //손에든 음식 순서 정리
        
        if (isOnDeliveryTile == true && Input.GetKeyDown(KeyCode.Return))
        {
            //푸드스텍 체크해보고 orderRequested랑 일치하면 해당 변수 지우고 정리(쿠킹or다른 스크립트 안에 잇음) 전달 스텍 1 쌓임.
            orderConfirm();
            //orderDifferent();
        }
        thirtySecVisual();
        timeOver(); //주문만료
    }
}
