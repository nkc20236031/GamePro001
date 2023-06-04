using UnityEngine;

public class BossEnemyController : MonoBehaviour {
    GameObject player;
    public float speed;
    int attack;
    float x = 45;
    float y = 30;

    void Start() {
        player = GameObject.Find("player");
        attack = 0;
    }

    void Update() {
        //プレイヤーに向けて移動
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        //範囲外に行くと削除
        if (transform.position.x < -x || transform.position.x > x || transform.position.y < -y || transform.position.y > y) {
            Destroy(this.gameObject);
        }
    }

    //当たり判定
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);

            //GameDirectorのBDecreaseを呼び出す
            GameObject decrease = GameObject.Find("GameDirector");
            decrease.GetComponent<GameDirector>().BDecrease();
        } else if (collision.gameObject.tag == "Shot") {
            Destroy(collision.gameObject);
            attack++;
            if(attack >= 10) {
                attack = 0;
                EnemyController.killCnt++;
                EnemyController.BossCnt++;
                EnemyController.Cnt+=10;
                Destroy(gameObject);
            }
        }

    }
}