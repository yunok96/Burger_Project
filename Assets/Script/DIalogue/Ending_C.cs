using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending_C : MonoBehaviour
{
    public DManagerEndingC dm;
    public GameObject DTB;
    Image dtb;
    float fade = 1f;
    public bool isfade;
    bool firstfade;

    void Start()
    {
        dtb = DTB.GetComponent<Image>();
        firstfade = true;
    }
    void Update()
    {
        if (firstfade)
        {
            fade -= Time.deltaTime * 0.5f;
            dtb.color = new Color(0, 0, 0, fade);
            if (fade < 0)
            {
                firstfade = false;
                fade = 0f;
                dm.id = 1200;
                dm.Action();
            }
        }

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
        dm.id = 1201;
        dm.Action();
    }
}
