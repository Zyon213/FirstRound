using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("PUBLIC VARIABLES")]
    public static GameManager Instance;
    public int numberOfImages = 0;
//    public bool isClicked = 0;
    public int numberOfClicked = 0;

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
}
