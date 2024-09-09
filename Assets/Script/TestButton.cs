using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestButton : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] SceneController m_sc;

    public System.Action onClickCallback;
    // タップ  
    public void OnPointerClick(PointerEventData eventData) { onClickCallback?.Invoke(); }
    // タップダウン  
    public void OnPointerDown(PointerEventData eventData) { m_sc.GoTitle(); }
    // タップアップ  
    public void OnPointerUp(PointerEventData eventData) { m_sc.GoTitle(); }
}
