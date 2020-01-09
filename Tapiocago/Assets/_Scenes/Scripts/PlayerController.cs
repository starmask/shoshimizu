using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20; // 動く速さ
    public float jumpPower = 10.0f;     // ジャンプ力

    private Rigidbody rb; // Rididbody

    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var ray = new Ray(this.transform.position, Vector3.down);
        if (Input.GetButton("Jump") && Physics.Raycast(ray, 0.8f))
        {
            rb.AddForce(new Vector3(0.0f, jumpPower, 0.0f));
        }

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);
    }
    
}
