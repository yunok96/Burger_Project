using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FryTut : MonoBehaviour
{
    public Transform AllDM;
    DControl dc;
    bool isTheCharacterOn = false; //캐릭터가 조리타일에 있는지

    void Start()
    {
        dc = AllDM.GetComponent<DControl>();
    }

    void OnTriggerStay2D(Collider2D other)//캐릭터가 조리 타일 위에 있다면
    {
        if (other.CompareTag("Player"))
            isTheCharacterOn = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isTheCharacterOn = false;
    }

    void Update()
    {
        if (isTheCharacterOn == true && Input.GetKeyDown(KeyCode.Return))//음식 미니게임
            dc.id = 10;
    }
}
