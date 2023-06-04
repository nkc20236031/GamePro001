using UnityEngine;

public class EnemyController : MonoBehaviour {
    GameObject player;
    public static int killCnt;      //Enemy��|������
    public static int BossCnt;
    public static int Cnt;
    int counter;
    float move;
    float max;
    float x = 45;
    float y = 30;

    void Start () {
        player = GameObject.Find("player");
    }

    void Update() {
        counter++;
        if (counter == max) {
            counter = 0;
            move *= Random.Range(-4, 4);
            if(move >= 10) {
                move = 10;
            }
        }

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

            //GameDirector��Decrease���Ăяo��
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().Decrease();
        } else if(collision.gameObject.tag == "Shot") {
            killCnt++;
            BossCnt++;
            Cnt++;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
