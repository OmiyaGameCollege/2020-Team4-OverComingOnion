using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBullet : MonoBehaviour
{
    // InspectorでPrefab化したBulletを指定する
    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        InvokeRepeating("Call", 3, 3);
    }

    void Update()
    {
        // 弾オブジェクトを生成して飛ばす関数を呼び出す
        ShotAction();
    }
    // 弾オブジェクトを生成して飛ばす関数
    void ShotAction()
    {

    }
    void Call()
    {
        Debug.Log("発射");
        Instantiate(bullet, transform.position, transform.rotation);

    }
}