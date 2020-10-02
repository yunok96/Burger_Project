using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MoveTutor : MonoBehaviour
{
    public DMTut dm;
    public GameObject MoveTutPlayer;
    public GameObject black;
    public OrderTableTut ord;
    public CustomerSpawnTut cusp;
    public Vigor vigor;
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
        if (vigor.vigorCount == 34)
        {
            cusp.Spawn();
            ord.orderCreate();
            dm.id = 300;
            dm.Action();
            Destroy(this.gameObject);
        }
    }
}
