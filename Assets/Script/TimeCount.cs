﻿using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public float TimeC;
    float blinkT;
    public Text Timetxt;
    public bool StartTime;//게임 시작 bool값

    public bool zaWarudo = false;
    private bool isTheDayCleared = false;

    public GameObject postpost;
    public GameObject post1;
    public GameObject post2;
    public GameObject post3;
    public GameObject pauseMenu;
    public GameObject winTheDay;

    private HP hp;

    //일시정지 화면메뉴
    public GameObject[] pMenuOptions = new GameObject[3];
    public int pOptionsHighlight = 0;
    private WaitForSeconds pauseCursorFadeIn = new WaitForSeconds(1.00f);//밝아지는 이펙트 지연시간

    private void Start()
    {
        hp = GameObject.FindGameObjectWithTag("Player").GetComponent<HP>();
        TimeC = 180;
        StartTime = true;
    }

    private void theWorld() //이것이... 더 월드다, 카쿄인...
    {
        if (zaWarudo == false && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            zaWarudo = true;
            pauseMenu.SetActive(true);
            StatVar.instance.Movable = false;
            Cursor2();
            // PmenuCursor();
            //answerSwitch();
            //GameResume();
        }
        else if (zaWarudo == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            zaWarudo = false;
            StatVar.instance.Movable = true;
        }
    }

    private void Cursor1()
    {
        Color color1 = pMenuOptions[0].GetComponent<Renderer>().material.color;
        Color color2 = pMenuOptions[1].GetComponent<Renderer>().material.color;
        Color color3 = pMenuOptions[2].GetComponent<Renderer>().material.color;
        Color color = pMenuOptions[pOptionsHighlight].GetComponent<Renderer>().material.color;
        switch(pOptionsHighlight){
            case 1:
                color = Color.black;
                color2 = Color.black;
                color3 = Color.black;
                break;
            case 2:
                color = Color.black;
                color1 = Color.black;
                color3 = Color.black;
                break;
            case 3:
                color = Color.black;
                color2 = Color.black;
                color1 = Color.black;
                break;
        }
    }

    private void Cursor2(){
        //Instantiate(postpost, post1.transform, false);
        switch (pOptionsHighlight)
        {
            case 0:
                //Instantiate(postpost, post1.transform, false);
                postpost.transform.position = new Vector3(-5f, 2.5f, 0f);
                break;
            case 1:
                //Instantiate(postpost, post2.transform, false);
                postpost.transform.position = new Vector3(-4.65f, 0.6f, 0f);
                break;
            case 2:
                //Instantiate(postpost, post3.transform, false);
                postpost.transform.position = new Vector3(-4.35f, -1.25f, 0f);
                break;
        }
    }


    // private void PmenuCursor()//선택 효과
    // {
    //     StopAllCoroutines();
        
        // Color color = pMenuOptions[pOptionsHighlight].GetComponent<Renderer>().material.color;
        // color = Color.red;
        // pMenuOptions[pOptionsHighlight].GetComponent<Renderer>().material.color = color;
        // for (int i = 0; i < pMenuOptions.Length; i++)
        // {
        //     pMenuOptions[i].GetComponent<Renderer>().material.color = color;
        // }
        // StartCoroutine(CursorHighlight());
    // }

    // IEnumerator CursorHighlight()//선택칸 밝게
    // {
        // Color color1 = pMenuOptions[0].GetComponent<Renderer>().material.color;
        // Color color2 = pMenuOptions[1].GetComponent<Renderer>().material.color;
        // Color color3 = pMenuOptions[2].GetComponent<Renderer>().material.color;

        // Color color = pMenuOptions[pOptionsHighlight].GetComponent<Renderer>().material.color;

        // while (color == Color.red)
        // {
        //     color = Color.black;
        //     pMenuOptions[pOptionsHighlight].GetComponent<Renderer>().material.color = color;
        //     yield return pauseCursorFadeIn;
        // }
    // }

    private void answerSwitch()
    {
        if (zaWarudo == true && Input.GetKeyDown(KeyCode.S))
        {
            switch (pOptionsHighlight)
            {
                case 0: //1번: Resume    2번: Retry     3번: Quit
                    pOptionsHighlight = 1;
                    Cursor2();
                    //PmenuCursor();
                    break;
                case 1:
                    pOptionsHighlight = 2;
                    Cursor2();
                    //PmenuCursor();
                    break;
                case 2:
                    pOptionsHighlight = 0;
                    Cursor2();
                    //PmenuCursor();
                    break;
            }
        }
        else if (zaWarudo == true && Input.GetKeyDown(KeyCode.W))
        {
            switch (pOptionsHighlight)
            {
                case 0: //1번: Resume    2번: Retry     3번: Quit
                    pOptionsHighlight = 2;
                    Cursor2();
                    break;
                case 1:
                    pOptionsHighlight = 0;
                    Cursor2();
                    break;
                case 2:
                    pOptionsHighlight = 1;
                    Cursor2();
                    break;
            }
        }
    }

    private void GameResume()
    {
        if (zaWarudo == true && pOptionsHighlight == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            zaWarudo = false;
            StatVar.instance.Movable = true;
        }
    }

    private void GameQuit()
    {
        if (zaWarudo == true && pOptionsHighlight == 2 && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("게임종료버튼");
        }
    }

    private void DayClear()
    {
        if (TimeC <= 0 && hp.health > 0)
        {
            Time.timeScale = 0;
            isTheDayCleared = true;
            StatVar.instance.Movable = false;
            winTheDay.SetActive(true);
        }
    }

    private void NextChapter()
    {
        if (isTheDayCleared == true && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("데이 클리어 확인. Proceed to the next sequence");
        }
    }

    void Update()
    {
        if (StartTime == true)
        {
            TimeC -= Time.deltaTime * StatVar.instance.time1;
            Timetxt.text = (int)TimeC + "초";
            if (TimeC <= 10)
            {
                blinkT += Time.deltaTime * StatVar.instance.time1 * 10;
                if (blinkT > TimeC)
                    blinkT = 0f;
                if (TimeC < 2)
                    Timetxt.color = new Color(1, 0, 0);
                else if (blinkT > TimeC / 2)
                    Timetxt.color = new Color(1, 1, 1);
                else
                    Timetxt.color = new Color(1, 0, 0);
            }
            DayClear();
            NextChapter();
            theWorld();

        }
        if (zaWarudo == true)
        {
            //PmenuCursor();
            Cursor2();
            answerSwitch();
            GameResume();
            GameQuit();
        }
    }
}
