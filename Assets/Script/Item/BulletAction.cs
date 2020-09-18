using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                    Destroy(gameObject);
                break;
            case "Enemy":
                {
                    StatVar.instance.soundplay = true;
                    collision.gameObject.GetComponent<EnemyHP>().EneHP--;
                    Destroy(gameObject);
                }
                break;
            case "SWAT":
                {
                    StatVar.instance.soundplay = true;
                    collision.gameObject.GetComponent<SWATHP>().SWHP--;
                    Destroy(gameObject);
                }
                break;
            case "Player":
                {
                    StatVar.instance.soundplay = true;
                    collision.gameObject.GetComponent<HP>().isBlin = true;
                    collision.gameObject.GetComponent<HP>().health--;
                    Destroy(gameObject);
                }
                break;
        }
    }
}
