using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DControl_C : MonoBehaviour
{
    public int id;
    public DManagerEndingC manager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("DelayAction", 0.01f);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            manager.Action();
        }
    }

    void DelayAction()
    {
        manager.Action();
    }
}
