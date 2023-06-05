using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private float x, y;
    [SerializeField] private float damage;
    public static int killCnt;      //Enemy��|������
    public static int BossCnt;
    public static int Cnt;
    GameObject player;

    void Start () {
        player = GameObject.Find("player");
    }

    void Update() {
        //�v���C���[�Ɍ����Ĉړ�
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 15 * Time.deltaTime);

        //�͈͊O�ɍs���ƍ폜
        if (transform.position.x < -x || transform.position.x > x || transform.position.y < -y || transform.position.y > y) {
            Destroy(this.gameObject);
        }
    }

    //�����蔻��
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //�_���[�W
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().Decrease(damage);
        } else if(collision.gameObject.tag == "Shot") {
            killCnt++;
            BossCnt++;
            Cnt++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
