using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject[] enemySpec = new GameObject[4];
    public float curEnemySpawnTime;
    public float maxEnemySpawnTime = 5f;
    public Transform[] enemySpawnPoints = new Transform[3];
    public bool[] alreadyExist = new bool[4];

    public void SpawnEnemy()
    {
        for (int num = 0; num < alreadyExist.Length; num++)
        {
            if (enemySpec[num] == null)
            {
                alreadyExist[num] = false;
            }
            if (!alreadyExist[num])
            {
                enemySpec[num] = Instantiate(enemy, enemySpawnPoints[Random.Range(0, 3)]);
                if (alreadyExist[num])
                {
                    curEnemySpawnTime = 0f;
                }
                alreadyExist[num] = true;
                curEnemySpawnTime = 0f;
                switch (num)
                {
                    case 0:
                        enemySpec[num].GetComponent<NewEnemyMovement>().target = new Vector3(-8, 1.1f, 0);
                        break;
                    case 1:
                        enemySpec[num].GetComponent<NewEnemyMovement>().target = new Vector3(-7, 0.1f, 0);
                        break;
                    case 2:
                        enemySpec[num].GetComponent<NewEnemyMovement>().target = new Vector3(-3, 1.1f, 0);
                        break;
                    case 3:
                        enemySpec[num].GetComponent<NewEnemyMovement>().target = new Vector3(-4, -0.9f, 0);
                        break;
                }
                break;
            }
        }
    }
}
