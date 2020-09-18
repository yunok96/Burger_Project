﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FryPotato : MonoBehaviour
{
    public float FryPower;
    Animator anim;
    public bool FryControl;
    float WaitTime;
    public Text FryText;
    bool CountDone;
    public GameObject EnterBtn;
    public SpriteRenderer EnterB;
    float Btime;
    bool Textoff;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        CountDone = true;
        FryControl = false;
        WaitTime = 1f;
        FryPower = 5f;
        Textoff = false;
    }

    void Update()
    {
        if(CountDone == true)
        {
            Btime += Time.deltaTime;
            if (Btime > 0.1f)
            {
                if (Btime > 0.2f)
                {
                    EnterB.color = new Color(0, 0, 0, 0.5f);
                    Btime = 0f;
                }
                else
                {
                    EnterB.color = new Color(0, 0, 0, 0f);
                }
            }
            FryText.text = "준비...";
            WaitTime -= Time.deltaTime;
            if (WaitTime < 0.01f)
            {
                FryControl = true;
                FryText.text = "시작!";
                CountDone = false;
            }
        }

        if (Textoff)
            FryText.text = null;

        if (FryControl == true)//시간 되면 시작
        {
            if (Input.GetKey(KeyCode.Return))
                EnterB.color = new Color(0, 0, 0, 0.5f);
            else if (Input.GetKeyUp(KeyCode.Return))
                EnterB.color = new Color(0, 0, 0, 0f);
            anim.SetInteger("FryPower", 1);
            FryPower -= Time.deltaTime * 3;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                FryPower += 1f;
                Textoff = true;
            }
            if (FryPower > 10f)
                anim.SetInteger("FryPower", 2);
            else if (FryPower > 0f || FryPower < 10f)
                anim.SetInteger("FryPower", 1);
        }
        if (FryPower < 0f)
        {
            Textoff = false;
            FryControl = false;
            FryText.text = "제대로 안 튀겨졌어...";
            EnterBtn.SetActive(false);
            anim.SetInteger("FryPower", 0);
            FryPower = -1f;
            Invoke("DelScene", 1f);
        }
        else if (FryPower > 20f)
        {
            FryControl = false;
            Textoff = false;
            FryText.text = "성공!";
            EnterBtn.SetActive(false);
            StatVar.instance.FrySuc = true;
            FryPower = 15f;
            Invoke("DelScene", 1f);
        }
    }

    void DelScene()
    {
        StatVar.instance.time1 = 1f;
        StatVar.instance.Movable = true;
        SceneManager.UnloadSceneAsync("FryGame");
    }
}
