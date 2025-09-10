using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    [Header("PUBLIC VARIALBES")]
    public Image frontImage;
    private float flipDelay = 2.0f;

    [Header("PRIVATE VARIABLES")]
    private bool isClicked;
    private Image backImage;
    private void Start()
    {
        frontImage = GetComponent<Image>();
     //   backImage = GetComponent<Image>();
    }
    public void OnPointerClick(PointerEventData eventData)
    { 
        
        GameObject imageObject = eventData.pointerCurrentRaycast.gameObject;
        if (imageObject != null && !isClicked)
        {
            Debug.Log(++GameManager.Instance.numberOfImages);
            isClicked = true;
            backImage = imageObject.GetComponentInChildren<Image>();
         //   frontImage = imageObject.GetComponentInChildren<Image>();
            Debug.Log(frontImage.name);
            if (backImage != null && backImage.CompareTag("CardBack"))
            {
                backImage.enabled = false;
                if (frontImage.CompareTag("Beaver"))
                {
                    Debug.Log("Success");
                }
                else
                    StartCoroutine(FlipCardDelay(flipDelay));

            }
        }
    }

    IEnumerator FlipCardDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        backImage.enabled = true;
        isClicked = false;
    }
}
