using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossEnemyGenerator : MonoBehaviour {
    public GameObject BossEnemyPrefab;
    bool bosscheck = false;

    void Update() {
        //Enemy‚ðˆê’è”“|‚µ‚½‚ço‚·
        if (EnemyController.killCnt >= 300 && bosscheck == false) {
            bosscheck = true;
            GameObject go = Instantiate(BossEnemyPrefab);
            go.name = "BigBossEnemyPrefab";
            go.transform.position = new Vector3(0, 25, 0);
        }
    }
}