using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JewelController : MonoBehaviour
{
    SpriteRenderer m_sr;

    [SerializeField] string m_jewelLevels;
    private void Start()
    {
        m_sr = GetComponent<SpriteRenderer>();
        transform.DOLocalMove(new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuart);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Get");
            m_sr.DOFade(endValue: 0f, duration: 0.7f).SetEase(Ease.Linear).OnComplete(JewelGet);
        }
    }
    private void JewelGet()
    {
        PlayerPrefs.SetInt(m_jewelLevels, 1);
        m_sr.DOFade(endValue: 0f, duration: 0.1f).SetEase(Ease.Linear).OnComplete(GKill);
    }
    private void GKill()
    {
        m_sr.DOKill();
        transform.DOKill();
        Invoke("DKill",0.1f);
    }
    private void DKill()
    {
        Destroy(this.gameObject);
    }
}
