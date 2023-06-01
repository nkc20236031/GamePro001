using UnityEngine;

public class EnemyController : MonoBehaviour {
    GameObject player;
    public static int killCnt;      //Enemyを倒した回数
    public static int BossCnt;
    public static int Cnt;
    int counter;
    float move;
    float max;

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

        //プレイヤーに向けて移動
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 15 * Time.deltaTime);

        //範囲外に行くと削除
        if (transform.position.x < -45 || transform.position.x > 45 || transform.position.y < -30 || transform.position.y > 30) {
            Destroy(this.gameObject);
        }
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //GameDirectorのDecreaseを呼び出す
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
