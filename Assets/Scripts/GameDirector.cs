using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameDirector : MonoBehaviour {
    GameObject Gauge;
    GameObject Distance;
    GameObject killCnt;
    GameObject bar;
    public static int km;
    public static float barAmo;
    float limit = 100f;
    float time = 0f;

    void Start() {
        //フレームレートを60に固定
        Application.targetFrameRate = 60;

        this.Gauge = GameObject.Find("Gauge");
        this.Distance = GameObject.Find("distance");
        this.killCnt = GameObject.Find("KillCnt");
        this.bar = GameObject.Find("Bar_1");

        km = 0;
    }

    void Update() {
        //タイム(100s)
        this.time += Time.deltaTime;
        this.time /= limit;
        this.Gauge.GetComponent<Image>().fillAmount -= this.time;

        //タイム終了
        if (this.Gauge.GetComponent<Image>().fillAmount  == 0) {
            SceneManager.LoadScene("TitleScene");
        }

        //60km/s
        km ++;
        this.Distance.GetComponent<Text>().text = km.ToString("000000") + "km";

        //倒した数
        this.killCnt.GetComponent<Text>().text = EnemyController.killCnt.ToString() + "kill";

        //ゲージバー
        float barcnt = EnemyController.Cnt;
        barAmo = barcnt / 100;
        this.bar.GetComponent<Image>().fillAmount = barAmo;
        if (this.bar.GetComponent<Image>().fillAmount == 1) {
            EnemyController.Cnt = 0;
            this.bar.GetComponent<Image>().fillAmount = EnemyController.Cnt;

            //タイムの回復
            this.Gauge.GetComponent<Image>().fillAmount += 0.1f;
        }
    }

    public void Decrease() {
        //タイムの5/100削る
        this.Gauge.GetComponent<Image>().fillAmount -= 0.05f;
    }

    public void BDecrease() {
        //タイムの10/100削る
        this.Gauge.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void BBDecrease() {
        //タイムの50/100削る
        this.Gauge.GetComponent<Image>().fillAmount -= 0.5f;
    }
}
