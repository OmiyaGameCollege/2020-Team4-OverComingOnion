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
    // Start is called before the first frame update
    void Start()
    {
        UzuCount++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {        
            UzuCount--;

            Destroy(gameObject);

        }
    }
}
