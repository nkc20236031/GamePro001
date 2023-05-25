using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 5;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(x >= 0 && y == 0)
        {
            animator.SetTrigger("front");
        }
        else if(x <= -0.01f && y == 0)
        {
            animator.SetTrigger("back");
        }

        if(y >= 0.01f)
        {
            animator.SetTrigger("up");
        }
        else if(y <= -0.01f)
        {
            animator.SetTrigger("down");
        }
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * moveSpeed;

        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -29, 29);
        pos.y = Mathf.Clamp(pos.y, -15, 15);

        transform.position = pos;
    }
}
