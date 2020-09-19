using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int EneHP;
    Animator anim;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        EneHP = 1;
    }

    void Update()
    {
        if (EneHP <= 0)
        {
            anim.SetTrigger("Attacked");
            Invoke("JujungDie", 0.2f);
        }
    }
    void JujungDie()
    {
        Destroy(this);
        Destroy(this.gameObject);
    }
}
