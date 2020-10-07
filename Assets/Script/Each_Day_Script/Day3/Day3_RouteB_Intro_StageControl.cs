using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day3_RouteB_Intro_StageControl : MonoBehaviour
{
    public DM_Day3_RouteB_Intro dm;
    public Image today;
    public Image DTB;
    float fade;
    bool fadeStart;
    bool fadeinDone = false;
    public bool SceneDone = false;
    void Start()
    {
        fadeStart = true;
    }

    void Update()
    {
        if (fadeStart)
        {
            fade += Time.deltaTime;
            today.color = new Color(1, 1, 1, fade);
            if (fade > 1f)
            {
                if (fade > 4f)
                {
                    fade = 1f;
                    fadeinDone = true;
                    fadeStart = false;
                }
            }
        }
        if (fadeinDone)
        {
            fade -= Time.deltaTime;
            today.color = new Color(1, 1, 1, fade);
            DTB.color = new Color(0, 0, 0, fade);
            if (fade < 0f)
            {
                fadeinDone = false;
                fade = 0f;
                dm.id = 3000;
                dm.Action();
            }
        }
        if (SceneDone)
        {
            fade += Time.deltaTime;
            DTB.color = new Color(0, 0, 0, fade);
            if (fade > 1f)
            {
                SceneDone = false;
                Debug.Log("데이 3 게임으로");
            }
        }
    }
}
