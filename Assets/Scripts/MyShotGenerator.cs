using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyShotGenerator : MonoBehaviour {
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

        //span•b‚²‚Æ‚Éo‚·
        this.delta += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && this.delta > this.span || Input.GetMouseButton(0) && this.delta > this.span) {
            this.delta = 0;
            for (int i = 0; i < 3;  i++)
            {
                GameObject attack = Instantiate(MyShotPrefab);
                attack.name = "MyShot" + i + "Prefab";
                attack.transform.position = new Vector2(players.x, players.y);
            }
        }
    }
}
