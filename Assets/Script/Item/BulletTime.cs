using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    Day2_StageControl dm;
    BroomAttack ba;
    void Awake()
    {
        dm = GameObject.FindWithTag("GM").GetComponent<Day2_StageControl>();
        ba = GameObject.FindWithTag("Player").GetComponent<BroomAttack>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                    Destroy(this.gameObject);
                break;
            case "Enemy":
                {
                    dm.jujeongKilled++;
                    ba.soundplay = true;
                    collision.gameObject.GetComponent<EnemyHP>().EneHP--;
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
