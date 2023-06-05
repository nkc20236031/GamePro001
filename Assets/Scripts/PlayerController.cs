using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float xPos, yPos;
    [SerializeField] private float moveSpeed;                     //スピード
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //カーソルに向きを合わせる
        Vector3 mousePos = Camera.main.WorldToScreenPoint(transform.localPosition);
        transform.localRotation = Quaternion.LookRotation(Vector3.forward, Input.mousePosition - mousePos);

        //プレイヤーアニメーション
        if(x == 0 && y == 0) {
            animator.SetTrigger("front");
        } else if(x >= 0 && y >= 0) {
            animator.SetTrigger("up");
        } else if (x <= 0 && y <= 0) {
            animator.SetTrigger("down");
        }
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * moveSpeed;

        //移動範囲
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xPos, xPos);
        pos.y = Mathf.Clamp(pos.y, -yPos, yPos);
        transform.position = pos;
    }
}
