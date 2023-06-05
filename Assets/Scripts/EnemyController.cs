using UnityEngine;

public class EnemyController : MonoBehaviour {
    [SerializeField] private float x, y;
    [SerializeField] private float damage;
    public static int killCnt;      //Enemyを倒した回数
    public static int BossCnt;
    public static int Cnt;
    GameObject player;

    void Start () {
        player = GameObject.Find("player");
    }

    void Update() {
        //プレイヤーに向けて移動
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 15 * Time.deltaTime);

        //範囲外に行くと削除
        if (transform.position.x < -x || transform.position.x > x || transform.position.y < -y || transform.position.y > y) {
            Destroy(this.gameObject);
        }
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //ダメージ
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
