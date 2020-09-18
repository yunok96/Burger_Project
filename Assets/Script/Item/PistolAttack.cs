using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PistolAttack : MonoBehaviour
{
    public GameObject VisibleAtk;
    public GameObject BulletPre;
    public AudioClip[] ad;
    AudioSource ShotSound;
    Animator anim;
    SpriteRenderer sr;
    PlayerMovement pl;
    public GameObject[] pSlots = new GameObject[5];

    void Awake()
    {
        ShotSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        pl = GetComponent<PlayerMovement>();
    }

    public void Shot()
    {
        if(Vector3.Distance(transform.position, pl.movePoint.position) <= 0.1f)
        {
            switch (pl.ShootWhere)
            {
                case 0:
                    {
                        Cummon();
                        anim.SetTrigger("PistolAtkR");
                        Vector3 BulletPointR = transform.position + new Vector3(1f, 0f, 0f);
                        GameObject bulletRig = Instantiate(BulletPre, BulletPointR, transform.rotation);
                        Rigidbody2D rig = bulletRig.GetComponent<Rigidbody2D>();
                        rig.AddForce(Vector2.right * 30, ForceMode2D.Impulse);
                    }
                    break;
                case 1:
                    {
                        Cummon();
                        sr.flipX=true;
                        anim.SetTrigger("PistolAtkR");
                        Vector3 BulletPointL = transform.position + new Vector3(-1f, 0f, 0f);
                        GameObject bulletRig = Instantiate(BulletPre, BulletPointL, Quaternion.Euler(0f, 0f, 180f));
                        Rigidbody2D rig = bulletRig.GetComponent<Rigidbody2D>();
                        rig.AddForce(Vector2.left * 30, ForceMode2D.Impulse);
                    }
                    break;
                case 2:
                    {
                        Cummon();
                        anim.SetTrigger("PistolAtkU");
                        Vector3 BulletPointU = transform.position + new Vector3(0f, 1f, 0f);
                        GameObject bulletRig = Instantiate(BulletPre, BulletPointU, Quaternion.Euler(0f, 0f, 90f));
                        Rigidbody2D rig = bulletRig.GetComponent<Rigidbody2D>();
                        rig.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
                    }
                    break;
                case 3:
                    {
                        Cummon();
                        anim.SetTrigger("PistolAtkD");
                        Vector3 BulletPointD = transform.position + new Vector3(0f, -1f, 0f);
                        GameObject bulletRig = Instantiate(BulletPre, BulletPointD, Quaternion.Euler(0f, 0f, 270f));
                        Rigidbody2D rig = bulletRig.GetComponent<Rigidbody2D>();
                        rig.AddForce(Vector2.down * 30, ForceMode2D.Impulse);
                    }
                    break;
            }
        }
    }
    void AttackDone()
    {
        for (int i = 0; i < 5; i++)
        {
            pSlots[i].SetActive(true);
        }
        StatVar.instance.Movable = true;
        if (sr.flipX == true)
            sr.flipX = false;
    }

    void Cummon()
    {
        for (int i = 0; i < 5; i++)
        {
            pSlots[i].SetActive(false);
        }
        ShotSound.clip = ad[0];
        ShotSound.Play();
        StatVar.instance.Movable = false;
        Invoke("AttackDone", 0.3f);
    }
}

