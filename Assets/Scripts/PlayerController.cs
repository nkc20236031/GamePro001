using UnityEngine;

public class PlayerController : MonoBehaviour {
    Animator animator;
    public float moveSpeed;                     //スピード
    public float xPos;
    public float yPos;

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
        if (x >= 0 && y == 0) {                 //右
            //animator.SetTrigger("front");     //前進
            animator.SetTrigger("down");
        } else if(x < 0 && y == 0) {            //左
            //animator.SetTrigger("back");      //後退
            animator.SetTrigger("up");
        }
        if(y > 0) {
            animator.SetTrigger("up");          //上がる
        } else if(y < 0) {
            animator.SetTrigger("down");        //下がる
        }
        transform.position += new Vector3(x, y).normalized * Time.deltaTime * moveSpeed;

        //移動範囲
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xPos, xPos);
        pos.y = Mathf.Clamp(pos.y, -yPos, yPos);
        transform.position = pos;
    }
}
