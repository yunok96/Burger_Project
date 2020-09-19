using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    GameManager gm;
    void Awake()
    {
        gm = GetComponent<GameManager>();
    }
    void Start()
    {
        //이곳에서 스테이지마다 스폰 시간, 물체 생성 여부 등의 개별 설정을 해줌
    }
}
