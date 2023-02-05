using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ReturnGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
