using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject Gauge;
    GameObject Distance;
    float limit = 100f;
    float time = 0f;
    float km = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.Gauge = GameObject.Find("Gauge");
        this.Distance = GameObject.Find("distance");
    }

    void Update()
    {
        this.time += Time.deltaTime;
        this.time /= limit;
        this.Gauge.GetComponent<Image>().fillAmount -= this.time;
        if (this.Gauge.GetComponent<Image>().fillAmount  == 0) {
            SceneManager.LoadScene("TitleScene");
        }
        //60km/s
        km ++;
        this.Distance.GetComponent<Text>().text = km.ToString("000000") + "km";
    }

    public void Decrease()
    {
        this.Gauge.GetComponent<Image>().fillAmount -= 0.1f;
    }
}
