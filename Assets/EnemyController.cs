using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("player");
    }

    void Update()
    {
        //�t���[�����Ƃɓ����ňړ�
        transform.Translate(-0.25f, 0, 0);

        //��ʊO�ł̃I�u�W�F�N�g�j��
        if (transform.position.x < -35.0f)
        {
            Destroy(gameObject);
        }

        //�����蔻��
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 3.75f;

        if (d < r1 + r2) {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().Decrease();

            Destroy(gameObject);
        }
    }
}
