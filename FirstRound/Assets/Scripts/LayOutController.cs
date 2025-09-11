using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayOutController : MonoBehaviour
{
    [Header("PUBLIC VARIABLES")]
    public GameObject layoutCanvas;
    public GameObject gameCanvas;

    [Header("PRIVATE VARIABLES")]
    private Button button;
    void Start()
    {
        layoutCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);
    }

    public void LayoutOne()
    {
        GameManager.Instance.itemCount = 6;
        gameCanvas.gameObject.SetActive(true);
        layoutCanvas.gameObject.SetActive(false);
    }
    public void LayoutTwo()
    {
        GameManager.Instance.itemCount = 12;
        gameCanvas.gameObject.SetActive(true);
        layoutCanvas.gameObject.SetActive(false);
    }
    public void LayoutThree()
    {
        GameManager.Instance.itemCount = 20;
        gameCanvas.gameObject.SetActive(true);
        layoutCanvas.gameObject.SetActive(false);
    }
    public void LayoutFour()
    {
        GameManager.Instance.itemCount = 30;
        gameCanvas.gameObject.SetActive(true);
        layoutCanvas.gameObject.SetActive(false);
    }
}
