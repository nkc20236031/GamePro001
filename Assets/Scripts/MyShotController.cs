using UnityEngine;

public class MyShotController : MonoBehaviour {
    public explosion Explosion;
    public float ShotSpeed, ShotAngle;
    float x = 45;
    float y = 30;

    void Update() {
        switch (gameObject.name) {
            case "MyShot0": transform.Translate(0, ShotSpeed, 0); break;
            case "MyShot1": transform.Translate(ShotAngle, ShotSpeed, 0); break;
            case "MyShot2": transform.Translate(-ShotAngle, ShotSpeed, 0); break;
        }

        //îÕàÕäOÇ…çsÇ≠Ç∆çÌèú
        if (transform.position.x < -x || transform.position.x > x || transform.position.y < -y || transform.position.y > y) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            Instantiate(Explosion, gameObject.transform.localPosition, Quaternion.identity);
        }
    }

}
