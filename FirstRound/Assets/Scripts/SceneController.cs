using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /*
    [Header("PUBLIC VARIABLES")]
    public GameObject pausePage;
    public GameObject gameOverPage;
    public GameObject winPage;

    [Header("PRIVATE VARIABLES")]
    private int attempts = 5;
    private void Start()
    {
        pausePage.gameObject.SetActive(false);
        gameOverPage.gameObject.SetActive(false);
        winPage.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (GameManager.Instance.numberOfAttempts > attempts)
        {
            gameOverPage.gameObject.SetActive(true);
            GameManager.Instance.numberOfAttempts = 0;

        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        pausePage.gameObject.SetActive(true);       
    }

    public void ResumeGame()
    {
        Time.timeScale += 1.0f;
        pausePage.gameObject.SetActive(false);

    }

    public void WinPage()
    {
        WinPage.gameObject.SetActive(true);
    }
    public void HomePage()
    {
        SceneManager.LoadScene("StartPage", LoadSceneMode.Single);
    }
*/

    public void StartGame()
    {
        SceneManager.LoadScene("Scene01");
    }

}
