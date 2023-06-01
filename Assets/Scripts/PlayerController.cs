using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Animator animator;
    public float moveSpeed = 5;             //スピード

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //カーソルに向きを合わせる
        Vector3 mousePos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - mousePos);
        transform.localRotation = rotation;

        //プレイヤーアニメーション
        if (x >= 0 && y == 0) {                 //右
            //animator.SetTrigger("front");     //前進
            animator.SetTrigger("down");
        } else if(x <= -0.01f && y == 0) {      //左
            //animator.SetTrigger("back");      //後退
            animator.SetTrigger("up");
        }
        if(y >= 0.01f) {
            animator.SetTrigger("up");          //上がる
        } else if(y <= -0.01f) {
            animator.SetTrigger("down");        //下がる
        }
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * moveSpeed;

        //移動範囲
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -42, 42);
        pos.y = Mathf.Clamp(pos.y, -20.5f, 20.5f);
        transform.position = pos;
    }
}
