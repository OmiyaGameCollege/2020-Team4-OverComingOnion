using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BossEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponentの処理をキャッシュしておく
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float speed = 0;
        if (gameObject.transform.forward.y == 0)
        {
            speed = moveSpeed;
        }
        //velocity: 速度
        //X方向へmoveSpeed分移動させる
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            // 障害物と衝突した場合
            if (collision.gameObject.CompareTag("Ground2"))
            {
                transform.DORotate(new Vector3(0, -180, 0), 0.5f);
                moveSpeed = 5;
            }
            if (collision.gameObject.CompareTag("Ground3"))
            {
                transform.DORotate(new Vector3(0, 360, 0), 0.5f);
                moveSpeed = -5;
            }

        }
    }
}