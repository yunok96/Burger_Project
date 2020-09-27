using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1_StageControl : MonoBehaviour
{
    GameManager gm;
    
    public GameObject rd;
    public float rdtime;
    bool once = true;//여기까지 게임 스타트
    public GameObject broom;
    Inventory inv;
    BroomAttack ba;

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
        ba.FirstBlood = true;
        rdtime = 1.5f;
    }
    void Update()
    {
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
    }
}
