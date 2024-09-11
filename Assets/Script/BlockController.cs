using DG.Tweening;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    Vector3 m_pos;

    int m_colCount = 0;
    Rigidbody2D m_rb;
    [SerializeField] int canIntrract = 1;
    private void Start()
    {
        m_pos = transform.position;
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hit");
        if (col.gameObject.tag != "Player")
        {
            Debug.Log("stop");
            transform.DOKill();
            m_colCount++;
        }
        else if (m_colCount <= canIntrract)
        {
            foreach (ContactPoint2D point in col.contacts)
            {
                Vector3 relativePoint = transform.InverseTransformPoint(point.point);

                if (relativePoint.x > 0.4)
                {
                    m_pos.x -= 0.5f;
                    this.transform.DOLocalMove(m_pos, 0.3f).SetEase(Ease.Linear);
                }


                else if (relativePoint.x < -0.4)
                {
                    m_pos.x += 0.5f;
                    this.transform.DOLocalMove(m_pos, 0.3f).SetEase(Ease.Linear);
                }

            }
        }

    }
}
