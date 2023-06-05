using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossEnemyController : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    GameObject Player;
    GameObject GameDirector;
    int attack;

    void Start() {
        Player = GameObject.Find("player");
        GameDirector = GameObject.Find("GameDirector");
        attack = 0;
    }

    void Update() {
        //�v���C���[�Ɍ����Ĉړ�
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    //�����蔻��
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            //�_���[�W
            GameDirector.GetComponent<GameDirector>().Decrease(damage);
        } else if (collision.gameObject.tag == "Shot") {
            Destroy(collision.gameObject);
            attack++;
            if (attack >= 100) {
                attack = 0;
                EnemyController.Cnt += 50;
                EnemyController.killCnt++;
                Destroy(gameObject);
            }
        }
    }
}
