using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSpec : MonoBehaviour
{
    public SpriteRenderer spr;
    public Sprite[] sp = new Sprite[4];
    float curTime = 30f;
    public TextMesh tm;
    public int whatsThis;
    GameManager gm;

    void Start()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        curTime = 30f;
        int ran = Random.Range(0, 4);
        spr.sprite = sp[ran];
        whatsThis = ran;
    }

    void Update()
    {
        curTime -= Time.deltaTime * gm.worldTime;
        tm.text = ((int)curTime).ToString();
        if (curTime < 0)
        {
            transform.parent.GetComponent<DisplayOrder>().failed = true;
        }
    }
}
