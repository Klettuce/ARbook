using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadBook(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
