using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    GameManager gm;
    public Image curUI;
    public Sprite[] announceUI = new Sprite[4];
    public float rdtime;
    public bool once = true;//여기까지 게임 스타트

    public GameObject broom;
    Inventory inv;
    BroomAttack ba;
    public PlayerHP PlyHP;
    public Text announce;
    public bool end = false;
    public Timer timer;
    bool pressEnter = false;
    float nextDayFade = 0f;
    public Image DTB;

    float[] curCustomerTime = { 0f };//손님 스폰 관리
    public float maxCustomerTime = 18f;
    public NewOrder ord;

    public NewEnemySpawner eneSpawn;//적 스폰 관리
    float curEnemyTime = 0f;
    public float maxEnemyTime = 21f;

    public NewItemSpawner itemSpawn;//아이템 스폰 관리
    float curItemTime = 0f;
    public float maxItemTime = 15f;

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
        for(int i = 0; i < curCustomerTime.Length; i++) //curTime 개수 늘려서 손님 다중 소환 가능
        {
            curCustomerTime[i] += Time.deltaTime * gm.worldTime;
            if (curCustomerTime[i] > maxCustomerTime)
            {
                ord.CustomerSpawn();
                curCustomerTime[i] = 0f;
                maxCustomerTime = 12f;//이후 기본 손님 스폰시간
            }
        }

        curEnemyTime += Time.deltaTime * gm.worldTime;
        if (curEnemyTime > maxEnemyTime)
        {
            eneSpawn.SpawnEnemy();
            curEnemyTime = 0f;
            maxEnemyTime = 8f;//이후 기본 적 스폰시간
        }

        curItemTime += Time.deltaTime * gm.worldTime;
        if (curItemTime > maxItemTime)
        {
            itemSpawn.ItemSpawn();
            curItemTime = 0f;
        }

        if (PlyHP.curHP == 0)
        {
            curUI.transform.parent.gameObject.SetActive(true);
            curUI.sprite = announceUI[2];
            announce.gameObject.SetActive(true);
            announce.text = "Press [Enter] To Retry";
            gm.plyrMovable = false;
            gm.worldTime = 0f;
            if (Input.GetKeyDown(KeyCode.Return))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (timer.stageClear)
        {
            curUI.transform.parent.gameObject.SetActive(true);
            curUI.sprite = announceUI[3];
            announce.gameObject.SetActive(true);
            announce.text = "Press [Enter] To Continue";
            gm.worldTime = 0f;
            gm.plyrMovable = false;
            if (Input.GetKeyDown(KeyCode.Return))
                pressEnter = true;
            if (pressEnter)
            {
                nextDayFade += Time.deltaTime;
                DTB.gameObject.SetActive(true);
                DTB.color = new Color(0, 0, 0, nextDayFade);
                if (nextDayFade > 1f)
                {
                    nextDayFade = 1f;
                    Debug.Log("다음 데이로 진행");
                }
            }
        }
        if (once)
        {
            rdtime -= Time.deltaTime;
            if (rdtime < 0.5f)
            {
                curUI.sprite = announceUI[1];
                gm.plyrMovable = true;
                gm.worldTime = 1f;
                if (rdtime < 0f && once)
                {
                    once = false;
                    curUI.transform.parent.gameObject.SetActive(false);
                    rdtime = 0f;
                }
            }
        }
    }
}
