using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyGenerator : MonoBehaviour {
    public GameObject BossEnemyPrefab;
    int cnt = 0;
    float span = 0.75f;
    float delta = 0;

    void Update() {
        //1�b����
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
            switch (go.name)
            {
                case "BossEnemyPrefab0":
                    go.transform.position = new Vector3(45, y, 0);
                    break;
                case "BossEnemyPrefab1":
                    go.transform.position = new Vector3(-45, y, 0);
                    break;
                case "BossEnemyPrefab2":
                    go.transform.position = new Vector3(x, 25, 0);
                    break;
                case "BossEnemyPrefab3":
                    go.transform.position = new Vector3(x, -25, 0);
                    break;

            }
            this.span = Random.Range(1f, 1.5f);
        }
    }

}
