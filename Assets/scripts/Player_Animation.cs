using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Animation : MonoBehaviour
{
    //インスペクターで設定する
    public float speed; //速度
    public float gravity; //重力
    public float jumpSpeed;//ジャンプする速度
    public float jumpHeight;//高さ制限
    public GroundCheck ground; //接地判定
    public GameObject UzuPrefab; //渦

    //プライベート変数
    private Animator anim = null;
    private Rigidbody2D rb = null;
    private CapsuleCollider2D capcol = null;
    private bool isGround = false;
    private bool isJump = false;
    private bool isRun = false;
    private bool isHead = false;
    private bool isDown = false;
    private bool isOtherJump = false;
    private float jumpPos = 0.0f;
    private float otherJumpHeight = 0.0f;
    private float dashTime = 0.0f;
    private float jumpTime = 0.0f;
    private float beforeKey = 0.0f;
    private string UzuTag = "Uzu";


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
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var velocity = rb.velocity;
        velocity.x = horizontal * 3;
        if (isGround)
        {
            if (Input.GetButtonDown("Jump"))
            {

                velocity.y = jumpSpeed;

                if (vertical > 0)
                {
                    jumpPos = transform.position.y; //ジャンプした位置を記録する
                    isJump = true;
                }
                else
                {
                    isJump = false;
                }
            }
            else if (isJump)
            {
                //上ボタンを押されている。かつ、現在の高さがジャンプした位置から自分の決めた位置より下ならジャンプを継続する
                if (vertical > 0 && jumpPos + jumpHeight > transform.position.y)
                {
                    isJump = true;
                    anim.SetBool("jump", true);
                }
                else
                {
                    isJump = false;
                    anim.SetBool("jump", false);
                }
            }
            if (horizontal > 0)
            {
                //transform.localScale = new Vector3(1, 1, 1);
                // 背景を反転させない処理
                GetComponent<SpriteRenderer>().flipX = false;
                // 右に走るアニメーション実行処理
                anim.SetBool("run", true);
            }
            else if (horizontal < 0)
            {
                // transform.localScale = new Vector3(-1, 1, 1);
                // 背景を反転させない処理
                GetComponent<SpriteRenderer>().flipX = true;
                // 左に走るアニメーション処理
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }
        }
        rb.velocity = velocity;

        if (Input.GetButtonDown("Fire1"))
        {
            //もしもCTRLキーを押して、渦が5個以下なら
            if (Input.GetButtonDown("Fire1") && ObjectCollision.UzuCount < 1000)
            {

                Vector3 position = transform.position;
                // もしも画像が左向きなら
                if (GetComponent<SpriteRenderer>().flipX)
                {
                    position.x -= 3;
                }

                // 右向きなら
                else
                {
                    position.x += 3;
                }

                Instantiate(UzuPrefab, position, UzuPrefab.transform.rotation);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //もしエネミーと当たったら
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Continue");
            Debug.Log("watywatya2");
        }
    }
}


