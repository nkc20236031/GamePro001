using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyShotController : MonoBehaviour
{
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("当たったよ");
    }
}
