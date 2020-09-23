using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day2_RouteA_Outro_StageControl : MonoBehaviour
{
    public DM_Day2_RouteA_Outro dm;
    public Image DTB;
    float fade;
    bool fadeStart;
    bool fadeinDone = false;
    public bool SceneDoneRouteA = false;
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
                dm.id = 2300;
                dm.Action();
            }
        }
        if (SceneDoneRouteA)
        {
            fade += Time.deltaTime;
            DTB.color = new Color(0, 0, 0, fade);
            if (fade > 1f)
            {
                SceneDoneRouteA = false;
                dm.id = 2302;
                dm.Action();
            }
        }
    }
}
