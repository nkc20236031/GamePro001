using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {
    GameObject KillTxt;     //“|‚µ‚½‰ñ”
    GameObject Travel;      //ˆÚ“®‹——£

    void Start() {
        KillTxt = GameObject.Find("KillCnt");
        Travel = GameObject.Find("travel");

        KillTxt.GetComponent<Text>().text = "Kil Count: " + EnemyController.killCnt;
        Travel.GetComponent<Text>().text = GameDirector.km + "km";
    }

    void Update() {
        //Z or Button0 Start
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
