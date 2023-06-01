using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BossEnemyController : MonoBehaviour {
    Animator animator;
    GameObject player;
    int attack;

    void Start() {
        animator = GetComponent<Animator>();
        animator.speed = 0.25f;

        player = GameObject.Find("player");

        attack = 0;
    }

    void Update() {
        //プレイヤーに向けて移動
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 7.5f * Time.deltaTime);

        //範囲外に行くと削除
        if (transform.position.x < -45 || transform.position.x > 45 || transform.position.y < -30 || transform.position.y > 30) {
            Destroy(this.gameObject);
        }
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //GameDirectorのBDecreaseを呼び出す
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().BDecrease();
        } else if (collision.gameObject.tag == "Shot") {
            Destroy(collision.gameObject);
            attack++;
            if(attack >= 10) {
                attack = 0;
                EnemyController.killCnt++;
                EnemyController.BossCnt++;
                EnemyController.Cnt+=10;
                Destroy(gameObject);
            }
        }

    }
}