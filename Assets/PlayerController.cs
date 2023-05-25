using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Application.targetFrameRate = 60;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(x, y) * speed;
        transform.localPosition += velocity;
    }

}
