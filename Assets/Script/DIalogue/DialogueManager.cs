using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueMaker dialogueMaker;
    public TypeEffect Talk;
    public Animator talkPanel;
    //public Animator portAnim; 초상화 흔들림 추가한다면 필요
    public Image portL;
    public Image portLB;
    public Image portR;
    public Image portRB;
    public int talkindex;
    public int id;

    public Animator[] anim;
    public GameObject vigor;
    CameraShake Vib;
    public GameManager gm;

    void Awake()
    {
        Vib = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("DelayAction", 0.01f);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Action();
        }
    }

    void DelayAction()
    {
        Action();
    }

    public void Action()
    {
        talk();
    }
    void talk()
    {
        if (id == 0)
            return;
        string talkData = "";
        if (Talk.isAnim)
        {
            Talk.SetMsg("");
            return;
        }
        else
        {
            talkData = dialogueMaker.GetTalk(id, talkindex);
        }
        if (talkData == null)
        {
            Invoke("DelayMove", 0.1f);//대화 끝나면 이동 가능
            gm.worldTime = 1f;
            talkPanel.SetBool("isShow", false);
            portL.color = new Color(1, 1, 1, 0);
            portLB.color = new Color(0, 0, 0, 0);
            portR.color = new Color(1, 1, 1, 0);
            portRB.color = new Color(0, 0, 0, 0);
            talkindex = 0;
            id = 0;
            DisappearUI(false);
            return;
        }
        else if (talkData.Split(':')[0] == "Event")//이벤트 보여줄때 대화창 일시적으로 숨기기, 움직임은 x
        {//이후 이벤트 종류
            if (talkData.Split(':')[1] == "0")
            {
                gm.plyrMovable = true;
            }
            talkPanel.SetBool("isShow", false);
            portL.color = new Color(1, 1, 1, 0);
            portLB.color = new Color(0, 0, 0, 0);
            portR.color = new Color(1, 1, 1, 0);
            portRB.color = new Color(0, 0, 0, 0);
            talkindex = 0;
            id = 0;
            DisappearUI(false);
            return;
        }

        else
        {
            Talk.SetMsg(talkData.Split(':')[0]);
            portL.sprite = dialogueMaker.GetPort(int.Parse(talkData.Split(':')[1]));
            portLB.sprite = dialogueMaker.GetPort(int.Parse(talkData.Split(':')[1]));
            portL.color = new Color(1, 1, 1, 1);
            if (portL.sprite == dialogueMaker.portArr[0])//0번이라면 투명도 높여서 출력 안함
            {
                portL.color = new Color(1, 1, 1, 0);
                portLB.color = new Color(0, 0, 0, 0);
            }
            portR.sprite = dialogueMaker.GetPort(int.Parse(talkData.Split(':')[2]));
            portRB.sprite = dialogueMaker.GetPort(int.Parse(talkData.Split(':')[2]));
            portR.color = new Color(1, 1, 1, 1);
            if (portR.sprite == dialogueMaker.portArr[0])
            {
                portR.color = new Color(1, 1, 1, 0);
                portRB.color = new Color(0, 0, 0, 0);
            }
            switch (int.Parse(talkData.Split(':')[3]))
            {
                case 0:
                    {
                        portLB.color = new Color(0, 0, 0, 0);
                        portRB.color = new Color(0, 0, 0, 0);
                    }
                    break;
                case 1:
                    {
                        portLB.color = new Color(0, 0, 0, 0.5f);
                        portRB.color = new Color(0, 0, 0, 0);
                    }
                    break;
                case 2:
                    {
                        portLB.color = new Color(0, 0, 0, 0);
                        portRB.color = new Color(0, 0, 0, 0.5f);
                    }
                    break;
                case 3:
                    {
                        portLB.color = new Color(0, 0, 0, 0.5f);
                        portRB.color = new Color(0, 0, 0, 0.5f);
                    }
                    break;
            }
            if (talkData.Split(':')[4] == "1")
            {
                //효과음 추가하고 싶으면 넣으세요
                Vib.VibrateForTime(0.2f);
            }
        }
        talkPanel.SetBool("isShow", true);
        //UI들 bool값 바꾸기
        DisappearUI(true);

        gm.plyrMovable = false;
        gm.worldTime = 0f;
        talkindex++;
    }

    void DisappearUI(bool on)//UI 안보이게 감추는 함수, true가 감춤.
    {
        for (int i = 0; i < anim.Length; i++)
            anim[i].SetBool("OnDial", on);
        vigor.SetActive(!on);
    }

    void DelayMove()
    {
        gm.plyrMovable = true;
    }
}
