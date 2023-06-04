using UnityEngine;

public class BossEnemyGenerator : MonoBehaviour {
    public GameObject BossEnemyPrefab;
    public float span, delta;
    int cnt;
    float x = 45;
    float y = 25;

    void Update() {
        //span秒ごとに出す
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            GameObject go = Instantiate(BossEnemyPrefab);
            int Ranx = Random.Range(-40, 40);
            int Rany = Random.Range(-18, 18);
            cnt++;
            if (cnt > 3) {
                cnt = 0;
            }
            go.name = "BossEnemyPrefab" + cnt;

            //スポーン位置
            switch (go.name)
            {
                case "BossEnemyPrefab0":                                //右
                    go.transform.position = new Vector3(x, Rany, 0);
                    break;
                case "BossEnemyPrefab1":                                //左
                    go.transform.position = new Vector3(-x, Rany, 0);
                    break;
                case "BossEnemyPrefab2":                                //上
                    go.transform.position = new Vector3(Ranx, y, 0);
                    break;
                case "BossEnemyPrefab3":                                //下
                    go.transform.position = new Vector3(Ranx, -y, 0);
                    break;

            }
        }
    }
}
