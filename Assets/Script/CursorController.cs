using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    Vector3 m_mousePos;
    Vector3 m_pos;
    // Update is called once per frame
    void Update()
    {
        m_mousePos = Input.mousePosition ;
        m_pos = Camera.main.ScreenToWorldPoint(new Vector3(m_mousePos.x , m_mousePos.y , 10f));
        this.transform.position = m_pos;
    }
}
