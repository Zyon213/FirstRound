using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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

    [Header("PRIVATE VARIABLES")]
    private float delay = 1.0f;
    private void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
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
            Debug.Log(numberOfMatches);
        }
        else
        {
            foreach (var card in FindObjectsOfType<CardController>())
            {
                if (!card.backImage.enabled)
                    card.backImage.enabled = true;
            }
            ++numberOfAttempts;
            Debug.Log(numberOfAttempts);
        }
        tags.Clear();
        numberOfClicks = 0;
    }

}
