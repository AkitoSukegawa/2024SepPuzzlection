using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestButton : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] SceneController m_sc;

    public System.Action onClickCallback;
    // �^�b�v  
    public void OnPointerClick(PointerEventData eventData) { onClickCallback?.Invoke(); }
    // �^�b�v�_�E��  
    public void OnPointerDown(PointerEventData eventData) { m_sc.GoTitle(); }
    // �^�b�v�A�b�v  
    public void OnPointerUp(PointerEventData eventData) { m_sc.GoTitle(); }
}
