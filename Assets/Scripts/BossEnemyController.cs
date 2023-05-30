using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BossEnemyController : MonoBehaviour {
    void Update() {
        //フレームごとに等速で移動
        transform.Translate(-0.25f, 0, 0);

        //画面外でのオブジェクト破棄
        if (transform.position.x < -35.0f) {
            Destroy(gameObject);
        }
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //GameDirectorのBDecreaseを呼び出す
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().BDecrease();
        }
    }
}