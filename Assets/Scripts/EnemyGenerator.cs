using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
    public GameObject EnemyPrefab;
    int cnt = 0;
    public float span = 0.375f;
    public float delta = 0;

    void Update() {
        //span�b���Ƃ�1~3��o��
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            for (int i = 0; i < Random.Range(1, 2);  i++) {
                GameObject go = Instantiate(EnemyPrefab);
                int x = Random.Range(-40, 40);
                int y = Random.Range(-18, 18);
                cnt++;
                if (cnt > 3) {
                    cnt = 0;
                }
                go.name = "EnemyPrefab" + cnt;
                //�X�|�[���ʒu
                switch (go.name) {
                    case "EnemyPrefab0":                                    //�E
                        go.transform.position = new Vector3(45, y, 0);
                        break;
                    case "EnemyPrefab1":                                    //��
                        go.transform.position = new Vector3(-45, y, 0);
                        break;
                    case "EnemyPrefab2":                                    //��
                        go.transform.position = new Vector3(x, 25, 0);
                        break;
                    case "EnemyPrefab3":                                    //��
                        go.transform.position = new Vector3(x, -25, 0);
                        break;
                }
            }
        }
    }
}
