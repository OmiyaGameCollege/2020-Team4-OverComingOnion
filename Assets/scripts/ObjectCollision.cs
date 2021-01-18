using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{

    public static int UzuCount = 0;

    [Header("これを踏んだ時のプレイヤーが跳ねる高さ")] public float boundHeight;
    /// <summary>
    /// このオブジェクトをプレイヤーが踏んだかどうか
    /// </summary>
    [HideInInspector] public bool playerStepOn;

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        UzuCount++;
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.deltaTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //もしエネミータグと当たったら
        if (collision.gameObject.tag == "Enemy")
        {        
            //うずカウントをマイナスに
            UzuCount--;
            
            //うずを消す
            Destroy(gameObject);

        }

        //if(time <= 10.0f)
        //{
        //    Destroy(gameObject);
        //}
    }

}
