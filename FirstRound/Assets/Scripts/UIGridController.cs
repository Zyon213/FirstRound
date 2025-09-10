using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGridController : MonoBehaviour
{
    [Header("PUBLIC VARIABLES")]
    public GridLayoutGroup gridLayout;
    public List<GameObject> uiItemPrefabs;
    public int itemCount = 8;

    [Header("PRIVATE VARIABLES")]
    private Image image;
    private List<int> indexValue = new List<int>();
//    private int index;
    private void Start()
    {
        // get image and gridlayout group components
        image = GetComponent<Image>();
        if (gridLayout == null)
            gridLayout = GetComponent<GridLayoutGroup>();
        RandomizeList(itemCount);
        ArrangeRectLayout(itemCount);
    }

    // create a randomized list using shuffle 
    private void RandomizeList(int count)
    {
        for (int i = 0; i < count; i++)
        {
            indexValue.Add(i);
        }
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
        float imageSize = (width / cols) - (2 * xSPacing);

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

}
