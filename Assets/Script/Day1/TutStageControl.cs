using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutStageControl : MonoBehaviour
{
    GameManager gm;
    BroomAttack ba;
    public DMTut dm;

    public bool jujungDown = false;
    bool cd;
    public float dontmove = 0f;//제발 움직이지마

    void Awake()
    {
        gm = GetComponent<GameManager>();
    }

    void Start()
    {
        ba = GameObject.FindWithTag("Player").GetComponent<BroomAttack>();
        ba.FirstBlood = true;
        dm.id = 100;
        dm.Action();
    }

    void Update()
    {
        if (cd)
        {
            dontmove += Time.deltaTime;
            //StatVar.instance.Movable = false;
            if (dontmove > 0.5f)
            {
                cd = false;
            }
        }
        if (jujungDown)
        {
            cd = true;
            jujungDown = false;
            dm.id = 1000;
            dm.Action();
        }
    }
}
