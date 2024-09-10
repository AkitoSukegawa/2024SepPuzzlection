using DG.Tweening;
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

    /// <summary>接地フラグ</summary>
    bool m_isGrounded = false;

    //if the object collides with another object tagged as this, it can jump again
    public string groundTag = "ground";

    //this determines if the script has to check for when the player touches the ground to enable him to jump again
    //if not, the player can jump even while in the air
    public bool checkGround = true;

    Transform m_ctr = null;
    private bool canJump = true;
    bool m_clearFlug = false;
    [SerializeField] StageFade m_sf;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!m_clearFlug)
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
        }

    }

    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.velocity = new Vector2(m_h * m_movePower, m_rb.velocity.y);
    }

    private void LateUpdate()
    {
        // アニメーションを制御する
        if (m_anim)
        {
            m_anim.SetFloat("SpeedX", Mathf.Abs(m_rb.velocity.x));
            m_anim.SetBool("IsGrounded", m_isGrounded);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
        if (!canJump)
        {
            m_isGrounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (checkGround && collision.gameObject.CompareTag(groundTag))
        {
            canJump = true;
            m_isGrounded = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            m_clearFlug = true;
            m_ctr = collision.transform;
            m_rb.velocity = Vector2.zero;
            m_h = 0f;
            ClearMove();
        }
    }
    private void ClearMove()
    {
        DOTween.Sequence()
            .Append(transform.DOLocalMove(m_ctr.position, 0.3f).SetEase(Ease.Linear))
            .Append(m_sprite.DOFade(endValue: 0f, duration: 0.5f).SetEase(Ease.Linear).OnComplete(m_sf.ClearFadeIn));
    }
}
