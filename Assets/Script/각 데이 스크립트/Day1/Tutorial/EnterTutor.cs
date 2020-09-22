using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnterTutor : MonoBehaviour
{
    public GameObject black;
    Image bImg;
    float blinkTime;

    void Awake()
    {
        bImg = black.GetComponent<Image>();
    }

    void Update()
    {
        blinkTime += Time.deltaTime;
        if (blinkTime > 0.5f)
        {
            if (blinkTime > 1f)
            {
                bImg.color = new Color(0, 0, 0, 0.5f);
                blinkTime = 0f;
            }
            else
                bImg.color = new Color(0, 0, 0, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.gameObject.SetActive(false);
        }
    }
}
