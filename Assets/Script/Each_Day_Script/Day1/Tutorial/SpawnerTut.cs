using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class SpawnerTut : MonoBehaviour
{
    public GameObject enemyObj;
    public Transform spawnPoints;
    //public GameObject ItemPickupObj;
    //public Transform ItemSpawnPoint;

    public void SpawnEnemy()
    {
        Instantiate(enemyObj, spawnPoints);
    }

}
