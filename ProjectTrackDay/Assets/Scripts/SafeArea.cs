using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeArea : MonoBehaviour
{
    RectTransform rectTransform;
    Rect safeArea;
    Vector2 MinAnchor;
    Vector2 MaxAnchor;

    void Awake() {
        rectTransform = GetComponent<RectTransform>();
        safeArea = Screen.safeArea;
        MinAnchor = safeArea.position;
        MaxAnchor = MinAnchor + safeArea.size;
        
        MinAnchor.x /= Screen.width;
        MinAnchor.y /= Screen.height;
        MaxAnchor.x /= Screen.width;
        MaxAnchor.y /= Screen.height;

        rectTransform.anchorMin = MinAnchor;
        rectTransform.anchorMax = MaxAnchor;
    }
}
