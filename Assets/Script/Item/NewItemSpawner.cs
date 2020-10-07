using UnityEngine;

public class NewItemSpawner : MonoBehaviour
{
    public GameObject[] items = new GameObject[3];
    bool[] isExist = new bool[46];
    public Transform[] where = new Transform[46];

    public void ItemSpawn()
    {
        int ran = Random.Range(0, 46);
        if (where[ran].childCount == 0)
            isExist[ran] = false;
        for(int i = 0; isExist[ran]; i++)
        {
            ran = Random.Range(0, 46);
            if (i > 100)//무한반복 방지
                break;
        }
        isExist[ran] = true;
        Instantiate(items[Random.Range(0, 3)], where[ran], false);
    }
}
