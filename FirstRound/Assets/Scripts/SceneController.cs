using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("LayoutPage");
    }

    public void LayoutOne(int count)
    {
        SceneManager.LoadScene("Scene01");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
