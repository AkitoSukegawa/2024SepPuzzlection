using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>���E�ړ������</summary>
    [SerializeField] float m_movePower = 5f;
    /// <summary>�W�����v�����</summary>
    [SerializeField] float m_jumpPower = 15f;
    Rigidbody2D m_rb = default;
    SpriteRenderer m_sprite = default;
    Animator m_anim = default;
    /// <summary>���������̓��͒l</summary>
    float m_h;
    /// <summary>�ŏ��ɏo���������W</summary>
    Vector3 m_initialPosition;

    /// <summary>�ڒn�t���O</summary>
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
        // ���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        // �e����͂��󂯎��
        if (canJump && Input.GetButtonDown("Jump"))
        {
            Debug.Log("�����ɃW�����v���鏈���������B");
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpPower);
            canJump = !checkGround;
        }

        // ���ɍs���������珉���ʒu�ɖ߂�
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }
    }

    private void FixedUpdate()
    {
        // �͂�������̂� FixedUpdate �ōs��
        m_rb.velocity = new Vector2 (m_h * m_movePower , m_rb.velocity.y);

        // �A�j���[�V�����𐧌䂷��
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
