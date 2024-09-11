using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    bool m_isCursor = false;
    [SerializeField] string m_loadLevels;

    [SerializeField] Sprite[] m_spIcon;
    SpriteRenderer m_sr;

    int m_isClear;

    private void Start()
    {
        m_isClear = PlayerPrefs.GetInt(m_loadLevels);
        m_sr = GetComponent<SpriteRenderer>();
        m_sr.sprite = m_spIcon[m_isClear];
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_isCursor) 
            { 
                SceneManager.LoadScene(m_loadLevels);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cursor"))
        {
            m_isCursor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("cursor"))
        {
            m_isCursor = false;
        }
    }
}
