using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWATHP : MonoBehaviour
{
    public int SWHP;
    Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        SWHP = 1;
    }

    void Update()
    {
        if (SWHP <= 0)
        {
            anim.SetTrigger("SWATdie");
            Invoke("SWATDie", 0.5f);
        }
    }
    void SWATDie()
    {
        Destroy(this.gameObject);
    }
}
