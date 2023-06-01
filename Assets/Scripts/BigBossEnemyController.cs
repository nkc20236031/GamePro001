using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossEnemyController : MonoBehaviour {
    GameObject player;
    int attack;

    void Start() {
        player = GameObject.Find("player");

        attack = 0;
    }

    void Update() {
        //�v���C���[�Ɍ����Ĉړ�
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5 * Time.deltaTime);
    }

    //�����蔻��
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            //GameDirector��BDecrease���Ăяo��
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().BBDecrease();
        } else if (collision.gameObject.tag == "Shot") {
            Destroy(collision.gameObject);
            attack++;
            if (attack >= 100) {
                attack = 0;
                EnemyController.Cnt+=50;
                EnemyController.killCnt++;
                Destroy(gameObject);
            }
        }
    }
}
