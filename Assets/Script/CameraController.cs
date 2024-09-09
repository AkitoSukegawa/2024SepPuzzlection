using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject m_gameCamera;
    Vector3 m_cameraPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        m_cameraPosition = m_gameCamera.transform.position;
    }

    public void CameraRightScroll()
    {
        if (m_cameraPosition.x < 100)
        {
            m_cameraPosition.x += 20;
            m_gameCamera.transform.DOLocalMove(m_cameraPosition, 0.7f).SetEase(Ease.InOutQuart);
        }
    }
    public void CameraLeftScroll()
    {
        if (m_cameraPosition.x > 0)
        {
            m_cameraPosition.x -= 20;
            m_gameCamera.transform.DOLocalMove(m_cameraPosition, 0.7f).SetEase(Ease.InOutQuart);
        }
    }
}
