using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSizeCalculator : MonoBehaviour
{
    public GridLayoutGroup gridLayout;
    public RectTransform rectTransform;
    private void Start()
    {
        float cellWidth = Screen.width / 5f; 
        float cellHeight = Screen.height / 5f; 
       
        float size = Mathf.Min(cellWidth, cellHeight);
        gridLayout.cellSize = new Vector2(size, size);
        
        float newRightValue = Screen.height *0.7f;
        Vector2 offsetMax = rectTransform.offsetMax;
        offsetMax.x = newRightValue;
        rectTransform.offsetMax = offsetMax;
    }
}
