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
    public bool isAction;
    public int talkindex;
    public DControl ct;
    CameraShake Vib;

    public GameObject ow;
    public GameObject movetut;
    public GameObject BurgerNav;
    public GameObject cooktut;
    public GameObject InvisibleBlock;
    public GameObject CounterNav;
    public GameObject csp;
    SpawnerTut spaw;
    BanJackBanJack3 ban3;
    BanJackBanJack4 ban4;
    void Awake()
    {
        ban4 = GameObject.Find("ISpawn (25)").GetComponent<BanJackBanJack4>();
        ban3 = GameObject.Find("ISpawn (30)").GetComponent<BanJackBanJack3>();
        Vib = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
        spaw = GameObject.FindWithTag("Spawn").GetComponent<SpawnerTut>();
    }
    public void Action()
    {
        talk(ct.id);
    }
    void talk(int id)
    {
        if (ct.id == 0)
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
            StatVar.instance.time1 = 1f;
            talkPanel.SetBool("isShow", false);
            portL.color = new Color(1, 1, 1, 0);
            portLB.color = new Color(0, 0, 0, 0);
            portR.color = new Color(1, 1, 1, 0);
            portRB.color = new Color(0, 0, 0, 0);
            talkindex = 0;
            ct.id = 0;
            return;
        }
        else if (talkData.Split(':')[0] == "Event")//이벤트 보여줄때 대화창 일시적으로 숨기기, 움직임은 x
        {//이후 이벤트 종류
            if (talkData.Split(':')[1] == "0")
            {
                StatVar.instance.Movable = true;
            }
            if (talkData.Split(':')[1] == "1")
                ow.GetComponent<Owner>().start = true;
            else if (talkData.Split(':')[1] == "2")
            {
                movetut.SetActive(true);
                Invoke("DelayMove", 0.1f);
            }
            else if(talkData.Split(':')[1] == "3")
            {
                BurgerNav.GetComponent<BanJackBanJack>().IsBurgerNavBlink = true;
                Invoke("DelayMove", 0.1f);
            }
            else if (talkData.Split(':')[1] == "4")
            {
                cooktut.SetActive(true);
                InvisibleBlock.SetActive(true);
                //햄버거 조리 타일 주위에 보이지 않는 벽 생성해서 못나가게 막음
                Invoke("DelayMove", 0.1f);
            }
            else if (talkData.Split(':')[1] == "5")
            {
                CounterNav.GetComponent<BanJackBanJack2>().IsCounterNavBlink = true;
                Invoke("DelayMove", 0.1f);
            }
            else if (talkData.Split(':')[1] == "6")
            {
                csp.GetComponent<CustomerSpawnTut>().walkoutspeed = 1f;
                Invoke("DelayMove", 0.1f);
            }
            else if (talkData.Split(':')[1] == "7")
            {
                spaw.SpawnEnemy();
            }
            else if (talkData.Split(':')[1] == "8")
            {
                Invoke("DelayMove", 0.1f);
                ban3.IsNavBlink = true;
            }
            else if (talkData.Split(':')[1] == "8")
            {
                Invoke("DelayMove", 0.1f);
                ban3.IsNavBlink = true;
            }
            else if (talkData.Split(':')[1] == "9")
            {
                Invoke("DelayMove", 0.1f);
                ban4.IsNavBlink2 = true;
            }
            else if (talkData.Split(':')[1] == "10")
            {
                SceneManager.LoadScene("MainGame");
            }
            talkPanel.SetBool("isShow", false);
            portL.color = new Color(1, 1, 1, 0);
            portLB.color = new Color(0, 0, 0, 0);
            portR.color = new Color(1, 1, 1, 0);
            portRB.color = new Color(0, 0, 0, 0);
            talkindex = 0;
            ct.id = 0;
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
        StatVar.instance.Movable = false;
        talkindex++;
    }

    void DelayMove()
    {
        StatVar.instance.Movable = true;
    }
}
