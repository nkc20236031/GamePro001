using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    void Update()
    {
        //Z or Button0 Start
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
