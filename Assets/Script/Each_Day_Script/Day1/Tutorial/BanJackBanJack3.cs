using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanJackBanJack3 : MonoBehaviour
{
    SpriteRenderer spr;
    public bool IsNavBlink = false;
    float blinkTime;
    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (IsNavBlink)
        {
            blinkTime += Time.deltaTime;
            if (blinkTime > 0.25f)
            {
                if (blinkTime > 0.4f)
                {
                    spr.color = new Color(1, 1, 1, 1f);
                    blinkTime = 0f;
                }
                else
                    spr.color = new Color(1, 1, 1, 0.5f);
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (IsNavBlink)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IsNavBlink = false;
                spr.color = new Color(1, 1, 1, 0);
            }
        }
    }
}
