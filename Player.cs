using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
   
    bool wDown;
    bool jDown;

    bool IsJump;
    bool IsDodge;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Rigidbody rigid;

    Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
   
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Dodge();
    }

    void GetInput()
    {
        //벽과 물리충돌무시 버그는 Rigidbody - Collision Detection에서 Contiuos로 바꿀 것
        //벽을 static으로 설정해줘야 효과적
        //캐릭터 관성 문제는 Rigidbody - Constraints - Freeze Rotation x,z축 체크
        //Walk는 Project Setting - Input Manager에 추가
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");//누르자마자 즉시
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (IsDodge) { moveVec = dodgeVec; }
        
        //걸을때 속력 조절
        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("IsRun", moveVec != Vector3.zero);
        anim.SetBool("IsWalk", wDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jDown && moveVec == Vector3.zero && !IsJump && !IsDodge)
        {
            rigid.AddForce(Vector3.up * 15,ForceMode.Impulse);
            anim.SetBool("IsJump", true);
            anim.SetTrigger("doJump");
            IsJump = true;
        }
    }

    void Dodge()
    {
        if (jDown && moveVec != Vector3.zero && !IsJump && !IsDodge)
        {
            dodgeVec = moveVec;
            speed *= 2;
            anim.SetTrigger("doDodge");
            IsDodge = true;

            Invoke("DodgeOut", 0.5f);
        }
    }

    void DodgeOut()
    {
        speed *= 0.5f;
        IsDodge = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("IsJump", false);
            IsJump = false;
        }
    }

}
