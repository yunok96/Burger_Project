using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class SpawnerSWAT : MonoBehaviour
{
    public GameObject[] enemyObj;
    public Transform[] spawnPoints;
    float maxSpawnDelay;
    float curSpawnDelay;
    public bool[] EnemyIsAlive;
    public GameObject[] ItemPickupObj;
    public Transform[] ItemSpawnPoint;
    public bool[] ItemExist;
    float ItemMaxSpawnDelay;
    float ItemCurSpawnDelay;

    void Awake()
    {
        maxSpawnDelay = 15f;
        curSpawnDelay = 0f;
        ItemMaxSpawnDelay = 15f;
        ItemCurSpawnDelay = 0f;
    }
    void Start()
    {
        SpawnItem();
    }

    void Update()
    {
        if (enemyObj[0])
            //curSpawnDelay += Time.deltaTime * StatVar.instance.time1;
        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            curSpawnDelay = 0;
        }

        //ItemCurSpawnDelay += Time.deltaTime * StatVar.instance.time1;//아이템 소환
        if (ItemCurSpawnDelay > ItemMaxSpawnDelay)
        {
            SpawnItem();
        }
        if (enemyObj[0] == null)
        {
            EnemyIsAlive[0] = false;
        }
    }
    
    void SpawnItem()
    {
        int IranItem = Random.Range(0, 3);
        int IranPoint = 46;
        IranPoint = Random.Range(0, 45);

        if (ItemExist[IranPoint] == true)
        {
            if(ItemSpawnPoint[IranPoint].childCount==0)
            {
                ItemExist[IranPoint] = false;
            }
            else
            {
                return;
            }
        }
        else
        {
            Instantiate(ItemPickupObj[IranItem], ItemSpawnPoint[IranPoint]);
            ItemExist[IranPoint] = true;
            ItemCurSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int ranPoint = Random.Range(0, 3);//소환위치
        int ranEnemy;

        if(!GameObject.Find("SWAT 1(Clone)"))
        {
            EnemyIsAlive[0] = false;
        }
        if (!GameObject.Find("SWAT 2(Clone)"))
        {
            EnemyIsAlive[1] = false;
        }
        if (!GameObject.Find("SWAT 3(Clone)"))
        {
            EnemyIsAlive[2] = false;
        }
        if (!GameObject.Find("SWAT 4(Clone)"))
        {
            EnemyIsAlive[3] = false;
        }

        if (EnemyIsAlive[0] && EnemyIsAlive[1] == true)
        {
            ranEnemy = Random.Range(2, 4);
        }
        else
        {
            ranEnemy = Random.Range(0, 2);
        }
        if (EnemyIsAlive[ranEnemy] == true)//랜덤으로 나온 주정뱅이가 이미 있는 애라면.
        {
            if (EnemyIsAlive[0] && EnemyIsAlive[1] && EnemyIsAlive[2] && EnemyIsAlive[3] == true)//모든 주정뱅이가 존재하는지 확인
            {
                return;//소환종료
            }
            else//없는애 나올때까지 랜덤으로 다시 돌림
                SpawnEnemy();
        }
        else
        {
            Instantiate(enemyObj[ranEnemy], spawnPoints[ranPoint]);
            EnemyIsAlive[ranEnemy] = true;
        }
    }

}
