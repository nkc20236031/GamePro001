using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    GameObject player;
    public static int killCnt;      //Enemyを倒した回数
    public static int Cnt;
    int counter = 0;
    float move = 0.02f;
    float max = 30;

    void Start () {
        player = GameObject.Find("player");
    }

    void Update() {
        counter++;
        if (counter == max) {
            counter = 0;
            move *= Random.Range(-4, 4);
            if(move >= 10) {
                move = 10;
            }
        }

        //プレイヤーのほうに向かって移動
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 15 * Time.deltaTime);

        //範囲外に行くと削除
        if (transform.position.x < -45 || transform.position.x > 45 || transform.position.y < -30 || transform.position.y > 30)
        {
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(this.gameObject);
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
            Cnt++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
