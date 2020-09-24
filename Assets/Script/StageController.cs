using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    GameManager gm;
    public Image curUI;
    public Sprite[] announceUI = new Sprite[4];
    public float rdtime;
    bool once = true;//여기까지 게임 스타트
    public GameObject broom;
    Inventory inv;
    BroomAttack ba;
    public PlayerHP PlyHP;

    public bool end = false;

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
        if (PlyHP.curHP == 0)
        {
            PlyHP.curHP = -1;
            gm.plyrMovable = false;
            gm.worldTime = 0f;
        }
        if (end)
        {
            end = false;
            gm.plyrMovable = false;
            gm.worldTime = 0f;
            curUI.transform.parent.gameObject.SetActive(true);
        }

        rdtime -= Time.deltaTime;
        if (rdtime < 0.5f)
        {
            curUI.sprite = announceUI[1];
            if (once)
            {
                once = false;
                gm.plyrMovable = true;
                gm.worldTime = 1f;
            }
            if (rdtime < 0f)
            {
                curUI.transform.parent.gameObject.SetActive(false);
                rdtime = 0f;
            }
        }
    }
}
