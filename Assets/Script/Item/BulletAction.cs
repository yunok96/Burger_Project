using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    BroomAttack ba;
    void Awake()
    {
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
                    ba.soundplay = true;
                    collision.gameObject.GetComponent<EnemyHP>().EneHP--;
                    Destroy(this.gameObject);
                }
                break;
            case "SWAT":
                {
                    ba.soundplay = true;
                    collision.gameObject.GetComponent<SWATHP>().SWHP--;
                    Destroy(this.gameObject);
                }
                break;
            case "Player":
                {
                    ba.soundplay = true;
                    collision.gameObject.GetComponent<HP>().isBlin = true;
                    collision.gameObject.GetComponent<HP>().health--;
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}
