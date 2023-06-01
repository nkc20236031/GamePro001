using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyGenerator : MonoBehaviour {
    public GameObject BossEnemyPrefab;
    int cnt = 0;
    float span = 0.75f;
    float delta = 0;

    void Update() {
        //span秒ごとに出す
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            GameObject go = Instantiate(BossEnemyPrefab);
            int x = Random.Range(-40, 40);
            int y = Random.Range(-18, 18);
            cnt++;
            if (cnt > 3) {
                cnt = 0;
            }
            go.name = "BossEnemyPrefab" + cnt;

            //スポーン位置
            switch (go.name)
            {
                case "BossEnemyPrefab0":                                //右
                    go.transform.position = new Vector3(45, y, 0);
                    break;
                case "BossEnemyPrefab1":                                //左
                    go.transform.position = new Vector3(-45, y, 0);
                    break;
                case "BossEnemyPrefab2":                                //上
                    go.transform.position = new Vector3(x, 25, 0);
                    break;
                case "BossEnemyPrefab3":                                //下
                    go.transform.position = new Vector3(x, -25, 0);
                    break;

            }
            //スポーン間隔
            this.span = Random.Range(1f, 1.5f);
        }
    }
}
