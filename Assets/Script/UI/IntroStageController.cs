using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroStageController : MonoBehaviour
{
    public Image today;
    public Image DTB;
    float fade;
    bool fadeStart;
    bool fadeinDone;
    void Start()
    {
        fadeStart = true;
    }

    void Update()
    {
        today.color = new Color(1, 1, 1, fade);
        if (fadeStart)
        {
            fade += Time.deltaTime;
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
            DTB.color = new Color(0, 0, 0, fade);
            if (fade < 0f)
            {
                fadeinDone = false;
                fade = 0f;
                Debug.Log("시작");
            }
        }
    }
}
