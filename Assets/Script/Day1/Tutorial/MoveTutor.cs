using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MoveTutor : MonoBehaviour
{
    public Transform AllDM;
    DControl dc;
    DialogueManager dm;
    public GameObject MoveTutPlayer;
    public GameObject black;
    public OrderTableTut ord;
    public CustomerSpawnTut cusp;
    Image bImg;
    float blinkTime;

    void Awake()
    {
        dc = AllDM.GetComponent<DControl>();
        dm = AllDM.GetComponent<DialogueManager>();
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
        if (MoveTutPlayer.GetComponent<PlayerMovement>().hwalgiCount == 34)
        {
            cusp.Spawn();
            ord.orderCreate();
            dc.id = 300;
            dm.Action();
            Destroy(this.gameObject);
        }
    }
}
