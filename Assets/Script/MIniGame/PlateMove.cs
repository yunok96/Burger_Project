﻿using UnityEngine;
using UnityEngine.UI;

public class PlateMove : MonoBehaviour
{
    bool isRight;
    bool isLeft;
    public Sprite[] BurSpr;
    SpriteRenderer sr;
    BoxCollider2D Col;

    bool CountDone;
    float WaitTime;
    public bool BurControl;
    public Text BurText;

    public Transform[] SpawnPoint;
    public GameObject[] BurIng;
    bool IngStart;
    public GameObject ABtn;
    public GameObject DBtn;
    public bool Textoff;
    Cook ck;

    public GameObject get_food;
    public GameObject hamburgerSE;

    void Awake()
    {
        ck = GameObject.FindWithTag("CookPlace").GetComponent<Cook>();
        sr = GetComponent<SpriteRenderer>();
        Col = GetComponent<BoxCollider2D>();
    }

    void OnEnable()
    {
        CountDone = true;
        isRight = false;
        isLeft = false;
        BurControl = false;
        WaitTime = 2f;
        IngStart = false;
        Textoff = false;
        ABtn.SetActive(true);
        DBtn.SetActive(true);
        sr.sprite = BurSpr[0];
        DBtn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.75f);
        ABtn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.75f);
        transform.position = new Vector3(20, -1.2f, 0);
        Col.offset = new Vector2(0, -0.4f);
    }

    void Update()
    {
        if(CountDone == true)
        {
            BurText.text = "준비...";
            WaitTime -= Time.deltaTime;
            if (WaitTime < 0.01f)
            {
                CountDone = false;
                BurControl = true;
                BurText.text = "시작!";
                if (IngStart == false)
                {
                    int Point = Random.Range(0, 9);
                    Instantiate(BurIng[0], SpawnPoint[Point]);
                    IngStart = true;
                }
            }
        }
        if (Textoff)
            BurText.text = null;
        if(BurControl == true)
        {
            //float h = Input.GetAxisRaw("Horizontal");
            float h = 0f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                h = -1f;
            }else if (Input.GetKey(KeyCode.RightArrow))
            {
                h = 1f;
            }
            if (h == 1)
            {
                DBtn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
                Textoff = true;
            }
            if (h == -1)
            {
                ABtn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
                Textoff = true;
            }
            if (h == 0)
            {
                DBtn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.75f);
                ABtn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.75f);
            }
            if ((isRight && h == 1) || (isLeft && h == -1))
                h = 0;
            Vector3 cur = transform.position;
            Vector3 next = new Vector3(h, 0f, 0f) * Time.deltaTime * 10;
            transform.position = cur + next;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            switch (collision.gameObject.name)
            {
                case "Right Wall":
                        isRight = true;
                    break;
                case "Left Wall":
                        isLeft = true;
                    break;
            }
        }

        switch (collision.gameObject.name)
        {
            case "B1(Clone)":
                {
                    hamburgerSE.active = false;
                    hamburgerSE.active = true;
                    Destroy(collision.gameObject);
                    sr.sprite = BurSpr[1];
                    Col.offset += new Vector2(0f, 0.05f);
                    int Point = Random.Range(0, 9);
                    Instantiate(BurIng[1], SpawnPoint[Point]);
                }
                break;
            case "B2(Clone)":
                {
                    hamburgerSE.active = false;
                    hamburgerSE.active = true;
                    Destroy(collision.gameObject);
                    sr.sprite = BurSpr[2];
                    Col.offset += new Vector2(0f, 0.05f);

                    int Point = Random.Range(0, 9);
                    Instantiate(BurIng[2], SpawnPoint[Point]);
                }
                break;
            case "B3(Clone)":
                {
                    hamburgerSE.active = false;
                    hamburgerSE.active = true;
                    Destroy(collision.gameObject);
                    sr.sprite = BurSpr[3];
                    Col.offset += new Vector2(0f, 0.02f);

                    int Point = Random.Range(0, 9);
                    Instantiate(BurIng[3], SpawnPoint[Point]);
                }
                break;
            case "B4(Clone)":
                {
                    hamburgerSE.active = false;
                    hamburgerSE.active = true;
                    Destroy(collision.gameObject);
                    sr.sprite = BurSpr[4];
                    Col.offset += new Vector2(0f, 0.05f);

                    int Point = Random.Range(0, 9);
                    Instantiate(BurIng[4], SpawnPoint[Point]);
                }
                break;
            case "B5(Clone)":
                {
                    hamburgerSE.active = false;
                    hamburgerSE.active = true;
                    Destroy(collision.gameObject);
                    sr.sprite = BurSpr[5];
                    Col.offset += new Vector2(0f, 0.03f);

                    int Point = Random.Range(0, 9);
                    Instantiate(BurIng[5], SpawnPoint[Point]);
                }
                break;
            case "B6(Clone)":
                {
                    hamburgerSE.active = false;
                    hamburgerSE.active = true;
                    Destroy(collision.gameObject);
                    sr.sprite = BurSpr[6];
                    Col.offset += new Vector2(0f, 0.03f);

                    int Point = Random.Range(0, 9);
                    Instantiate(BurIng[6], SpawnPoint[Point]);
                }
                break;
            case "B7(Clone)":
                {
                    hamburgerSE.active = false;
                    hamburgerSE.active = true;
                    get_food.active = false;
                    get_food.active = true;
                    BurControl = false;
                    Textoff = false;
                    Destroy(collision.gameObject);
                    ABtn.SetActive(false);
                    DBtn.SetActive(false);
                    sr.sprite = BurSpr[7];
                    BurText.text = "성공!";
                    Invoke("DelScene", 0.5f);
                }
                break;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            switch (collision.gameObject.name)
            {
                case "Right Wall":
                    isRight = false;
                    break;
                case "Left Wall":
                    isLeft = false;
                    break;
            }
        }
    }

    void DelScene()
    {
        ck.resultFood = 4;
        transform.parent.gameObject.SetActive(false);
    }
}
