﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day49_RouteB_Outro_StageControl : MonoBehaviour
{
    public DM_Day49_RouteB_Outro dm;
    public Image DTB;
    float fade;
    bool fadeStart;
    bool fadeinDone = false;
    public bool SceneDoneRouteB = true;
    void Start()
    {
        fadeinDone = true;
        fade = 1f;
    }

    void Update()
    {
        if (fadeinDone)
        {
            fade -= Time.deltaTime;
            DTB.color = new Color(0, 0, 0, fade);
            if (fade < 0f)
            {
                fadeinDone = false;
                fade = 0f;
                dm.id = 3001;
                dm.Action();
            }
        }
        if (SceneDoneRouteB)
        {
            fade += Time.deltaTime;
            DTB.color = new Color(0, 0, 0, fade);
            if (fade > 1f)
            {
                SceneDoneRouteB = false;
                dm.id = 3001;
                dm.Action();
            }
        }
    }
}
