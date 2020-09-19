using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GameManager : MonoBehaviour
{
    public GameObject rd;
    public float rdtime;
    bool once = true;//여기까지 게임 스타트

    public bool plyrMovable = false;
    public float worldTime;
    public GameObject broom;
    Inventory inv;
    BroomAttack ba;

    void Start()
    {
        inv = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        inv.isFull[0] = true;
        Instantiate(broom, inv.slots[0].transform, false);
        inv.VisibleRange();
        ba = GameObject.FindWithTag("Player").GetComponent<BroomAttack>();
        worldTime = 0f;
        ba.FirstBlood = false;
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
                plyrMovable = true;
                worldTime = 1f;
            }
            if (rdtime < 0f)
            {
                rd.SetActive(false);
                rdtime = 0f;
            }
        }
    }
}
