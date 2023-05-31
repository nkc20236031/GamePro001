using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    Animator animator;

    void Start () {
        animator = GetComponent<Animator>();
        animator.speed = 0.25f;

        var mousePos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - mousePos);
        transform.localRotation = rotation;
    }

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

        //�͈͊O�ɍs���ƍ폜
        if (transform.position.x < -45 || transform.position.x > 45 || transform.position.y < -30 || transform.position.y > 30) {
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
