using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreePlayerMove : MonoBehaviour
{
    float movespeed;//이동속도
    public Transform movePoint;
    public LayerMask WhatStopMove;
    public int ShootWhere;
    public AudioClip[] adc;
    AudioSource ad;
    Animator anim;
    public GameManager gm;

    void Awake()
    {
        anim = GetComponent<Animator>();
        ad = GetComponent<AudioSource>();
    }
    void Start()
    {
        movePoint.parent = null;
        movespeed = 17f;//기본 이동속도
        ShootWhere = 3;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, movePoint.position, movespeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.03f && gm.plyrMovable)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                anim.SetTrigger("Neutral");
                ShootWhere = Input.GetAxisRaw("Horizontal") == 1f ? 0 : 1;
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, WhatStopMove))
                {
                    ad.clip = adc[2];
                    ad.Play();
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                anim.SetTrigger("Neutral");
                ShootWhere = Input.GetAxisRaw("Vertical") == 1f ? 2 : 3;
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, WhatStopMove))
                {
                    ad.clip = adc[2];
                    ad.Play();
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }
}
