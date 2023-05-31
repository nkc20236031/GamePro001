using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject EnemyPrefab;
    int cnt = 0;
    float span = 0.25f;
    float delta = 0;

    void Update() {
        //0.25•b‚²‚Æ‚É3~5‰ñ
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            for (int i = 0; i < Random.Range(1, 3);  i++)
            {
                GameObject go = Instantiate(EnemyPrefab);
                int x = Random.Range(-40, 40);
                int y = Random.Range(-18, 18);
                cnt++;
                if (cnt > 3) {
                    cnt = 0;
                }
                go.name = "EnemyPrefab" + cnt;
                switch (go.name) {
                    case "EnemyPrefab0":
                        go.transform.position = new Vector3(45, y, 0);
                        break;
                    case "EnemyPrefab1":
                        go.transform.position = new Vector3(-45, y, 0);
                        break;
                    case "EnemyPrefab2":
                        go.transform.position = new Vector3(x, 25, 0);
                        break;
                    case "EnemyPrefab3":
                        go.transform.position = new Vector3(x, -25, 0);
                        break;

                }
            }
            this.span = Random.Range(0.1f, 0.5f);
        }
    }
}
