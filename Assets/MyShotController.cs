using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyShotController : MonoBehaviour
{
    void Update()
    {
        //�t���[�����Ƃɓ����ňړ�
        transform.Translate(0, 0.5f, 0);

        //��ʊO�ł̃I�u�W�F�N�g�j��
        if (transform.position.x > 35.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("����������");
    }
}
