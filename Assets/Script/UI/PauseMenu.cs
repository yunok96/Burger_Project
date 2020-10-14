using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameManager gm;
    public StageController sc;
    Animator anim;
    public bool pauseOn = false;
    public int whereCursor;

    public GameObject pauseSE;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gm.plyrMovable && !pauseOn && !sc.once)
        {
            pauseSE.active = false;
            pauseSE.active = true;
            Invoke("wait", 0.1f);
            anim.SetBool("PauseOn", true);
            gm.plyrMovable = false;
            gm.worldTime = 0f;
            whereCursor = 0;
            changeColor();
        }
        if (pauseOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                resume();
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                whereCursor = (whereCursor == 2) ? 0 : whereCursor += 1;
                changeColor();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                whereCursor = (whereCursor == 0) ? 2 : whereCursor -= 1;
                changeColor();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                switch (whereCursor)
                {
                    case 0:
                        {
                            transform.GetChild(whereCursor).GetComponent<Animator>().SetTrigger("Resume");
                        }
                        break;
                    case 1:
                        {
                            transform.GetChild(whereCursor).GetComponent<Animator>().SetTrigger("Retry");
                        }
                        break;
                    case 2:
                        {
                            transform.GetChild(whereCursor).GetComponent<Animator>().SetTrigger("Quit");
                        }
                        break;
                }
                Invoke("waitBeforeAnim", 0.1f);
            }
        }
    }

    void waitBeforeAnim()
    {
        switch (whereCursor)
        {
            case 0:
                {
                    resume();
                }
                break;
            case 1:
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;
            case 2:
                {
                    SceneManager.LoadScene("StartMenu");
                }
                break;
        }
    }

    void changeColor()//코드 간결화 용도
    {
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).GetComponent<Image>().color = new Color(0, 0, 0);
        }
        transform.GetChild(whereCursor).GetComponent<Image>().color = new Color(1, 0, 0);
    }

    void wait()//지연 호출 용도. 지연없으면 버튼 누르자마자 true false 동시에 처리되서 호출이 안됨.
    {
        pauseOn = (pauseOn == false) ? true : false;
    }
    void resume()
    {
        pauseSE.active = false;
        Invoke("wait", 0.1f);
        anim.SetBool("PauseOn", false);
        gm.plyrMovable = true;
        gm.worldTime = 1f;
    }
}
