using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    bool m_isCursor = false;
    [SerializeField] string m_loadLevels;
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
