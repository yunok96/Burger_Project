using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanJackBanJack2 : MonoBehaviour
{
    SpriteRenderer spr;
    public bool IsCounterNavBlink = false;
    float blinkTime;
    public GameObject EntTut;
    public GameObject invisibleCounterBlock;
    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (IsCounterNavBlink)
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
        if (IsCounterNavBlink)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IsCounterNavBlink = false;
                invisibleCounterBlock.SetActive(true);
                spr.color = new Color(1, 1, 1, 0);
                EntTut.SetActive(true);
            }
        }
    }
}
