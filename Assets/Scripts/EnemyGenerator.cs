using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject EnemyPrefab;
    public float span, delta;
    int cnt = 0;
    float x = 45;
    float y = 25;

    void Update() {
        //span秒ごとに1~3回出す
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            for (int i = 0; i < Random.Range(1, 2);  i++) {
                GameObject go = Instantiate(EnemyPrefab);
                int Ranx = Random.Range(-40, 40);
                int Rany = Random.Range(-18, 18);
                cnt++;
                if (cnt > 3) {
                    cnt = 0;
                }
                go.name = "EnemyPrefab" + cnt;
                //スポーン位置
                switch (go.name) {
                    case "EnemyPrefab0":                                    //右
                        go.transform.position = new Vector3(x, Rany, 0);
                        break;
                    case "EnemyPrefab1":                                    //左
                        go.transform.position = new Vector3(-x, Rany, 0);
                        break;
                    case "EnemyPrefab2":                                    //上
                        go.transform.position = new Vector3(Ranx, y, 0);
                        break;
                    case "EnemyPrefab3":                                    //下
                        go.transform.position = new Vector3(Ranx, -y, 0);
                        break;
                }
            }
        }
    }
}
