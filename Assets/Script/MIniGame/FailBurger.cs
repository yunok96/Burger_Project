using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailBurger : MonoBehaviour
{
    public Transform Cont;
    PlateMove pm;
    public GameObject AD;

    void Awake()
    {
        pm = Cont.GetComponent<PlateMove>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BurIng")
        {
            pm.Textoff = false;
            pm.BurControl = false;
            AD.SetActive(false);
            pm.BurText.text = "바닥에 떨어졌어...";
            Destroy(collision.gameObject);
            Invoke("DelScene", 1f);
        }
    }
    void DelScene()
    {
        StatVar.instance.time1 = 1f;
        StatVar.instance.Movable = true;
        SceneManager.UnloadSceneAsync("BurgerGame");
    }
}
