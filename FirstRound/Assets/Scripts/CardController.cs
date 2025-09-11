using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    [Header("PUBLIC VARIALBES")]
    public Image frontImage;
    public Image backImage;

    private void Start()
    {
        frontImage = GetComponent<Image>();
        frontImage.rectTransform.sizeDelta = new Vector2(200, 200);
    }
    // uisng onpointerclick method access the image that is clicked from the pointerEventData
    // and can access the game object using pointer currentRaycast but you must enable the raycast
    // on the image.
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.numberOfClicks >= 2)
            return;

        // get the gameobject from the eventData
        GameObject imageObject = eventData.pointerCurrentRaycast.gameObject;
        if (imageObject != null )
        {
            // check if the backImage tack is cardback add the tag of the front image into the
            // tags list for comparision.
            if (backImage != null && backImage.CompareTag("CardBack"))
            {
                backImage.enabled = false;
                GameManager.Instance.tags.Add(frontImage.gameObject.tag);
                ++GameManager.Instance.numberOfClicks;
                if (GameManager.Instance.numberOfClicks == 2)
                {
                    StartCoroutine(GameManager.Instance.CheckMatch());
                }
            }
        }
    }
}
