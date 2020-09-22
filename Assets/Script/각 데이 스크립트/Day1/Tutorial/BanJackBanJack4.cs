using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanJackBanJack4 : MonoBehaviour
{
    public DMTut dm;
    SpriteRenderer spr;
    public bool IsNavBlink2 = false;
    float blinkTime;
    GameObject memo;
    void Awake()
    {
        memo = transform.GetChild(0).gameObject;
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (IsNavBlink2)
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
        if (IsNavBlink2)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IsNavBlink2 = false;
                spr.color = new Color(1, 1, 1, 0);
                Destroy(memo);
                dm.id = 1100;
                dm.Action();
            }
        }
    }
}
