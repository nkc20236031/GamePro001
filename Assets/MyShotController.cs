using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotController : MonoBehaviour
{
    GameObject enemy;

    void Start()
    {
        this.enemy = GameObject.Find("EnemyPrefab");
    }

    void Update()
    {
        //フレームごとに等速で移動
        transform.Translate(0, 0.5f, 0);

        //画面外でのオブジェクト破棄
        if (transform.position.x > 35.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("gomikasu");
        GameObject attack = collision.gameObject;
        if (collision.GetComponent<Transform>().tag == "Enemy")
        {
            attack.GetComponent<EnemyController>().Attack();
            Destroy(gameObject);
        }
    }
}
