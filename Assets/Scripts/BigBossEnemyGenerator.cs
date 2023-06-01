using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossEnemyGenerator : MonoBehaviour {
    public GameObject BossEnemyPrefab;
    bool bosscheck = false;

    void Update() {
        float cnt = EnemyController.killCnt % 500;
        //300���Ƃɏo��
        if (cnt == 0 && EnemyController.killCnt > 0) {
            bosscheck = true;
        }
        //Enemy����萔�|������o��
        if (bosscheck == true) {
            bosscheck = false;
            GameObject go = Instantiate(BossEnemyPrefab);
            go.name = "BigBossEnemyPrefab";
            go.transform.position = new Vector3(0, 25, 0);
        }
    }
}