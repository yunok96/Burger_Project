using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Owner : MonoBehaviour
{
    public Transform AllDM;
    DControl dc;
    DialogueManager dm;
    public Transform p1;
    public Transform p2;
    public bool start;
    bool next;
    void Awake()
    {
        dc = AllDM.GetComponent<DControl>();
        dm = AllDM.GetComponent<DialogueManager>();
    }
    void Update()
    {
        if (start)
        {
            transform.position = Vector3.MoveTowards(transform.position, p1.position, 4f * Time.deltaTime);
            if (transform.position==p1.position)
            {
                start = false;
                next = true;
            }
        }
        if (next)
        {
            transform.position = Vector3.MoveTowards(transform.position, p2.position, 4f * Time.deltaTime);
            if (transform.position == p2.position)
            {
                dc.id = 200;
                dm.Action();
                Destroy(this.gameObject);
            }
        }
    }
}
