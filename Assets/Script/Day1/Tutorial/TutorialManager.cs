using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class TutorialManager : MonoBehaviour
{
    public Transform AllDM;
    DControl dc;
    DialogueManager dm;
    BroomAttack ba;
    public bool jujungDown = false;
    bool cd;
    public float dontmove = 0f;//제발 움직이지마
    void Awake()
    {
        dc = AllDM.GetComponent<DControl>();
        dm = AllDM.GetComponent<DialogueManager>();
        ba = GameObject.FindWithTag("Player").GetComponent<BroomAttack>();
    }
    void Start()
    {
        ba.FirstBlood = true;
        //StatVar.instance.time1 = 0f;
        dc.id = 100;
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
            dc.id = 1000;
            dm.Action();
        }
    }
}
