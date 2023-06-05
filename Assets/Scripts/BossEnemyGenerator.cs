using UnityEngine;

public class BossEnemyGenerator : MonoBehaviour {
    [SerializeField] private GameObject BossEnemyPrefab;
    [SerializeField] private float x, y;
    [SerializeField] private float span, delta;
    int cnt;

    void Update() {
        //span�b���Ƃɏo��
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            GameObject go = Instantiate(BossEnemyPrefab);
            int Ranx = Random.Range(-40, 40);
            int Rany = Random.Range(-18, 18);
            cnt++;
            if (cnt > 3) {
                cnt = 0;
            }
            go.name = "BossEnemyPrefab" + cnt;

            //�X�|�[���ʒu
            switch (go.name) {
                case "BossEnemyPrefab0":                                //�E
                    go.transform.position = new Vector3(x, Rany, 0);
                    break;
                case "BossEnemyPrefab1":                                //��
                    go.transform.position = new Vector3(-x, Rany, 0);
                    break;
                case "BossEnemyPrefab2":                                //��
                    go.transform.position = new Vector3(Ranx, y, 0);
                    break;
                case "BossEnemyPrefab3":                                //��
                    go.transform.position = new Vector3(Ranx, -y, 0);
                    break;
            }
        }
    }
}
