using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeC = 180f;
    float blinkT;
    Text Timetxt;
    public bool stageClear = false;
    public GameObject under5sec;

    public GameManager gm;

    void Awake()
    {
        Timetxt = GetComponent<Text>();
        under5sec.active = false;
    }

    void Update()
    {
        if (!stageClear)
        {
            TimeC -= Time.deltaTime * gm.worldTime;
            Timetxt.text = (int)TimeC + "초";
            if (TimeC < 0)
            {
                stageClear = true;
            }
        }

        if (TimeC <= 10)//시간 적을때 깜빡임
        {
            blinkT += Time.deltaTime * gm.worldTime * 10;
            if (blinkT > TimeC)
                blinkT = 0f;
            if (TimeC < 2)
                Timetxt.color = new Color(1, 0, 0);
            else if (blinkT > TimeC / 2)
                Timetxt.color = new Color(1, 1, 1);
            else
                Timetxt.color = new Color(1, 0, 0);
        }

        if(TimeC <= 5f)
        {
            under5sec.active = true;
        }
        if(TimeC <= 0.2f)
        {
            under5sec.active = false;
        }

        if (Input.GetKeyDown(KeyCode.J)) //10초 이하 디버그
        {
            TimeC = 10f;
        }
    }
}
