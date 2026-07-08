using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO.Compression;
using UnityEngine;

public class OnKeyPressMoveGravity3 : MonoBehaviour
{
    //---------------------------------------------------
    public InputKey junpkey = InputKey.Jump;
    public float speed = 5f;
    public float jumppower = 1f;
    public float checkDistance = 0.1f;
    public float footOffset = 0.01f;
    //----------------------------------------------------
    Rigidbody2D rbody;
    float vx = 0;
    bool leftFlag;
    bool isGrounded;
    bool isJumping = false;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        vx = 0;
        vx = Input.GetAxisRaw("Horizontal") * speed;
        if (vx != 0)
        {
            leftFlag = vx < 0;
        }
        rbody.linearVelocity = new Vector2(vx,rbody.linearVelocity.y);
        GetComponent<SpriteRenderer>().flipX = leftFlag;

        // 足の下が何かに触れているかを調べる
        float myHeight = GetComponent<Collider2D>().bounds.extents.x;
        float footy = transform.position.y - myHeight - footOffset;
        Vector2 startRay = new Vector2(transform.position.x, footy);
        isGrounded = Physics2D.Raycast(startRay, Vector2.down, checkDistance);
        // ジャンプキーが押されていて、ジャンプ中でなければジャンプ
        if (Input.GetButtonDown(junpkey.ToString()) && isGrounded && !isGrounded)
        {
            isJumping = true;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
        if (rbody.linearVelocity.y <= 0)
        {
            isJumping = false;
        }
    }
}