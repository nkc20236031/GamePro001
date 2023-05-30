using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BossEnemyController : MonoBehaviour {
    void Update() {
        //�t���[�����Ƃɓ����ňړ�
        transform.Translate(-0.25f, 0, 0);

        //��ʊO�ł̃I�u�W�F�N�g�j��
        if (transform.position.x < -35.0f) {
            Destroy(gameObject);
        }
    }

    //�����蔻��
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //GameDirector��BDecrease���Ăяo��
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().BDecrease();
        }
    }
}