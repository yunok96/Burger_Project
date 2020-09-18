using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCursor : MonoBehaviour
{
    int WhereCursor;
    public Transform[] where;
    public AudioClip[] whichiad;
    AudioSource ad;
    void Awake()
    {
        ad = GetComponent<AudioSource>();
    }
    void Start()
    {
        WhereCursor = 0;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, where[WhereCursor].position, 1000f*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ad.clip = whichiad[0];
            ad.Play();
            if (WhereCursor == 3)
                WhereCursor = 0;
            else
                WhereCursor++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ad.clip = whichiad[0];
            ad.Play();
            if (WhereCursor == 0)
                WhereCursor = 3;
            else
                WhereCursor--;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ad.clip = whichiad[1];
            ad.Play();
            switch (WhereCursor)
            {
                case 0:
                    Debug.Log("시작");
                    SceneManager.LoadScene("MainGame");
                    break;
                case 1:
                    Debug.Log("컨티뉴");
                    SceneManager.LoadScene("MainGameSWAT");
                    break;
                case 2:
                    Debug.Log("옵션");
                    break;
                case 3:
                    Debug.Log("나가기");
                    break;
            }
        }
    }
}
