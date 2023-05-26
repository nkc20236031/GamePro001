using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float span = 1f;
    float delta = 0;

    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span) {
            this.delta = 0;
            GameObject go = Instantiate(EnemyPrefab);
            int px = Random.Range(-12, 12);
            go.name = "EnemyPrefab";
            go.transform.position = new Vector3(35, px, 0);
            this.span = Random.Range(0.75f, 2);
        }
    }
}
