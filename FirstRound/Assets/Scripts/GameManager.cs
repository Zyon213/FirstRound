using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header ("PUBLIC VARIABLES")]
    public static GameManager Instance;
    public int numberOfImages = 0;
    public bool isClicked = false;
    public int numberOfClicks = 0;
    public int numberOfMatches = 0;
    public int numberOfAttempts = 0;
    public List<string> tags = new();
    public int itemCount;
    public Text match;
    public Text attempt;
    public GameObject pausePage;
    public GameObject gameOverPage;
    public GameObject winPage;
    public int winPoint;

    [Header("PRIVATE VARIABLES")]
    private float delay = 0.50f;
    // set this value to show the game over page functionality 
    // it will restrict the number of attempts for bigger itemcounts
    private int attempts = 10;


    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void ResetGame()
    {
        tags.Clear();
        isClicked = false;
        numberOfClicks = 0;
        numberOfMatches = 0;
        numberOfAttempts = 0;
        pausePage.gameObject.SetActive(false);
        gameOverPage.gameObject.SetActive(false);
        winPage.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (numberOfAttempts > attempts)
        {
            gameOverPage.gameObject.SetActive(true);
            numberOfAttempts = 0;
        }
        Debug.Log("winpoint " + winPoint  + " number of matches " + numberOfMatches);
        if (numberOfMatches > 0 && numberOfMatches == winPoint)
        {
            winPage.gameObject.SetActive(true);
            Debug.Log("winn");
        }
    }
    public IEnumerator CheckMatch()
    {
        yield return new WaitForSeconds(delay);

        // check only when 2 images are flipped if they match change the backImage sprite
        // to null and alpha to 0 . else enable the backImage to true .
        // clear the tags list 
        if (tags[0] == tags[1])
        {
            foreach (var card in FindObjectsOfType<CardController>())
            {
                if (!card.backImage.enabled)
                {
                    Color temp = card.backImage.color;
                    temp.a = 0.0f;
                    card.backImage.sprite = null;
                    card.backImage.color = temp ;
                }
            }
            ++numberOfMatches;

        }
        else
        {
            foreach (var card in FindObjectsOfType<CardController>())
            {
                if (!card.backImage.enabled)
                    card.backImage.enabled = true;
            }
            ++numberOfAttempts;
        }
        tags.Clear();
        UpdateScore();
        numberOfClicks = 0;
    }

    public void UpdateScore()
    {
        match.text = numberOfMatches.ToString();
        attempt.text = numberOfAttempts.ToString();
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
        winPage.gameObject.SetActive(true);
    }
    public void HomePage()
    {
        SceneManager.LoadScene("StartPage", LoadSceneMode.Single);
        ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
