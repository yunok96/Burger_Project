using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Owner : MonoBehaviour
{
    public DMTut dm;
    public bool start;
    bool next;

    void Update()
    {
        if (start)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3,-1,0), 4f * Time.deltaTime);
            if (transform.position==new Vector3(-3,-1,0))
            {
                start = false;
                next = true;
            }
        }
        if (next)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(2,-1,0), 4f * Time.deltaTime);
            if (transform.position == new Vector3(2,-1,0))
            {
                dm.id = 200;
                dm.Action();
                Destroy(this.gameObject);
            }
        }
    }
}
