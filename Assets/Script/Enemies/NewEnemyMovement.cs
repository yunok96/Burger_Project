using UnityEngine;

public class NewEnemyMovement : MonoBehaviour
{
    Animator anim;
    public Transform movePoint;
    public LayerMask PlayerLayer;
    public LayerMask WhatStopMove;
    float curTime;
    float maxTime;
    public Vector3 target;
    GameManager gm;

    void Awake()
    {
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        maxTime = 3f;
    }

    void Start()
    {
        movePoint.parent = null;//종속관계 해제
    }
    void OnEnable()
    {
        curTime = 0f;
    }

    void Update()
    {
        if (transform.position == target)
        {
            anim.SetTrigger("GetTarget");
        }
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 3 * Time.deltaTime);//본체가 무브포인터로 움직이는 속도
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)//무브포인터와 본체의 거리가 가까우면
        {
            if (movePoint.position != target)//무브포인터의 위치와 타겟의 위치가 같지 않다면
            {
                curTime += Time.deltaTime * gm.worldTime;
                if (curTime > maxTime)
                {
                    if (movePoint.position.x != target.x)
                        MoveLR();
                    else if (movePoint.position.y != target.y)
                        MoveUD();
                }
            }
        }
    }

    void MoveLR()
    {
        if (curTime > maxTime)
        {
            if (movePoint.position.x < target.x)//무브포인터의 x축보다 타겟의 x축이 크다면(우측) 
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, WhatStopMove))//무브포인터가 이동하는 방향에 지정한 레이어가 없다면
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);//무브포인터 이동
                    curTime = 0f;
                }
                else if (Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, WhatStopMove))
                {
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(1f, 0f, 0f), .2f, PlayerLayer))
                    {
                        curTime = 1.5f;
                        return;
                    }
                    else
                    {
                        curTime = 0f;
                        MoveUD();
                    }
                }
            }
            else if (movePoint.position.x > target.x)//무브포인터의 x축보다 타겟의 x축이 작다면(좌측) 
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, WhatStopMove))//무브포인터가 이동하는 방향에 지정한 레이어가 없다면
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);//무브포인터 이동
                    curTime = 0f;
                }
                else if (Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, WhatStopMove))
                {
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(-1f, 0f, 0f), .2f, PlayerLayer))
                    {
                        curTime = 1.5f;
                        return;
                    }
                    else
                    {
                        curTime = 0f;
                        MoveUD();
                    }
                }
            }
        }
    }

    void MoveUD()
    {
        if (curTime > maxTime)
        {
            if (movePoint.position.y > target.y || movePoint.position.y == target.y)//무브포인터의 x축보다 타겟의 x축이 작다면(아래쪽) 
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, WhatStopMove))//무브포인터가 이동하는 방향에 지정한 레이어가 없다면
                {
                    movePoint.position += new Vector3(0f, -1f, 0f);//무브포인터 이동
                    curTime = 0f;
                }
                else if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, WhatStopMove))
                {
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, -1f, 0f), .2f, PlayerLayer))
                    {
                        curTime = 1.5f;
                        return;
                    }
                    else
                    {
                        curTime = 0f;
                        MoveLR();
                    }
                }
            }
            else if (movePoint.position.y < target.y || movePoint.position.y == target.y)//무브포인터의 y축보다 타겟의 y축이 크다면(위쪽) 
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, WhatStopMove))//무브포인터가 이동하는 방향에 지정한 레이어가 없다면
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);//무브포인터 이동
                    curTime = 0f;
                }
                else if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, WhatStopMove))
                {
                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, 1f, 0f), .2f, PlayerLayer))
                    {
                        curTime = 1.5f;
                        return;
                    }
                    else
                    {
                        curTime = 0f;
                        MoveLR();
                    }
                }
            }
        }
    }
}
