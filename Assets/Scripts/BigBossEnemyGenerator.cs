using UnityEngine;

public class BigBossEnemyGenerator : MonoBehaviour {
    [SerializeField] private GameObject BossEnemyPrefab;
    [SerializeField] private float BossCnt;
    bool bosscheck = false;

    void Update() {
        //Enemyを一定数倒したら出す
        float cnt = EnemyController.killCnt % BossCnt;
        if (bosscheck == false && cnt == 0 && EnemyController.killCnt > 0) {
            bosscheck = true;
            GameObject go = Instantiate(BossEnemyPrefab);
            go.name = "BigBossEnemyPrefab";
            go.transform.position = new Vector3(0, 25, 0);
        }
    }
}