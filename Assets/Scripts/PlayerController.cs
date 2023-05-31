using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Animator animator;
    public float moveSpeed = 5;             //�X�s�[�h

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        var mousePos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - mousePos);
        transform.localRotation = rotation;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //�v���C���[�A�j���[�V����
        if(x >= 0 && y == 0) {
            animator.SetTrigger("front");   //�O�i
        } else if(x <= -0.01f && y == 0) {
            animator.SetTrigger("back");    //���
        }
        if(y >= 0.01f) {
            animator.SetTrigger("up");      //�オ��
        } else if(y <= -0.01f) {
            animator.SetTrigger("down");    //������
        }
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * moveSpeed;

        //�ړ��͈�
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -42, 42);
        pos.y = Mathf.Clamp(pos.y, -20.5f, 20.5f);
        transform.position = pos;
    }
}
