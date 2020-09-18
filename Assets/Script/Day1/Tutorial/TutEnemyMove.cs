using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutEnemyMove : MonoBehaviour
{
    Animator anim;
    public Transform t1;
    public Transform target;
    bool sta;
    bool isNext;
    bool imdone;
    BroomPickup bp;
    TutorialManager tm;

    void Awake()
    {
        tm = GameObject.Find("GameManager").GetComponent<TutorialManager>();
        bp = GameObject.FindWithTag("Item").GetComponent<BroomPickup>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        target.parent = null;
        sta = true;
    }

    void Update()
    {
        if (transform.position == t1.position)
        {
            isNext = true;
            sta = false;
        }
        if (transform.position == target.position)
        {
            imdone = true;
            anim.SetBool("GetPoint", true);
        }
        if (imdone)
            bp.kikiKanri = true;
        if (sta)
            transform.position = Vector3.MoveTowards(transform.position, t1.position, 1.3f * Time.deltaTime);
        else if (isNext)
            transform.position = Vector3.MoveTowards(transform.position, target.position, 1f * Time.deltaTime);
    }
    void OnDestroy()
    {
        tm.jujungDown = true;
    }
}
