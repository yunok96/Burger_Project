using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailBurger : MonoBehaviour
{
    public Transform Cont;
    PlateMove pm;
    public GameObject A;
    public GameObject D;

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
            A.SetActive(false);
            D.SetActive(false);
            pm.BurText.text = "바닥에 떨어졌어...";
            Destroy(collision.gameObject);
            Invoke("DelScene", 1f);
        }
    }
    void DelScene()
    {
        StatVar.instance.Movable = true;
        transform.parent.gameObject.SetActive(false);
    }
}
