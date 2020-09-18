using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PourCola : MonoBehaviour
{
    float CurColaTime;
    float ColaMinTime;
    float ColaOverTime;
    Animator anim;
    bool CountDone;
    bool ColaControl;
    float WaitTime;
    public Text ColaText;
    public GameObject EnterBtn;
    public SpriteRenderer EnterB;
    float Btime = 0f;

    void Awake()
    {
        ColaMinTime = 3f;
        ColaOverTime = 5f;
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        CountDone = true;
        ColaControl = false;
        WaitTime = 1f;
    }

    void Update()
    {
        if(CountDone == true)
        {
            ColaText.text = "준비...";
            WaitTime -= Time.deltaTime;
            if (WaitTime < 0.01f)
            {
                ColaControl = true;
                ColaText.text = "시작!";
                CountDone = false;
            }
        }
        if (ColaControl == true && Input.GetKey(KeyCode.Return))//엔터 눌러서 시작
        {
            ColaText.text = null;
            CurColaTime += Time.deltaTime;//시간재기 시작
            anim.SetBool("ColaStart", true);
            if(CurColaTime > ColaOverTime)
            {
                EnterBtn.SetActive(false);
                anim.SetBool("ColaOver", true);
                ColaText.text = "콜라가 넘쳤다...";
                ColaControl = false;
                Invoke("DelScene", 1f);
                //실패 후에 메인화면으로 돌아감
            }
        }
        if (ColaControl == true && Input.GetKeyUp(KeyCode.Return))
        {
            if (CurColaTime < ColaMinTime)
            {
                EnterBtn.SetActive(false);
                ColaControl = false;
                ColaText.text = "콜라가 너무 적다...";
                Invoke("DelScene", 1f);
                //실패 후에 메인화면으로 돌아감
            }
            else if (ColaMinTime < CurColaTime && CurColaTime < ColaOverTime)
            {
                EnterBtn.SetActive(false);
                ColaControl = false;
                ColaText.text = "성공!";
                StatVar.instance.ColaSuc = true;
                //성공 후에 메인화면으로 돌아감
                Invoke("DelScene", 1f);
            }
            CurColaTime = 0f;
        }

        if (0.01f < CurColaTime && CurColaTime < 3f)
        {
            EnterB.color = new Color(0, 0, 0, 0.5f);
        }
        else if (3f < CurColaTime && CurColaTime < 5f)
        {
            Btime += Time.deltaTime;
            if(Btime > 0.1f)
            {
                if (Btime > 0.2f)
                {
                    EnterB.color = new Color(0, 0, 0, 0.5f);
                    Btime = 0f;
                }
                else
                {
                    EnterB.color = new Color(0, 0, 0, 0.25f);
                }
            }
        }
    }
    void DelScene()
    {
        StatVar.instance.time1 = 1f;
        StatVar.instance.Movable = true;
        SceneManager.UnloadSceneAsync("ColaGame");
    }
}
