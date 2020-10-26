using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;

    // ターゲットとなるオブジェクト
    public GameObject Player;
    // ラジアン変数
    private float rad;
    // 現在位置を代入する為の変数
    private Vector2 Position;

    // PlayerTagを呼び出す
    // PlayerTagはPlayerに設定する
    private string PlayerTag = "Player";
    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (sr.isVisible || nonVisibleAct)
        {
            int xVector = -1;
            if (rightTleftF)
            {
                xVector = 1;
                // 当たった時のエネミーの大きさ??
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            }
            else
            {
                // 当たってない状態のエネミーの大きさ
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
            }
            rb.velocity = new Vector2(xVector * speed, -gravity);
        }
        else
        {
            rb.Sleep();
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // もしもPlayertagを持つオブジェクトに当たったら
        if (collision.collider.tag == PlayerTag)
        {

        } 
        //もしエネミーと当たったら
        if (collision.gameObject.tag == "Uzu")
        {
            //エネミーが消える
            Destroy(gameObject);
        }


    }


}

