using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Day1_End : MonoBehaviour
{
    DM_Day1End dm;
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
        dm.id = 1150;
        dm.Action();
    }
    void nextScene()
    {
        Debug.Log("다음 씬으로 이동");
    }
}
