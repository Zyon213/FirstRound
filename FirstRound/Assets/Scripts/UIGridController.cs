using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UIGridController : MonoBehaviour 
{
    [Header("PUBLIC VARIABLES")]
    public GridLayoutGroup gridLayout;
    public List<GameObject> uiItemPrefabs;
 

    [Header("PRIVATE VARIABLES")]
    private float imageSize;
    private Image image;
    private List<int> indexValue = new();
    private int itemCount;
    private float revealDelay = 1.0f;

    private int halfItem;
//    private int index;
    private void Start()
    {
        // get image and gridlayout group components
        image = GetComponent<Image>();
        if (gridLayout == null)
            gridLayout = GetComponent<GridLayoutGroup>();
    }

    public void InitializeItems()
    {
        itemCount = GameManager.Instance.itemCount;
        halfItem = itemCount / 2;
  
        ReapeatList(halfItem);
        RandomizeList(itemCount);
        ArrangeRectLayout(itemCount);
        StartCoroutine(RevealImages());
        HideImages();
    }
    // fill the index twice on the list to complete the full capacity
    private void ReapeatList(int count)
    {
        indexValue.Capacity = 2 * count;
        for (int i = 0; i < count; i++)
        {
            indexValue.Add(i);
            indexValue.Add(i);
        }
    }
    // create a randomized list using shuffle 
    private void RandomizeList(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int temp = indexValue[i];
            int item = Random.Range(i, count);
            indexValue[i] = indexValue[item];
            indexValue[item] = temp;
        }
    }
    public void ArrangeRectLayout(int count)
    {


        // get the columns of the rectangle from the item count
        int cols = Mathf.CeilToInt(Mathf.Sqrt(count));
        //     int rows = Mathf.CeilToInt((float)count / cols);

        // get the width of the image
        float width = image.rectTransform.rect.width;

        // get the spacing of the gridlayout
        float xSPacing = gridLayout.spacing.x;

        // calculate the size of the cell 
        imageSize = (width / cols) - (2 * xSPacing);


        // set the cell size 
        gridLayout.cellSize = new Vector2(imageSize, imageSize);

        // create rectangle with a fixed column

        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = cols;

        // put the images in side the grid
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(uiItemPrefabs[indexValue[i]], gridLayout.transform);
            RectTransform rect = go.GetComponent<RectTransform>();
            rect.localScale = Vector3.one;
        }
    } 

    // reveal the images for 1 second 
    IEnumerator RevealImages()
    {
        yield return new WaitForSeconds(revealDelay);
        foreach (var card in FindObjectsOfType<CardController>())
        {
            if (card.backImage.enabled == false)
            {
                card.backImage.enabled = true;
            }
        }
    }
   // hide the images with back image
    public void HideImages()
    { 
        foreach (var card in FindObjectsOfType<CardController>())
        {
            if (card.backImage.enabled == true)
            {
                card.backImage.enabled = false;
            }
        }
    }
}
