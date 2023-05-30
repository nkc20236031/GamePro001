using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotupGenerator : MonoBehaviour {
    public GameObject MyShotPrefab;
    GameObject player;
    Vector2 players = Vector2.zero;
    float span = 0.125f;
    float delta = 0;

    void Start() {
        this.player = GameObject.Find("player");
    }

    void Update() {
        this.players.x = this.player.transform.position.x;
        this.players.y = this.player.transform.position.y;

        //0.125•b‚²‚Æ
        this.delta += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && this.delta > this.span || Input.GetMouseButton(0) && this.delta > this.span) {
            this.delta = 0;
            GameObject attack = Instantiate(MyShotPrefab);
            attack.name = "MyShot2Prefab";
            attack.transform.position = new Vector2(players.x, players.y);
        }
    }
}