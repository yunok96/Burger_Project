using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Icecream : MonoBehaviour
{
    bool CountDone;
    bool IceControl;
    float WaitTime;
    public Text IceText;
    public GameObject RightBtn;
    public SpriteRenderer RightB;
    public GameObject LeftBtn;
    public SpriteRenderer LeftB;
    public Sprite[] Cream;
    SpriteRenderer sr;
    float Btime;
    int WhichBtn;
    int Progress;
    float HurryUp;
    Cook ck;
    bool suc;

    void Awake()
    {
        ck = GameObject.FindWithTag("CookPlace").GetComponent<Cook>();
        sr = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        CountDone = true;
        IceControl = false;
        WaitTime = 1f;
        HurryUp = 0f;
        WhichBtn = Random.Range(0, 2);
        Progress = 0;
        sr.sprite = Cream[10];
        RightBtn.SetActive(true);
        LeftBtn.SetActive(true);
        suc = false;
        Btime = 0f;
    }

    void Update()
    {
        Btime += Time.deltaTime;
        if(Progress == 0 && WhichBtn == 0)
        {
            if (Btime > 0.1f)
            {
                if (Btime > 0.2f)
                {
                    RightB.color = new Color(0, 0, 0, 0.5f);
                    Btime = 0f;
                }
                else
                    RightB.color = new Color(0, 0, 0, 0f);
            }
        }
        else if (Progress == 0 && WhichBtn == 1)
        {
            if (Btime > 0.1f)
            {
                if (Btime > 0.2f)
                {
                    LeftB.color = new Color(0, 0, 0, 0.5f);
                    Btime = 0f;
                }
                else
                    LeftB.color = new Color(0, 0, 0, 0f);
            }
        }
        
        if (CountDone == true)
        {
            IceText.text = "준비...";
            WaitTime -= Time.deltaTime;
            if (WaitTime < 0.01f)
            {
                IceControl = true;
                IceText.text = "시작!";
                CountDone = false;
            }
        }
        if(IceControl == true)
        {
            HurryUp += Time.deltaTime;
            if(HurryUp > 1f)
            {
                IceText.text = "늦었어...";
                IceControl = false;
                Invoke("DelScene", 1f);
            }

            if(WhichBtn == 0)
            {
                switch (Progress)
                {
                    case 0:
                        {
                            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                IceText.text = null;
                                sr.sprite = Cream[0];
                                HurryUp = 0f;
                                RightB.color = new Color(0, 0, 0, 0f);
                                Progress = 1;
                            }
                            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                    case 1:
                        {
                            if (Btime > 0.1f)
                            {
                                if (Btime > 0.2f)
                                {
                                    LeftB.color = new Color(0, 0, 0, 0.5f);
                                    Btime = 0f;
                                }
                                else
                                    LeftB.color = new Color(0, 0, 0, 0f);
                            }
                            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                sr.sprite = Cream[1];
                                HurryUp = 0f;
                                LeftB.color = new Color(0, 0, 0, 0f);
                                Progress = 2;
                            }
                            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                    case 2:
                        {
                            if (Btime > 0.1f)
                            {
                                if (Btime > 0.2f)
                                {
                                    RightB.color = new Color(0, 0, 0, 0.5f);
                                    Btime = 0f;
                                }
                                else
                                    RightB.color = new Color(0, 0, 0, 0f);
                            }
                            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                sr.sprite = Cream[2];
                                HurryUp = 0f;
                                RightB.color = new Color(0, 0, 0, 0f);
                                Progress = 3;
                            }
                            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                    case 3:
                        {
                            if (Btime > 0.1f)
                            {
                                if (Btime > 0.2f)
                                {
                                    LeftB.color = new Color(0, 0, 0, 0.5f);
                                    Btime = 0f;
                                }
                                else
                                    LeftB.color = new Color(0, 0, 0, 0f);
                            }
                            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                sr.sprite = Cream[3];
                                HurryUp = 0f;
                                LeftB.color = new Color(0, 0, 0, 0f);
                                Progress = 4;
                            }
                            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                    case 4:
                        {
                            if (Btime > 0.1f)
                            {
                                if (Btime > 0.2f)
                                {
                                    RightB.color = new Color(0, 0, 0, 0.5f);
                                    Btime = 0f;
                                }
                                else
                                    RightB.color = new Color(0, 0, 0, 0f);
                            }
                            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                sr.sprite = Cream[4];
                                IceText.text = "성공!";
                                IceControl = false;
                                suc = true;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                }
            }
            if(WhichBtn == 1)
            {
                switch (Progress)
                {
                    case 0:
                        {
                            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                IceText.text = null;
                                sr.sprite = Cream[5];
                                HurryUp = 0f;
                                LeftB.color = new Color(0, 0, 0, 0f);
                                Progress = 1;
                            }
                            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                    case 1:
                        {

                            if (Btime > 0.1f)
                            {
                                if (Btime > 0.2f)
                                {
                                    RightB.color = new Color(0, 0, 0, 0.5f);
                                    Btime = 0f;
                                }
                                else
                                    RightB.color = new Color(0, 0, 0, 0f);
                            }
                            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                sr.sprite = Cream[6];
                                HurryUp = 0f;
                                RightB.color = new Color(0, 0, 0, 0f);
                                Progress = 2;
                            }
                            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                    case 2:
                        {
                            if (Btime > 0.1f)
                            {
                                if (Btime > 0.2f)
                                {
                                    LeftB.color = new Color(0, 0, 0, 0.5f);
                                    Btime = 0f;
                                }
                                else
                                    LeftB.color = new Color(0, 0, 0, 0f);
                            }
                            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                sr.sprite = Cream[7];
                                HurryUp = 0f;
                                LeftB.color = new Color(0, 0, 0, 0f);
                                Progress = 3;
                            }
                            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                    case 3:
                        {
                            if (Btime > 0.1f)
                            {
                                if (Btime > 0.2f)
                                {
                                    RightB.color = new Color(0, 0, 0, 0.5f);
                                    Btime = 0f;
                                }
                                else
                                    RightB.color = new Color(0, 0, 0, 0f);
                            }
                            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                sr.sprite = Cream[8];
                                HurryUp = 0f;
                                RightB.color = new Color(0, 0, 0, 0f);
                                Progress = 4;
                            }
                            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                    case 4:
                        {
                            if (Btime > 0.1f)
                            {
                                if (Btime > 0.2f)
                                {
                                    LeftB.color = new Color(0, 0, 0, 0.5f);
                                    Btime = 0f;
                                }
                                else
                                    LeftB.color = new Color(0, 0, 0, 0f);
                            }
                            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                            {
                                sr.sprite = Cream[9];
                                IceControl = false;
                                IceText.text = "성공!";
                                suc = true;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);

                            }
                            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                            {
                                IceText.text = "다른 맛이야...";
                                IceControl = false;
                                Invoke("DelScene", 1f);
                                RightBtn.SetActive(false);
                                LeftBtn.SetActive(false);
                            }
                        }
                        break;
                }
            }
        }
    }
    void DelScene()
    {
        transform.parent.gameObject.SetActive(false);
        ck.resultFood = (suc) ? 2 : 5;
    }
}
