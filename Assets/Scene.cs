using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    [SerializeField] private GameObject[] scenes;
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
        scenes[0].SetActive(true);
        scenes[1].SetActive(false);
        scenes[2].SetActive(true);
    }

    public void Back()
    {
        scenes[0].SetActive(false);
        scenes[1].SetActive(true);
        scenes[2].SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        scenes[0].SetActive(true);
        scenes[1].SetActive(false);
        scenes[2].SetActive(false);
    }
}
