using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyShotController : MonoBehaviour {
    void Update() {
        //フレームごとに等速で移動
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

        //画面外でのオブジェクト破棄
        if (transform.position.x > 35.0f) {
            Destroy(gameObject);
        }
    }
}
