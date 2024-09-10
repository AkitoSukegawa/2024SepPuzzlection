using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoTitle() => SceneManager.LoadScene("Title");
    public void GoChooseLevel() => SceneManager.LoadScene("ChooseLevels");

    public void SceneReload() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

}
