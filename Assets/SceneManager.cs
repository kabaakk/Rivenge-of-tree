using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject scene, game;
    // Start is called before the first frame update
    void Start()
    {
        scene.SetActive(true);
        game.SetActive(false);
    }

    public void NewGame()
    {
        scene.SetActive(false);
        game.SetActive(true);
    }

    public void Options()
    {
        Debug.Log("Options system");
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
