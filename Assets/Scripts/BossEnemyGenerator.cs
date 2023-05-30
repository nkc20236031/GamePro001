using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyGenerator : MonoBehaviour {
    public GameObject BossEnemyPrefab;
    float span = 0.75f;
    float delta = 0;

    void Update() {
        //1•b‚²‚Æ
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            GameObject go = Instantiate(BossEnemyPrefab);
            int px = Random.Range(-13, 13);
            go.name = "BossEnemyPrefab";
            go.transform.position = new Vector3(35, px, 0);
            this.span = Random.Range(1f, 1.5f);
        }
    }

}
