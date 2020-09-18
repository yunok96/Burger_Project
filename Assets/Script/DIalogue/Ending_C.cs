using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending_C : MonoBehaviour
{
    DManagerEndingC dm;
    DControl_C dc;
    public GameObject DTB;
    Image dtb;
    float fade;
    public bool isfade;
    bool dont;

    void Start()
    {
        dtb = DTB.GetComponent<Image>();
        dm = GameObject.FindWithTag("Dialogue").GetComponent<DManagerEndingC>();
        dc = GameObject.FindWithTag("Dialogue").GetComponent<DControl_C>();
        dc.id = 1200;
        dm.Action();
    }
    void Update()
    {
        if (isfade)
        {
            fade += Time.deltaTime * 0.5f;
            dtb.color = new Color(0, 0, 0, fade);
            if (fade > 1f)
            {
                isfade = false;
                Invoke("Endc", 1f);
            }
        }


    }
    void Endc()
    {
        dc.id = 1201;
        dm.Action();
    }
}
