using UnityEngine;

public class MyShotController : MonoBehaviour {
    public explosion Explosion;
    public float ShotSpeed;
    public float ShotAngle;
    float x = 45;
    float y = 30;

    void Start () {
        //カーソルに向きを合わせる
        Vector3 mousePos = Camera.main.WorldToScreenPoint(transform.localPosition);
        transform.localRotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - mousePos);
    }

    void Update() {
        //フレームごとに等速で移動
        switch (gameObject.name) {
            case "MyShot0Prefab":                       //真ん中
                transform.Translate(0, ShotSpeed, 0);
                break;
            case "MyShot1Prefab":                       //右
                transform.Translate(ShotAngle, ShotSpeed, 0);
                break;
            case "MyShot2Prefab":                       //左
                transform.Translate(-ShotAngle, ShotSpeed, 0);
                break;
        }

        //範囲外に行くと削除
        if (transform.position.x < -x || transform.position.x > x || transform.position.y < -y || transform.position.y > y) {
            Destroy(gameObject);
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
