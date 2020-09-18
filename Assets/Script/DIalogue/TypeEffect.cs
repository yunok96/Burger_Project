using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    string targetMsg;
    public GameObject EndCur;
    public int CharPerSec;
    Text msgtxt;
    AudioSource audioSource;
    int index;
    float interval;
    public bool isAnim;
    void Awake()
    {
        msgtxt = GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
    }

    public void SetMsg(string msg)
    {
        if (isAnim)
        {
            msgtxt.text = targetMsg;
            CancelInvoke();
            EffectEnd();
        }
        else
        {
            targetMsg = msg;
            EffectStart();
        }
    }
    void EffectStart()
    {
        EndCur.SetActive(false);
        msgtxt.text = "";
        index = 0;
        interval = 1.0f / CharPerSec;
        isAnim = true;
        Invoke("Effect", interval);
    }
    void Effect()
    {
        if (msgtxt.text == targetMsg)
        {
            EffectEnd();
            return;
        }
        msgtxt.text += targetMsg[index];

        if (targetMsg[index] != ' ' && targetMsg[index] != '.')
            audioSource.Play();
        index++;
        Invoke("Effect", interval);
    }
    void EffectEnd()
    {
        EndCur.SetActive(true);
        isAnim = false;
    }
}
