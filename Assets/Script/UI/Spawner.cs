using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class Spawner : MonoBehaviour
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
    public GameManager gm;

    //public GameObject BroomPup;
    //public Transform BSpawnPoint;
    //public float WCurTime;
    //public float WMaxTime;
    //public bool BroomNotYet;

    void Awake()
    {
        maxSpawnDelay = 7;
        curSpawnDelay = 0f;
        ItemMaxSpawnDelay = 15f;
        ItemCurSpawnDelay = 0f;
    }
    void Start()
    {
        //SpawnItem();
        //BroomNotYet = true;
    }

    void Update()
    {
        if (enemyObj[0])
            curSpawnDelay += Time.deltaTime * gm.worldTime;
        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            curSpawnDelay = 0;//주정뱅이 죽이는거 구현하고 나서 0으로 만드는시점 조절해야됨. 지금은 중복소환 시에도 0됨.
        }

        ItemCurSpawnDelay += Time.deltaTime * gm.worldTime;//아이템 소환
        if (ItemCurSpawnDelay > ItemMaxSpawnDelay)
        {
            SpawnItem();
        }

        /*if (BroomNotYet == true)30초 후 빗자루 스폰 폐기
        {
            WCurTime += Time.deltaTime;//빗자루 스폰
            if (WCurTime > WMaxTime)
            {
                Instantiate(BroomPup, BSpawnPoint);
                BroomNotYet = false;
            }
        }*/
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
            if(ItemSpawnPoint[IranPoint].childCount==0)//소환할때 사라진 오브젝트 자리를 false로 바꿔줌
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

        if(!GameObject.Find("Enemy 1(Clone)"))
        {
            EnemyIsAlive[0] = false;
        }
        if (!GameObject.Find("Enemy 2(Clone)"))
        {
            EnemyIsAlive[1] = false;
        }
        if (!GameObject.Find("Enemy 3(Clone)"))
        {
            EnemyIsAlive[2] = false;
        }
        if (!GameObject.Find("Enemy 4(Clone)"))
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
