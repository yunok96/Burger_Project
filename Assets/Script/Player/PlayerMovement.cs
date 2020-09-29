using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float movespeed;//이동속도
    public Transform movePoint;
    public LayerMask WhatStopMove;
    public bool isBoost;
    public float boostTime;
    public int hwalgiCount;
    Text hwalgiValue;
    GameObject VisibleAtk;
    SpriteRenderer visA;
    public int ShootWhere;
    public AudioClip[] adc;
    AudioSource ad;
    float hwalgiminustime;
    GameObject vigor;
    Animator anim;
    public GameManager gm;
    public int vigorCookTime = 1;

    void Awake()
    {
        anim = GetComponent<Animator>();
        VisibleAtk = transform.GetChild(0).gameObject;
        visA = VisibleAtk.GetComponent<SpriteRenderer>();
        vigor = GameObject.FindWithTag("Vigor");
        hwalgiValue = vigor.transform.GetChild(5).GetComponent<Text>();
        ad = GetComponent<AudioSource>();
    }
    void Start()
    {
        movePoint.parent = null;
        movespeed = 17f;//기본 이동속도
        boostTime = 0f;
        isBoost = false;
        VisibleAtk.GetComponent<Transform>();
        VisibleAtk.transform.position = transform.position + new Vector3(0f, -1f, 0f);
        ShootWhere = 3;
        hwalgiCount = 30;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, movePoint.position, movespeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.03f && gm.plyrMovable)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                anim.SetTrigger("Neutral");
                VisibleAtk.transform.position = transform.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                ShootWhere = Input.GetAxisRaw("Horizontal") == 1f ? 0 : 1;
                visA.color = new Color(1, 1, 1, 0);
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, WhatStopMove))
                {
                    ad.clip = adc[2];
                    ad.Play();
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    if (hwalgiCount < 99)
                    {
                        hwalgiCount++;
                    }
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                anim.SetTrigger("Neutral");
                VisibleAtk.transform.position = transform.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                ShootWhere = Input.GetAxisRaw("Vertical") == 1f ? 2 : 3;
                visA.color = new Color(1, 1, 1, 0);
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, WhatStopMove))
                {
                    ad.clip = adc[2];
                    ad.Play();
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    if (hwalgiCount < 99)
                    {
                        hwalgiCount++;
                    }
                }
            }
            switch (ShootWhere)
            {
                case 0:
                    VisibleAtk.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                    break;
                case 1:
                    VisibleAtk.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                    break;
                case 2:
                    VisibleAtk.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    break;
                case 3:
                    VisibleAtk.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
            }
        }
        

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.001f)
        {
            visA.color = new Color(1, 1, 1, 1);
        }
        if (isBoost)//아이템으로 인한 이동속도 증가
        {
            boostTime += Time.deltaTime;
            movespeed = 27f;//1.5배 증가한 이동속도
            if (boostTime >= 15f)
            {
                movespeed = 17f;//기본 이동속도
                boostTime = 0f;
                isBoost = false;
            }
        }
        hwalgiminustime += Time.deltaTime * vigorCookTime * gm.worldTime;
        if (hwalgiminustime > 1f)
        {
            hwalgiminustime = 0f;
            hwalgiCount--;
        }
        hwalgiValue.text = hwalgiCount.ToString();
        if (hwalgiCount > 99)
            hwalgiCount = 99;
        if (hwalgiCount > 19)
        {
            vigor.transform.GetChild(1).gameObject.SetActive(true);
            if (hwalgiCount > 39)
            {
                vigor.transform.GetChild(2).gameObject.SetActive(true);
                if (hwalgiCount > 59)
                {
                    vigor.transform.GetChild(3).gameObject.SetActive(true);
                    if (hwalgiCount > 79)
                        vigor.transform.GetChild(4).gameObject.SetActive(true);
                    else
                        vigor.transform.GetChild(4).gameObject.SetActive(false);
                }
                else
                    vigor.transform.GetChild(3).gameObject.SetActive(false);
            }
            else
                vigor.transform.GetChild(2).gameObject.SetActive(false);
        }
        else
            vigor.transform.GetChild(1).gameObject.SetActive(false);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            movePoint.position += new Vector3(-1f, 0f, 0f);
            VisibleAtk.transform.position = transform.position + new Vector3(1f, 0f, 0f);//공격방향 틀어짐 수정
        }
        if (collision.gameObject.tag == "Wall")//이론상 충돌할 수 있는 벽이 중앙 테이블 오른쪽 뿐이라서 포인터와 플레이어 동시에 위로 올려버림. 주정뱅이+벽 충돌로 최종적으로는 (-1,1) 움직이게 됨.
        {
            movePoint.position += new Vector3(0f, 1f, 0f);
            transform.position += new Vector3(0f, 1f, 0f);
        }
    }
}
