using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanJackBanJack : MonoBehaviour
{
    public Transform AllDM;
    DControl dc;
    DialogueManager dm;
    SpriteRenderer[] spr=new SpriteRenderer[3];

    public bool IsBurgerNavBlink = false;

    float blinkTime;
    void Awake()
    {
        dc = AllDM.GetComponent<DControl>();
        dm = AllDM.GetComponent<DialogueManager>();
    }
    void Start()
    {
        spr = transform.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (IsBurgerNavBlink)
        {
            blinkTime += Time.deltaTime;
            if (blinkTime > 0.25f)
            {
                if (blinkTime > 0.4f)
                {
                    for(int i = 0; i < 3; i++)
                    {
                        spr[i].color = new Color(1, 1, 1, 1f);
                    }
                    
                    blinkTime = 0f;
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        spr[i].color = new Color(1, 1, 1, 0.5f);
                    }
                }
            }
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (IsBurgerNavBlink)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IsBurgerNavBlink = false;
                for (int i = 0; i < 3; i++)
                {
                    spr[i].color = new Color(1, 1, 1, 0);
                }
                dc.id = 400;
                dm.Action();
            }
        }
    }
}
