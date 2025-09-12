using System;
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
    public Text highScoreText;
    public GameObject pausePage;
    public GameObject gameOverPage;
    public GameObject winPage;
    public int winPoint;

    [Header("PRIVATE VARIABLES")]
    private float delay = 0.50f;
 //   private DataController dataController;
    private SaveManager saveManager;
    public int highScore = 0;

    // set this value to show the game over page functionality 
    // it will restrict the number of attempts for bigger itemcounts
    private int attempts = 10;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);


        saveManager = FindObjectOfType<SaveManager>();
        if (saveManager == null)
            Debug.Log("data controller not found");

        LoadHighScore();
        ShowHighScore();

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
        if (numberOfMatches > 0 && numberOfMatches == winPoint)
        {
            winPage.gameObject.SetActive(true);
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
            ++highScore;

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

    public void ShowHighScore()
    {
        highScoreText.text = highScore.ToString();
    }

    public void SaveHighScore()
    {
        DataController data = new DataController();
        if (this.highScore > data.highScore)
        {
            data.highScore = this.highScore;
        }
        saveManager.SaveGame(data);
     //   this.highScore = 0;
    }

    public void LoadHighScore()
    {
        DataController data = saveManager.LoadGame();
        if (data != null)
            this.highScore = data.highScore;
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
        LoadHighScore();
        SceneManager.LoadScene("StartPage", LoadSceneMode.Single);
        numberOfMatches = 0;
        numberOfAttempts = 0;
    }

    public void QuitGame()
    {
        SaveHighScore();
        Application.Quit();
    }

}
