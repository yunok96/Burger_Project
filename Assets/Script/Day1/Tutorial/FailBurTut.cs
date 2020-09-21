using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailBurTut : MonoBehaviour
{
    public Transform Cont;
    PlateMoveTut pm;
    public GameObject A;
    public GameObject D;
    CookTut ck;

    void Awake()
    {
        ck = GameObject.FindWithTag("CookPlace").GetComponent<CookTut>();
        pm = Cont.GetComponent<PlateMoveTut>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BurIng")
        {
            pm.Textoff = false;
            pm.BurControl = false;
            A.SetActive(false);
            D.SetActive(false);
            pm.BurText.text = "바닥에 떨어졌어...";
            Destroy(collision.gameObject);
            Invoke("DelScene", 1f);
        }
    }
    void DelScene()
    {
        transform.parent.gameObject.SetActive(false);
        ck.resultFood = 5;
    }
}
