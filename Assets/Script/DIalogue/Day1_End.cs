using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day1_End : MonoBehaviour
{
    DM_Day1End dm;
    DControl_D1E dc;
    public GameObject DTB;
    Image dtb;
    float fade;
    public bool isFadeOut;
    bool isFadeIn;

    void Start()
    {
        isFadeIn = true;
        fade = 1f;
        dtb = DTB.GetComponent<Image>();
        dm = GameObject.FindWithTag("Dialogue").GetComponent<DM_Day1End>();
        dc = GameObject.FindWithTag("Dialogue").GetComponent<DControl_D1E>();
    }
    void Update()
    {
        if (isFadeIn)
        {
            fade -= Time.deltaTime * 0.5f;
            dtb.color = new Color(0, 0, 0, fade);
            if (fade < 0f)
            {
                isFadeIn = false;
                Invoke("dialStart", 1f);
            }
        }
        if (isFadeOut)
        {
            fade += Time.deltaTime * 0.5f;
            dtb.color = new Color(0, 0, 0, fade);
            if (fade > 1f)
            {
                isFadeOut = false;
                Invoke("nextScene", 1f);
            }
        }
    }
    void dialStart()
    {
        dc.id = 1150;
        dm.Action();
    }
    void nextScene()
    {
        Debug.Log("다음 씬으로 이동");
    }
}
