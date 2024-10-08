﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditorInternal;

public class PlayerHP : MonoBehaviour
{
    public int curHP = 3;//현재 체력
    public GameObject[] Heart = new GameObject[3];//체력 UI
    public GameManager gm;//시간 정지 및 이동 불가

    float BlinTime = 0f;//체력 떨어질때 깜빡임 효과
    float Btime = 0f;
    public bool isBlin = false;
    SpriteRenderer spr;

    public GameObject order_disappear;

    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isBlin)//총알 피격시 깜빡이는 효과
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

            if (Input.GetKeyDown(KeyCode.X)) //체력감소 디버그
            {
                curHP--;
            }
        }
    }

    public void HPSet()//외부에서 체력 떨어질때 사용
    {
        order_disappear.active = false;
        order_disappear.active = true;
        curHP--;
        Heart[curHP].SetActive(false);
    }
}
