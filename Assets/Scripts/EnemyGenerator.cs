using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject EnemyPrefab;
    float span = 0.25f;
    float delta = 0;

    void Update() {
        //0.25•b‚²‚Æ‚É3~5‰ñ
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            for (int i = 0; i < Random.Range(3, 5);  i++)
            {
                GameObject go = Instantiate(EnemyPrefab);
                int px = Random.Range(-14, 14);
                go.name = "EnemyPrefab";
                go.transform.position = new Vector3(45, px, 0);
            }
            this.span = Random.Range(0.1f, 0.5f);
        }
    }
}
