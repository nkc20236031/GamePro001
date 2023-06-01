using UnityEngine;

public class MyShotController : MonoBehaviour {
    public explosion Explosion;
    public float ShotSpeed;
    public float ShotAngle;
    float x = 45;
    float y = 30;

    void Start () {
        //�J�[�\���Ɍ��������킹��
        Vector3 mousePos = Camera.main.WorldToScreenPoint(transform.localPosition);
        transform.localRotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - mousePos);
    }

    void Update() {
        //�t���[�����Ƃɓ����ňړ�
        switch (gameObject.name) {
            case "MyShot0Prefab":                       //�^��
                transform.Translate(0, ShotSpeed, 0);
                break;
            case "MyShot1Prefab":                       //�E
                transform.Translate(ShotAngle, ShotSpeed, 0);
                break;
            case "MyShot2Prefab":                       //��
                transform.Translate(-ShotAngle, ShotSpeed, 0);
                break;
        }

        //�͈͊O�ɍs���ƍ폜
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
