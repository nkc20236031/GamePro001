using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    Animator animator;
    public explosion Explosion;

    void Start () {
        animator = GetComponent<Animator>();
        animator.speed = 0.25f;

        //カーソルに向きを合わせる
        var mousePos = Camera.main.WorldToScreenPoint(transform.localPosition);
        var rotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - mousePos);
        transform.localRotation = rotation;
    }

    void Update() {
        //フレームごとに等速で移動
        switch (gameObject.name) {
            case "MyShot0Prefab":                       //真ん中
                transform.Translate(0, 1, 0);
                break;
            case "MyShot1Prefab":                       //右
                transform.Translate(0.375f, 1, 0);
                break;
            case "MyShot2Prefab":                       //左
                transform.Translate(-0.375f, 1, 0);
                break;
        }

        //範囲外に行くと削除
        if (transform.position.x < -45 || transform.position.x > 45 || transform.position.y < -30 || transform.position.y > 30) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(Explosion, gameObject.transform.localPosition, Quaternion.identity);
        }
    }
}
