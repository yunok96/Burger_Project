using TMPro;
using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    public bool isGetFood = false;
    public Vector3 targetTable;
    public int whoIsMe;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = (isGetFood) ? Vector3.MoveTowards(transform.position, new Vector3(-17, transform.position.y, 0), 3 * Time.deltaTime) : Vector3.MoveTowards(transform.position, targetTable, 3 * Time.deltaTime);
        if (transform.position == targetTable)
            anim.SetBool("GetPoint", true);
        else
            anim.SetBool("GetPoint", false);
    }
}
