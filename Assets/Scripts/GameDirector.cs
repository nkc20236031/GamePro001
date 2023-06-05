using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    [SerializeField] private float Heal;

    public static int km;
    public static float BarAmo;

    GameObject Gauge;
    GameObject Bar;
    GameObject Distance;
    GameObject KillCnt;

    Image Timer;
    Image Skill;
    Text Score;
    Text Kill;

    float limit = 100f;
    float time = 0f;

    float BarCnt;

    void Start() {
        //フレームレートを60に固定
        Application.targetFrameRate = 60;

        km = 0;

        Gauge = GameObject.Find("Gauge");
        Bar = GameObject.Find("Bar");
        Distance = GameObject.Find("Distance");
        KillCnt = GameObject.Find("KillCnt");

        Timer = Gauge.GetComponent<Image>();
        Skill = Bar.GetComponent<Image>();
        Score = Distance.GetComponent<Text>();
        Kill = KillCnt.GetComponent<Text>();
    }

    void Update() {
        //タイム(100s)
        time += Time.deltaTime;
        time /= limit;
        Timer.fillAmount -= time;

        //タイム終了
        if (Timer.fillAmount  == 0) {
            SceneManager.LoadScene("TitleScene");
        }

        //60km/s
        km ++;
        Score.text = km.ToString("000000") + "km";

        //倒した数
        Kill.text = EnemyController.killCnt.ToString() + "kill";

        //スキルバー
        BarCnt = EnemyController.Cnt;
        BarAmo = BarCnt / 100;
        Skill.fillAmount = BarAmo;
        if (Skill.fillAmount == 1) {
            EnemyController.Cnt = 0;
            Skill.fillAmount = EnemyController.Cnt;

            //タイムの回復
            Timer.fillAmount += Heal;
        }
    }

    public void Decrease(float Damage) {
        Timer.fillAmount -= Damage;
    }
}
