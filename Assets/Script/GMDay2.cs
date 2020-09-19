using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GMDay2 : MonoBehaviour
{
    public GameObject rd;
    public float rdtime;
    bool once;

    public GameObject broom;
    Inventory inv;
    BroomAttack ba;

    void Start()
    {
        inv = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        inv.isFull[0] = true;
        Instantiate(broom, inv.slots[0].transform, false);
        inv.VisibleRange();
        ba = GameObject.FindWithTag("Player").GetComponent<BroomAttack>();
        ba.FirstBlood = false;
        once = true;
        //StatVar.instance.time1 = 0f;
        rdtime = 1.5f;
    }
    void Update()
    {
        rdtime -= Time.deltaTime;
        if (rdtime < 0.5f)
        {
            rd.transform.GetChild(0).gameObject.SetActive(false);
            rd.transform.GetChild(1).gameObject.SetActive(true);
            if (once)
            {
                once = false;
                //StatVar.instance.Movable = true;
                //StatVar.instance.time1 = 1f;
            }
            if (rdtime < 0f)
            {
                rd.SetActive(false);
                rdtime = 0f;
            }
        }
    }
}
