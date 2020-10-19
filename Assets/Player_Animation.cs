using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float gravity; //重力
    public float jumpSpeed;//ジャンプする速度
    public float jumpHeight;//高さ制限
    public GroundCheck ground; //接地判定
    public GameObject　minePrefab; //渦

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private bool isGround = false;
    private bool isJump = false;
    private float jumpPos = 0.0f;

    void Start()
    {
        //コンポーネントのインスタンスを捕まえる
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //接地判定を得る
        isGround = ground.IsGround();

        //キー入力されたら行動する
        float horizontalKey = Input.GetAxis("Horizontal");
        float xSpeed = 0.0f;
        float ySpeed = -gravity;
        float verticalKey = Input.GetAxis("Vertical");

        if (isGround)
        {
            if (verticalKey > 0)
            {
                ySpeed = jumpSpeed;
                jumpPos = transform.position.y; //ジャンプした位置を記録する
                isJump = true;
            }
            else
            {
                isJump = false;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 position = transform.position;
                position.x += 3;
                Instantiate(minePrefab, position, minePrefab.transform.rotation);

            }
            

        }
        else if (isJump)
        {
            //上ボタンを押されている。かつ、現在の高さがジャンプした位置から自分の決めた位置より下ならジャンプを継続する
            if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y)
            {
                ySpeed = jumpSpeed;
            }
            else
            {
                isJump = false;
            }
        }
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = speed;
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("run", true);
            xSpeed = -speed;
        }
        else
        {
            anim.SetBool("run", false);
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, ySpeed);
     }
  
}


