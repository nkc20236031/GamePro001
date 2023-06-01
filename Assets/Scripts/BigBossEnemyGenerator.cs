using UnityEngine;

public class BigBossEnemyGenerator : MonoBehaviour {
    public GameObject BossEnemyPrefab;
    public float BossCnt;
    bool bosscheck = false;

    void Update() {
        //Enemy‚ðˆê’è”“|‚µ‚½‚ço‚·
        float cnt = EnemyController.killCnt % BossCnt;
        if (bosscheck == false && cnt == 0 && EnemyController.killCnt > 0) {
            bosscheck = true;
            GameObject go = Instantiate(BossEnemyPrefab);
            go.name = "BigBossEnemyPrefab";
            go.transform.position = new Vector3(0, 25, 0);
        }
    }
}