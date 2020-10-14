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
    public PlayerMovement PlyMov;
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

    public GameObject fail; //여기서부터 사운드
    public GameObject enemyEnter;
    public GameObject uiSelect; //데이 클리어 후 씬 바뀌면 false로 초기화하기
    public GameObject icecreamSE;
    public GameObject dayClear;
    public GameObject pauseSE;
    public GameObject unable_to_cook;
    public GameObject get_food;
    public GameObject fail_food;
    public GameObject cashCash;
    public GameObject orderReceived;
    public GameObject order_disappear;
    public GameObject cokeSE;
    public GameObject frySE1;
    public GameObject frySE2;
    public GameObject hamburgerSE;


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

        //SE소스들 데이 시작때 비활성화
        fail.active = false;
        enemyEnter.active = false;
        uiSelect.active = false;
        icecreamSE.active = false;
        dayClear.active = false;
        pauseSE.active = false;
        unable_to_cook.active = false;
        get_food.active = false;
        fail_food.active = false;
        cashCash.active = false;
        orderReceived.active = false;
        order_disappear.active = false;
        cokeSE.active = false;
        frySE1.active = false;
        frySE2.active = false;
        hamburgerSE.active = false;

    }

    void enemy_enter_switch()
    {
        
        if(enemyEnter.active == false)
        {
            enemyEnter.active = true;
        }
        else if(enemyEnter.active == true)
        {
            enemyEnter.active = false;
        }
    }

    void uiSelect_switch()
    {
        if (uiSelect.active == false)
        {
            uiSelect.active = true;
        }
        else if (uiSelect.active == true)
        {
            uiSelect.active = false;
        }
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
            Invoke("enemy_enter_switch", 5f); //에너미가 스폰과 맵 등장이 차이가 나서 5f로 둠.
            Invoke("enemy_enter_switch", 2f);
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
            PlyMov.ResultSprite(false);
            fail.active = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                uiSelect.active = true;
                fail.active = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (timer.stageClear)
        {
            dayClear.active = true;
            curUI.transform.parent.gameObject.SetActive(true);
            curUI.sprite = announceUI[3];
            announce.gameObject.SetActive(true);
            announce.text = "Press [Enter] To Continue";
            gm.worldTime = 0f;
            gm.plyrMovable = false;
            PlyMov.ResultSprite(true);
            if (Input.GetKeyDown(KeyCode.Return))
                pressEnter = true;
            if (pressEnter)
            {
                uiSelect.active = true;
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
