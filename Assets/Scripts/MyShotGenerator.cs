using UnityEngine;

public class MyShotGenerator : MonoBehaviour {
    public GameObject MyShotPrefab;
    GameObject player;
    public float span, delta;

    void Start() {
        this.player = GameObject.Find("player");
    }

    void Update() {
        float x = this.player.transform.position.x;
        float y = this.player.transform.position.y;

        //span•b‚²‚Æ‚Éo‚·
        this.delta += Time.deltaTime;
        if (Input.GetButton("Shot") && this.delta > this.span) {
            this.delta = 0;
            for (int i = 0; i < 3; i++) {
                GameObject attack = Instantiate(MyShotPrefab);
                attack.name = "MyShot" + i;
                attack.transform.position = new Vector2(x, y);
                attack.transform.localRotation = player.transform.rotation;
            }
        }
    }
}
