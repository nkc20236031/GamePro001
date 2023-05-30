using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public static int killCnt;      //Enemyを倒した回数
    int counter = 0;
    float move = 0.02f;
    float max = 30;

    void Update() {
        counter++;
        if (counter == max)
        {
            counter = 0;
            move *= Random.Range(-4, 4);
        }

        //フレームごとに等速で移動
        transform.Translate(-0.5f, move * 1.5f, 0);

        //画面外でのオブジェクト破棄
        if (transform.position.x < -35.0f) {
            Destroy(gameObject);
        }
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //GameDirectorのDecreaseを呼び出す
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().Decrease();
        } else if(collision.gameObject.tag == "Shot") {
            killCnt++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
