using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutFailBurger : MonoBehaviour
{
    public Transform Cont;
    PlateMoveTut pm;
    public GameObject AD;

    void Awake()
    {
        pm = Cont.GetComponent<PlateMoveTut>();
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
        StatVar.instance.TutCookFail = true;
        SceneManager.UnloadSceneAsync("TutBurgerGame");
    }
}
