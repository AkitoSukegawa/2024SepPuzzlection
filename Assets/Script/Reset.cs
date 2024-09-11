using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("1-1", 0);
        PlayerPrefs.SetInt("1-2", 0);
    }
}
