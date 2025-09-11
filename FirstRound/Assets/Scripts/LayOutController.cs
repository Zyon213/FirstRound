using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayOutController : MonoBehaviour
{
    [Header("PUBLIC VARIABLES")]
    public GameObject layoutCanvas;
    public GameObject gameCanvas;

//    [Header("PRIVATE VARIABLES")]
    void Start()
    {
        layoutCanvas.SetActive(true);
        gameCanvas.SetActive(false);
    }

    // on layout button click disable the layout page and enable the game page
    // and initialize call InitializeItems method to initialize the itemcounts and others methods
    public void LayoutOne()
    {
        UpdatePage(6);
    }
    public void LayoutTwo()
    {
        UpdatePage(12);
    }
    public void LayoutThree()
    {
        UpdatePage(20);
    }
    public void LayoutFour()
    {
        UpdatePage(30);
    }

    private void UpdatePage(int count)
    {
        GameManager.Instance.itemCount = count;
        gameCanvas.SetActive(true);
        layoutCanvas.SetActive(false);
        gameCanvas.GetComponentInChildren<UIGridController>().InitializeItems();
        GameManager.Instance.winPoint = count / 2;
    }
}
