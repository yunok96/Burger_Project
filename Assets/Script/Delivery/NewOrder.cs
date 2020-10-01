using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrder : MonoBehaviour
{
    public GameManager gm;
    public GameObject[] customers = new GameObject[3];
    public bool[] isTableOnOrder = { false, false, false, false, false, false };
    public Transform[] customerSpawnPoints = new Transform[6];
    public Transform[] targetTables;
    public GameObject[] customerSpec = new GameObject[6];

    public GameObject[] foodButton = new GameObject[4];
    public int whereIsPlayer = 0;
    public DisplayOrder[] dispOrder = new DisplayOrder[6];
    public FoodStack foodstack;
    public PlayerHP hp;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && whereIsPlayer!=0 && gm.plyrMovable)
        {
            for (int i = 0; i < foodstack.dishes.Length; i++)
            {
                if (foodstack.dishes[i] == (dispOrder[whereIsPlayer - 1].findOrder.GetComponent<OrderSpec>().whatsThis) + 1)
                {
                    customerSpec[whereIsPlayer - 1].GetComponent<CustomerMove>().isGetFood = true;
                    Instantiate(foodButton[foodstack.dishes[i] - 1], customerSpec[whereIsPlayer - 1].transform.GetChild(0), false);
                    Destroy(dispOrder[whereIsPlayer - 1].findOrder);
                    foodstack.dishes[i] = 0;
                    Destroy(foodstack.onHerHands[i].GetChild(0).gameObject);
                    foodstack.Delivery();
                    break;
                }
            }
        }
    }

    public void CustomerSpawn()
    {
        for (int i = 0; i < isTableOnOrder.Length; i++)
        {
            if (!isTableOnOrder[i])
            {
                isTableOnOrder[i] = true;
                int ranCus = Random.Range(0, 3);
                customerSpec[i] = Instantiate(customers[ranCus], customerSpawnPoints[i]);
                switch (i)
                {
                    case 0:
                        {
                            customerSpec[i].GetComponent<CustomerMove>().targetTable = new Vector3(-12, 3.5f, 0.6f);
                            customerSpec[i].GetComponent<CustomerMove>().whoIsMe = 0;
                        }
                        break;
                    case 1:
                        {
                            customerSpec[i].GetComponent<CustomerMove>().targetTable = new Vector3(-12, 2.5f, 0.5f);
                            customerSpec[i].GetComponent<CustomerMove>().whoIsMe = 1;
                        }
                        break;
                    case 2:
                        {
                            customerSpec[i].GetComponent<CustomerMove>().targetTable = new Vector3(-12, 1.5f, 0.4f);
                            customerSpec[i].GetComponent<CustomerMove>().whoIsMe = 2;
                        }
                        break;
                    case 3:
                        {
                            customerSpec[i].GetComponent<CustomerMove>().targetTable = new Vector3(-12, -0.5f, 0.3f);
                            customerSpec[i].GetComponent<CustomerMove>().whoIsMe = 3;
                        }
                        break;
                    case 4:
                        {
                            customerSpec[i].GetComponent<CustomerMove>().targetTable = new Vector3(-12, -1.5f, 0.2f);
                            customerSpec[i].GetComponent<CustomerMove>().whoIsMe = 4;
                        }
                        break;
                    case 5:
                        {
                            customerSpec[i].GetComponent<CustomerMove>().targetTable = new Vector3(-12, -2.5f, 0.1f);
                            customerSpec[i].GetComponent<CustomerMove>().whoIsMe = 5;
                        }
                        break;
                }
                break;
            }
        }
    }

    public void damage()
    {
        for (int i = 0; i < dispOrder.Length; i++)
        {
            if (dispOrder[i].failed)
            {
                dispOrder[i].failed = false;
                Destroy(dispOrder[i].findOrder);
                customerSpec[i].GetComponent<CustomerMove>().isGetFood = true;
                hp.HPSet();
                break;
            }
        }
    }
}
