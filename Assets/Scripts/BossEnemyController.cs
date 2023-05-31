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
        //�v���C���[�̂ق��Ɍ������Ĉړ�
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 7.5f * Time.deltaTime);

        //�͈͊O�ɍs���ƍ폜
        if (transform.position.x < -45 || transform.position.x > 45 || transform.position.y < -30 || transform.position.y > 30) {
            Destroy(this.gameObject);
        }
    }

    //�����蔻��
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //GameDirector��BDecrease���Ăяo��
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().BDecrease();
        } else if (collision.gameObject.tag == "Shot") {
            attack++;
            if(attack >= 3) {
                attack = 0;
                EnemyController.Cnt++;
                EnemyController.killCnt++;
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }

    }
}