using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] Sprite[] m_switchS;
    SpriteRenderer m_sr;
    BoxCollider2D m_boxCollider;
    bool m_pushed = false;
    private void Start()
    {
        m_sr = GetComponent<SpriteRenderer>();
        m_sr.sprite = m_switchS[0];
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!m_pushed)
        {
            DestroyChildAll(this.transform);
            m_sr.sprite = m_switchS[1];
            m_pushed = true;
        }
    }
    private void DestroyChildAll(Transform root)
    {
        //�����̎q����S�Ē��ׂ�
        foreach (Transform child in root)
        {
            //�����̎q����Destroy����
            Destroy(child.gameObject);
        }
    }
}
