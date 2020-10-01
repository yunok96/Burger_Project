using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] enemySpec;
    public float curEnemySpawnTime;
    public float maxEnemySpawnTime;
    public Transform[] enemySpawnPoints = new Transform[3];


    void Start()
    {
        
    }

    void Update()
    {
        curEnemySpawnTime += Time.deltaTime;
        if (curEnemySpawnTime > maxEnemySpawnTime)
        {
            curEnemySpawnTime = 0f;
            int rand = Random.Range(0, 4);
            enemySpec[rand] = Instantiate(enemy, enemySpawnPoints[Random.Range(0,3)]);
            switch (rand)
            {
                case 0:
                    {
                        enemySpec[rand].GetComponent<NewEnemyMovement>().target.position = new Vector3(-8, 1.1f, 0);
                    }
                    break;
                case 1:
                    {

                    }
                    break;
                case 2:
                    {

                    }
                    break;
                case 3:
                    {

                    }
                    break;
            }
        }
    }
}
