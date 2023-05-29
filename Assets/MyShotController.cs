using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyShotController : MonoBehaviour
{
    GameObject[] enemy;

    void Start()
    {
        this.enemy = GameObject.FindGameObjectsWithTag("EnemyPrefab");
    }

    void Update()
    {
        //�t���[�����Ƃɓ����ňړ�
        transform.Translate(0, 0.5f, 0);

        //��ʊO�ł̃I�u�W�F�N�g�j��
        if (transform.position.x > 35.0f)
        {
            Destroy(gameObject);
        }
        //�����蔻��
        Vector2 p1 = transform.position;
        Vector2 p2 = this.enemy.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 3.75f;

        if (d < r1 + r2)
        {
            GameObject attack = GameObject.Find("EnemyPrefab");
            attack.GetComponent<EnemyController>().Attack();
            Destroy(gameObject);
        }
    }
}
