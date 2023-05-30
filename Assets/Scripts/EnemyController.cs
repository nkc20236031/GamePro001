using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public static int killCnt;      //Enemy��|������
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

        //�t���[�����Ƃɓ����ňړ�
        transform.Translate(-0.5f, move * 1.5f, 0);

        //��ʊO�ł̃I�u�W�F�N�g�j��
        if (transform.position.x < -35.0f) {
            Destroy(gameObject);
        }
    }

    //�����蔻��
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //GameDirector��Decrease���Ăяo��
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().Decrease();
        } else if(collision.gameObject.tag == "Shot") {
            killCnt++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
