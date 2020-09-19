using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditorInternal;

public class HP : MonoBehaviour
{
    //체력과 체력UI
    public int health = 3; //최대체력
    public GameObject heartShape; //하트모양 스프라이트
    public GameObject[] hpSlot = new GameObject[3]; //하트 박아 넣을 곳
    public GameObject gameOverUI;
    private bool[] hpMinus = { false, false, false };

    //게임오버 유아이
    public GameObject[] willYouContinue = new GameObject[2];
    public GameObject[] selectedWillYouContinue = new GameObject[2];
    public int selectedGameOverOption = 0;
    private WaitForSeconds gameOverCursorFadeIn = new WaitForSeconds(1.00f);//밝아지는 이펙트 지연시간
    private bool isSheDead = false;

    //다른 스크립트 불러오기
    private OrderTable orderUI;
    private TimeCount timeCount;
    private Cook cook;
    private PlayerMovement playerMovement;
    public GameManager gm;
    
    float BlinTime;//체력 떨어질때 깜빡임 효과
    float Btime;
    public bool isBlin;
    SpriteRenderer spr;


    //데이 시작할 때 필요한 세팅 (시간 설정)
    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void gameStart()
    {
        //if (유아이나 게임 스타트를 알리는 행동이 입력된다면) {} <- 이것도 메서드 하나 만들어야될듯. 유아이 출력과 입력 넣으려면
        orderUI = GameObject.FindGameObjectWithTag("Player").GetComponent<OrderTable>();
        timeCount = GameObject.FindGameObjectWithTag("timer").GetComponent<TimeCount>();
        cook = GameObject.FindGameObjectWithTag("CookPlace").GetComponent<Cook>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

    private void ContinueCursor()//선택 효과
    {
        StopAllCoroutines();
        Color color = selectedWillYouContinue[selectedGameOverOption].GetComponent<SpriteRenderer>().color;
        color.a = 1.0f;
        for (int i = 0; i < selectedWillYouContinue.Length; i++)
        {
            selectedWillYouContinue[i].GetComponent<SpriteRenderer>().color = color;
        }
        StartCoroutine(SelectedChoice());
    }

    IEnumerator SelectedChoice()//선택칸 밝게
    {
        Color color = selectedWillYouContinue[0].GetComponent<SpriteRenderer>().color;
        while (color.a > 0f)
        {
            color.a -= 0.6f;
            selectedWillYouContinue[selectedGameOverOption].GetComponent<SpriteRenderer>().color = color;
            yield return gameOverCursorFadeIn;
        }
    }

    private void answerSwitch()
    {
        if (isSheDead == true && Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            switch (selectedGameOverOption)
            {
                case 0: //1번이 예스 2번이 노
                    selectedGameOverOption = 1;
                    ContinueCursor();
                    break;
                case 1:
                    selectedGameOverOption = 0;
                    ContinueCursor();
                    break;
            }
        }
    }

    private void doYouContinue() //죽고서 재시작 누르면~
    {
        if (isSheDead == true && selectedGameOverOption == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            timeCount.TimeC = 90;
            orderUI.deliveryCount = 0;
            for (int i = 0; i < orderUI.orderRequested.Length; i++)
            {
                if (orderUI.orderRequested[i] != 0)
                {
                    orderUI.orderRequested[i] = 0;
                    Destroy(orderUI.orderTableSorted[i].transform.GetChild(0).gameObject, 0.1f);
                    Destroy(orderUI.orderTableSorted[i].transform.GetChild(1).gameObject, 0.1f);
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameStart();
        }
    }

    private void doYouContinue2() //일시정지에서 재시작 누르면~
    {
        if (timeCount.zaWarudo == true && timeCount.pOptionsHighlight == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            timeCount.TimeC = 90;
            orderUI.deliveryCount = 0;
            for (int i = 0; i < orderUI.orderRequested.Length; i++)
            {
                if (orderUI.orderRequested[i] != 0)
                {
                    orderUI.orderRequested[i] = 0;
                    orderUI.orderStatus[i] = 0;
                    Destroy(orderUI.orderTableSorted[i].transform.GetChild(0).gameObject, 0.1f);
                    Destroy(orderUI.orderTableSorted[i].transform.GetChild(1).gameObject, 0.1f);
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameStart();
        }
    }

    //데이 패배
    private void gameOver()
    {
        if (health <= 0)
        {
            isSheDead = true;
            //Time.timeScale = 0;
            playerMovement.enabled = false;
            cook.enabled = false;
            timeCount.enabled = false;
            orderUI.enabled = false;

            gameOverUI.SetActive(true);
            ContinueCursor();

            //이동불능, 조작불능. 이거 추가했다-윤호
            gm.plyrMovable = false;

            //유아이 개입
            //playTheDayAgain()
        }
    }

    private void healthPointMinus()
    {
        //hpMinus
        switch (health)
        {
            case 2:
                if (hpMinus[2] == false)
                {
                    hpMinus[2] = true;
                    Destroy(hpSlot[2].transform.GetChild(0).gameObject);
                }
                break;
            case 1:
                if (hpMinus[1] == false)
                {
                    hpMinus[1] = true;
                    Destroy(hpSlot[1].transform.GetChild(0).gameObject);
                }
                break;
            case 0:
                if (hpMinus[0] == false)
                {
                    hpMinus[0] = true;
                    Destroy(hpSlot[0].transform.GetChild(0).gameObject);
                }
                break;
        }
    }

    private void healthPointPlus() //체력 늘어나는 경우가 있을때 오류 생길수도 있으니 위의 불 리스트
    {
        switch (health)
        {
            case 1:
                if (!hpSlot[0].transform.GetChild(0))
                {
                    Instantiate(heartShape, hpSlot[0].transform, false);
                }
                break;
            case 2:
                if (!hpSlot[0].transform.GetChild(0))
                {
                    Instantiate(heartShape, hpSlot[0].transform, false);
                }
                if (!hpSlot[1].transform.GetChild(0))
                {
                    Instantiate(heartShape, hpSlot[1].transform, false);
                }
                break;
            case 3:
                if (!hpSlot[0].transform.GetChild(0))
                {
                    Instantiate(heartShape, hpSlot[0].transform, false);
                }
                if (!hpSlot[1].transform.GetChild(0))
                {
                    Instantiate(heartShape, hpSlot[1].transform, false);
                }
                if (!hpSlot[2].transform.GetChild(0))
                {
                    Instantiate(heartShape, hpSlot[2].transform, false);
                }
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //orderUI = GameObject.FindGameObjectWithTag("Player").GetComponent<OrderTableUIPopup>();
        //체력 3으로 맞추기. 게임 시작이 아니라 다른 타이밍에 체력이 3이 되어야 한다면 위치를 옮기세요~
        for (int i = 0; i < hpSlot.Length; i++)
        {
            Instantiate(heartShape, hpSlot[i].transform, false);
        }

        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            health--;
        }

        gameStart();


        //리스타트 기능: 디버그용
        if (Input.GetKeyDown(KeyCode.R))
        {
            timeCount.TimeC = 90;
            orderUI.deliveryCount = 0;
            for (int i = 0; i < orderUI.orderRequested.Length; i++)
            {
                if (orderUI.orderRequested[i] != 0)
                {
                    orderUI.orderRequested[i] = 0;
                    Destroy(orderUI.orderTableSorted[i].transform.GetChild(0).gameObject, 0.1f);
                    Destroy(orderUI.orderTableSorted[i].transform.GetChild(1).gameObject, 0.1f);
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            gameStart();
        }

        gameOver();
        healthPointMinus();
        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < 3; i++)
            {
                health--;
            }
        }
        if (isSheDead == true)
        {
            ContinueCursor();
            answerSwitch();
            doYouContinue();
        }

        if (timeCount.zaWarudo == true)
        {
            doYouContinue2();
        }

        if (isBlin)//총알 피격시 깜빡이는 효과-최윤호
        {
            BlinTime += Time.deltaTime;
            Btime += Time.deltaTime;
            if (Btime > 0.15f)
            {
                if (Btime > 0.3f)
                {
                    Btime = 0f;
                    spr.color = new Color(1, 0.5f, 0.5f, 1);
                }
                else
                {
                    spr.color = new Color(1, 0.5f, 0.5f, 0.5f);
                }
            }
            if (BlinTime > 1)
            {
                isBlin = false;
                Btime = 0f;
                BlinTime = 0f;
                spr.color = new Color(1, 1, 1, 1);
            }
        }
    }
}
