using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    void Update() {
        //�t���[�����Ƃɓ����ňړ�
        switch (gameObject.name)
        {
            case "MyShot0Prefab":
                transform.Translate(0, 0.5f, 0);
                break;
            case "MyShot1Prefab":
                transform.Translate(0.25f, 0.5f, 0);
                break;
            case "MyShot2Prefab":
                transform.Translate(-0.25f, 0.5f, 0);
                break;
        }

        //��ʊO�ł̃I�u�W�F�N�g�j��
        if (transform.position.x > 35.0f) {
            Destroy(gameObject);
        }
    }
}
