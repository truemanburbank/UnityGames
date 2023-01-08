using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    SpriteRenderer spriter;
    Animator anim;

    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    // 물리 연산 프레임마다 호출되는 생명 주기 함수
    void FixedUpdate() 
    {
        // fixedDeltaTime: 물리 프레임 하나가 소비한 시간
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        //1. 위치 이동
        rigid.MovePosition(rigid.position + nextVec);
    }

    // 프레임이 종료되기 전 실행되는 생명주기 함수
    void LateUpdate() 
    {
        // SetDlaot(파라미터, 크기)
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            // inputVec.x가 0보다 작으면 false
            spriter.flipX = inputVec.x < 0;
        }
    }
}
