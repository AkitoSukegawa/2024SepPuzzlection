using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StageFade : MonoBehaviour
{
    [SerializeField] SceneController m_sc;
    SpriteRenderer m_sr;
    // Start is called before the first frame update
    void Start()
    {
        m_sr = GetComponent<SpriteRenderer>();
        m_sr.DOFade(endValue: 0f, duration: 1f).SetEase(Ease.Linear);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FadeIn();
        }
    }
    void FadeIn()
    {
        m_sr.DOKill();
        m_sr.DOFade(endValue: 1.5f, duration: 1.5f).SetEase(Ease.Linear).OnComplete(m_sc.SceneReload);
    }
    public void ClearFadeIn()
    {

        m_sr.DOKill();
        m_sr.DOFade(endValue: 1.5f, duration: 1.5f).SetEase(Ease.Linear).OnComplete(m_sc.GoChooseLevel);
    }
}
