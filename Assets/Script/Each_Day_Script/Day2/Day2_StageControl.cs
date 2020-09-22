using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Day2_StageControl : MonoBehaviour
{
    GameManager gm;
    public DM_Day2_Game dm;
    
    public GameObject rd;
    public float rdtime;
    bool once = true;//여기까지 게임 스타트
    public GameObject broom;
    Inventory inv;
    BroomAttack ba;
    public int iGotAGun = 0;
    public int jujeongKilled = 0;
    bool routeB = false;
    bool dont = false;
    float dontmove = 0f;//얼음땡

    void Awake()
    {
        gm = GetComponent<GameManager>();
    }

    void Start()
    {
        inv = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        inv.isFull[0] = true;
        Instantiate(broom, inv.slots[0].transform, false);
        inv.VisibleRange();
        ba = GameObject.FindWithTag("Player").GetComponent<BroomAttack>();
        ba.FirstBlood = false;
        rdtime = 1.5f;
    }
    void Update()
    {
        //routeB true인 상태로 데이 끝나면 씬 다른걸 불러오게 해야됨
        rdtime -= Time.deltaTime;
        if (rdtime < 0.5f)
        {
            rd.transform.GetChild(0).gameObject.SetActive(false);
            rd.transform.GetChild(1).gameObject.SetActive(true);
            if (once)
            {
                once = false;
                gm.plyrMovable = true;
                gm.worldTime = 1f;
            }
            if (rdtime < 0f)
            {
                rd.SetActive(false);
                rdtime = 0f;
            }
        }
        if (iGotAGun == 1)
        {
            dont = true;
            iGotAGun = 2;
            dm.id = 2100;
            dm.Action();
        }
        if (jujeongKilled == 1)
        {
            dont = true;
            jujeongKilled = 2;
            routeB = true;
            dm.id = 2200;
            dm.Action();
        }
        if (dont)
        {
            dontmove += Time.deltaTime;
            gm.plyrMovable = false;
            if (dontmove > 1f)
            {
                dont = false;
                dontmove = 0f;
            }
        }
    }
}
