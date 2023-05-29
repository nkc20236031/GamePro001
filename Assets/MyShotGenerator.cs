using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShotGenerator : MonoBehaviour
{
    public GameObject MyShotPrefab;
    GameObject player;
    Vector2 players = Vector2.zero;

    void Start()
    {
        this.player = GameObject.Find("player");
    }

    void Update()
    {
        this.players.x = this.player.transform.position.x;
        this.players.y = this.player.transform.position.y;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject attack = Instantiate(MyShotPrefab);
            attack.name = "MyShotPrefab";
            attack.transform.position = new Vector2(players.x, players.y);
        }
    }
}
