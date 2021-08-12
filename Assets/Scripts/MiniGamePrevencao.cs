using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGamePrevencao : MonoBehaviour
{
    public GameObject buttonDisable;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void Vitoria()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -3);
    }

    public void FakeNews()
    {
        buttonDisable.SetActive (false);
    }
}

