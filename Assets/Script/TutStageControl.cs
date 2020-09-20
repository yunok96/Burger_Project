using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutStageControl : MonoBehaviour
{
    GameManager gm;
    BroomAttack ba;
    public DMTut dm;
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
}
