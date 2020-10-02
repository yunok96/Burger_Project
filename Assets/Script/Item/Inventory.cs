using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull = new bool[6];
    public GameObject[] slots;
    int selectedItem;

    public GameObject Inv;//자기자신. GetChild로 슬롯들 불러오는 용도

    WaitForSeconds waitTime = new WaitForSeconds(0.01f);//밝아지는 이펙트 지연시간

    public GameObject VisRan;
    public GameManager gm;
    public GameObject pl;
    public Vigor vigor;
    public Timer tc;
    public Text txt;

    public void ItemCursor()//선택 효과
    {
        StopAllCoroutines();
        Color color = slots[selectedItem].GetComponent<Image>().color;
        color.a = 0f;
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Image>().color = color;
        }
        StartCoroutine(SelectedEffectCoroutine());
    }

    IEnumerator SelectedEffectCoroutine()//선택칸 밝게
    {
        Color color = slots[0].GetComponent<Image>().color;
        while (color.a < 1f)
        {
            color.a += 0.1f;
            slots[selectedItem].GetComponent<Image>().color = color;
            yield return waitTime;
        }
    }
    
    void Start()
    {
        selectedItem = 0;//시작할때 아이템 1번+선택 효과
        ItemCursor();
    }

    public void VisibleRange()
    {
        if(VisRan.activeSelf == true)
            return;
        else
            VisRan.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gm.plyrMovable)//커서 이동
        {
            if (selectedItem < slots.Length - 1)
                selectedItem++;
            else
                selectedItem = 0;
            ItemCursor();  
        }
        else if (Input.GetKeyDown(KeyCode.Q) && gm.plyrMovable)
        {
            if (selectedItem > 0)
                selectedItem--;
            else
                selectedItem = slots.Length - 1;
            ItemCursor();
        }
        VisRan.SetActive(slots[selectedItem].transform.Find("BroomUI(Clone)") || slots[selectedItem].transform.Find("PistolUI(Clone)"));

        if (!isFull[selectedItem])
        {
            txt.text = "";
        }
        else if (isFull[selectedItem])
        {
            switch (slots[selectedItem].transform.GetChild(0).tag)
            {
                case "Broom":
                    txt.text = "사용하면 근처의 주정뱅이를 정중하게 쫓아낸다";
                    break;
                case "Pistol":
                    txt.text = "사용하면 안된다";
                    break;
                case "Choco":
                    txt.text = "먹으면 힘이 나서 활기 게이지가 조금 오른다";
                    break;
                case "Coffee":
                    txt.text = "마시면 정신이 들어서 잠시 동안 이동이 빨라진다";
                    break;
                case "Candy":
                    txt.text = "먹으면 너무 달콤해서 시간이 빨리 지나간다";
                    break;
            }
            if (Input.GetKeyDown(KeyCode.Space) && gm.plyrMovable)
            {
                if (isFull[selectedItem] != false)
                {
                    switch (slots[selectedItem].transform.GetChild(0).tag)
                    {
                        case "Broom":
                            pl.GetComponent<BroomAttack>().Melee();
                            break;
                        case "Pistol":
                            pl.GetComponent<PistolAttack>().Shot();
                            break;
                        case "Choco":
                            {
                                vigor.vigorCount += 10;
                                isFull[selectedItem] = false;
                                Destroy(slots[selectedItem].transform.GetChild(0).gameObject);
                            }
                            break;
                        case "Coffee":
                            {
                                pl.GetComponent<PlayerMovement>().isBoost = true;
                                pl.GetComponent<PlayerMovement>().boostTime = 0f;
                                isFull[selectedItem] = false;
                                Destroy(slots[selectedItem].transform.GetChild(0).gameObject);
                            }
                            break;
                        case "Candy":
                            {
                                tc.TimeC -= 10f;
                                isFull[selectedItem] = false;
                                Destroy(slots[selectedItem].transform.GetChild(0).gameObject);
                            }
                            break;
                    }
                }
            }
        }
    }
}
