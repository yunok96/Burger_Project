﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class BroomAttack : MonoBehaviour
{
    public GameObject VisibleAtk;
    public LayerMask EnemyMask;
    public bool FirstBlood;
    public GameObject PistolPup;
    public AudioClip[] audioB;
    AudioSource ad;
    Animator anim;
    SpriteRenderer sr;
    PlayerMovement pl;
    public GameObject[] bSlots = new GameObject[5];
    public GameManager gm;
    public bool soundplay = false;

    public GameObject broomHit;

    void Awake()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        pl = GetComponent<PlayerMovement>();
        ad = GetComponent<AudioSource>();
        broomHit.active = false;
    }

    void Update()
    {
        if (soundplay)
        {
            soundplay = false;
            ad.clip = audioB[0];
            ad.Play();
        }
    }

    void broomHit_switch()
    {
        if(broomHit.active == true)
        {
            broomHit.active = false;
        }
    }

    public void Melee()
    {
        if (Vector3.Distance(transform.position, pl.movePoint.position) <= 0.1f)
        {
            switch (pl.ShootWhere)
            {
                case 0:
                    {
                        Cummon();
                        anim.SetTrigger("BroomAtkR");
                        if (Physics2D.OverlapCircle(transform.position + new Vector3(1f, 0f, 0f), .2f, EnemyMask))
                        {
                            ad.clip = audioB[0];
                            ad.Play();
                            Vector3 PistolSpawnPointR = transform.position + new Vector3(1f, 0f, 0f);
                            Collider2D HitEnemy = Physics2D.OverlapCircle(PistolSpawnPointR, .2f, EnemyMask);
                            if (HitEnemy.tag == "Enemy")
                            {
                                HitEnemy.GetComponent<EnemyHP>().EneHP--;
                                broomHit.active = true;
                                Invoke("broomHit_switch", 1.0f);
                            }
                            else if (HitEnemy.tag == "SWAT")
                            {
                                HitEnemy.GetComponent<SWATHP>().SWHP--;
                                broomHit.active = true;
                                Invoke("broomHit_switch", 1.0f);
                            }
                            if (!FirstBlood)
                            {
                                FirstBlood = true;
                                Instantiate(PistolPup, HitEnemy.GetComponent<NewEnemyMovement>().whereIsPistol);
                            }
                        }
                    }
                    break;
                case 1:
                    {
                        Cummon();
                        anim.SetTrigger("BroomAtkR");
                        sr.flipX = true;
                        if (Physics2D.OverlapCircle(transform.position + new Vector3(-1f, 0f, 0f), .2f, EnemyMask))
                        {
                            ad.clip = audioB[0];
                            ad.Play();
                            Vector3 PistolSpawnPointL = transform.position + new Vector3(-1f, 0f, 0f);
                            Collider2D HitEnemy = Physics2D.OverlapCircle(PistolSpawnPointL, .2f, EnemyMask);
                            if (HitEnemy.tag == "Enemy")
                                HitEnemy.GetComponent<EnemyHP>().EneHP--;
                            else if (HitEnemy.tag == "SWAT")
                                HitEnemy.GetComponent<SWATHP>().SWHP--;
                            if (!FirstBlood)
                            {
                                FirstBlood = true;
                                Instantiate(PistolPup, HitEnemy.GetComponent<NewEnemyMovement>().whereIsPistol);
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        Cummon();
                        anim.SetTrigger("BroomAtkU");
                        if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, 1f, 0f), .2f, EnemyMask))
                        {
                            ad.clip = audioB[0];
                            ad.Play();
                            Vector3 PistolSpawnPointU = transform.position + new Vector3(0f, 1f, 0f);
                            Collider2D HitEnemy = Physics2D.OverlapCircle(PistolSpawnPointU, .2f, EnemyMask);
                            if (HitEnemy.tag == "Enemy")
                                HitEnemy.GetComponent<EnemyHP>().EneHP--;
                            else if (HitEnemy.tag == "SWAT")
                                HitEnemy.GetComponent<SWATHP>().SWHP--;
                            if (!FirstBlood)
                            {
                                FirstBlood = true;
                                Instantiate(PistolPup, HitEnemy.GetComponent<NewEnemyMovement>().whereIsPistol);
                            }
                        }
                    }
                    break;
                case 3:
                    {
                        Cummon();
                        anim.SetTrigger("BroomAtkD");
                        if (Physics2D.OverlapCircle(transform.position + new Vector3(0f, -1f, 0f), .2f, EnemyMask))
                        {
                            ad.clip = audioB[0];
                            ad.Play();
                            Vector3 PistolSpawnPointD = transform.position + new Vector3(0f, -1f, 0f);
                            Collider2D HitEnemy = Physics2D.OverlapCircle(PistolSpawnPointD, .2f, EnemyMask);
                            if (HitEnemy.tag == "Enemy")
                                HitEnemy.GetComponent<EnemyHP>().EneHP--;
                            else if (HitEnemy.tag == "SWAT")
                                HitEnemy.GetComponent<SWATHP>().SWHP--;
                            if (!FirstBlood)
                            {
                                FirstBlood = true;
                                Instantiate(PistolPup, HitEnemy.GetComponent<NewEnemyMovement>().whereIsPistol);
                            }
                        }
                    }
                    break;
            }
        }
    }
    void AttackDone()
    {
        for (int i = 0; i < 5; i++)
        {
            bSlots[i].SetActive(true);
        }
        gm.plyrMovable = true;
        if (sr.flipX == true)
            sr.flipX = false;
    }
    void Cummon()
    {
        for (int i = 0; i < 5; i++)
        {
            bSlots[i].SetActive(false);
        }
        ad.clip = audioB[1];
        ad.Play();
        gm.plyrMovable = false;
        Invoke("AttackDone", 0.3f);
    }
    public void SoundEff()
    {
        ad.clip = audioB[0];
        ad.Play();
    }
}

