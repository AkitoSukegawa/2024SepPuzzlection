using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>左右移動する力</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>ジャンプする力</summary>
    [SerializeField] float m_jumpPower = 15f;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    Animator m_anim = default;
    /// <summary>水平方向の入力値</summary>
    float m_h;
    /// <summary>最初に出現した座標</summary>
    Vector3 m_initialPosition;

    /// <summary>接地フラグ</summary>
    bool m_isGrounded = false;

    //if the object collides with another object tagged as this, it can jump again
    public string groundTag = "ground";

    //this determines if the script has to check for when the player touches the ground to enable him to jump again
    //if not, the player can jump even while in the air
    public bool checkGround = true;

    private bool canJump = true;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        // 各種入力を受け取る
        if (canJump && Input.GetButtonDown("Jump"))
        {
            Debug.Log("ここにジャンプする処理を書く。");
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpPower);
            canJump = !checkGround;
        }

        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }
    }

    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.velocity = new Vector2 (m_h * m_movePower , m_rb.velocity.y);

        // アニメーションを制御する
        if (m_anim)
        {
            m_anim.SetFloat("SpeedX", Mathf.Abs(m_rb.velocity.x));
            m_anim.SetBool("IsGrounded", m_isGrounded);
        }
    }
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        if (checkGround
            && collisionData.gameObject.CompareTag(groundTag))
        {
            canJump = true;
            m_isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!canJump) 
        { 
            m_isGrounded = false;
        }
    }
}
