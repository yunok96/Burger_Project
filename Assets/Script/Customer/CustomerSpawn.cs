using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerSpawn : MonoBehaviour
{
    float CurCustomerTime;
    private bool[] isSonThere = new bool[6]; //손님이 있는가?
    public bool isSonDeadYet = false;
    //private bool isFoodinHands = false;
    public GameObject[] spawnSlots = new GameObject[6]; //손님 생성위치
    public GameObject[] customerSprites = new GameObject[3]; //손님 스프라이트
    public GameObject[] foodInSonnimHands = new GameObject[4];//손님 손에 들려줄 음식

    //다른 코드 불러오기
    private OrderTable orderTable;

    //손님아 움직여
    private Vector3 s1; //손님 이동목표: 테이블 앞; 주문생성시 입장
    private Vector3 s2; //손님 이동목표: 테이블 밖; 주문소멸시 퇴장
    public GameManager gm;

    private void Spawn() //손님 소환 및 테이블 앞까지 걸어가기
    {
        for (int i = 0; i < orderTable.orderStatus.Length; i++)
        {
            if (orderTable.orderStatus[i] == 0 && isSonThere[i] != true)
            {
                Instantiate(customerSprites[Random.Range(0, 3)], spawnSlots[i].transform, false);
                /*if(spawnSlots[i].transform.GetChild(0).position != customerDestination[i].transform.position)
                {
                    //spawnSlots[i].transform.GetChild(0).position += Vector3.right * customerSpeed * Time.deltaTime;
                        //Vector3.MoveTowards(spawnSlots[i].transform.GetChild(0).position, customerDestination[i].transform.position, customerSpeed * Time.deltaTime);
                }*/
                isSonThere[i] = true;
                break;
            }
        }
    }

    private void walkinCstmr()
    {
        for (int i = 0; i < orderTable.orderRequested.Length; i++)
        {
            if (orderTable.orderRequested[i] != 0 && isSonThere[i] == true)
            {
                switch (i)
                {
                    case 0:
                        s1 = new Vector3(-12.1f, 3.5f, 0.0f);
                        break;
                    case 1:
                        s1 = new Vector3(-12.1f, 2.5f, 0.0f);
                        break;
                    case 2:
                        s1 = new Vector3(-12.1f, 1.5f, 0.0f);
                        break;
                    case 3:
                        s1 = new Vector3(-12.1f, -0.5f, 0.0f);
                        break;
                    case 4:
                        s1 = new Vector3(-12.1f, -1.5f, 0.0f);
                        break;
                    case 5:
                        s1 = new Vector3(-12.1f, -2.5f, 0.0f);
                        break;
                }
                spawnSlots[i].transform.GetChild(0).position = Vector3.Lerp(spawnSlots[i].transform.GetChild(0).position, s1, 0.1f);
            }

        }
    }

    private void walkoutCstmr()
    {
        for (int i = 0; i < orderTable.orderStatus.Length; i++)
        {
            //if(isSonThere[i] == true)
            //{
                if (orderTable.orderStatus[i] == 2 || orderTable.orderStatus[i] == 3)
                {
                    switch (i)
                    {
                        case 0:
                            s2 = new Vector3(-17.0f, 3.5f, 0.0f);
                            break;
                        case 1:
                            s2 = new Vector3(-17.0f, 2.5f, 0.0f);
                            break;
                        case 2:
                            s2 = new Vector3(-17.0f, 1.5f, 0.0f);
                            break;
                        case 3:
                            s2 = new Vector3(-17.0f, -0.5f, 0.0f);
                            break;
                        case 4:
                            s2 = new Vector3(-17.0f, -1.5f, 0.0f);
                            break;
                        case 5:
                            s2 = new Vector3(-17.0f, -2.5f, 0.0f);
                            break;
                    }
                    spawnSlots[i].transform.GetChild(0).transform.position = Vector3.Lerp(spawnSlots[i].transform.GetChild(0).transform.position, s2, 0.03f); //버그발생?
                }
                if(orderTable.orderStatus[i] == 3)
                {
                    if(orderTable.orderRequested[i] == 0)
                {
                    break;
                }
                else
                {
                    Instantiate(foodInSonnimHands[orderTable.orderRequested[i] - 1], spawnSlots[i].transform.GetChild(0).transform.GetChild(0).transform, false);
                    orderTable.orderRequested[i] = 0;
                }
                        
            }
            //}
        }
    }


    private void killSonnim()
    {
        if(isSonDeadYet == true)
        {
            for (int i = 0; i < orderTable.orderStatus.Length; i++)
            {
                if (orderTable.orderStatus[i] == 2 || orderTable.orderStatus[i] == 3) /* 아래 코드 아직 안바꿈 */
                {
                    //오류나옴 null reference 프리팹으로 만든 겜오브젝트가 null? 
                    Destroy(spawnSlots[i].transform.GetChild(0).gameObject, 0.1f);
                    isSonThere[i] = false;
                    isSonDeadYet = false;
                    orderTable.orderStatus[i] = 0;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        orderTable = GameObject.FindGameObjectWithTag("Player").GetComponent<OrderTable>();
        for (int i = 0; i < isSonThere.Length; i++)
        {
            isSonThere[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurCustomerTime += Time.deltaTime * gm.worldTime;
        if (CurCustomerTime > 4.9f)
        {
            CurCustomerTime = 0f;
            Spawn();
        }
        walkinCstmr();
        walkoutCstmr();
        killSonnim();
    }
}
