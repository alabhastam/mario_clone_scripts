//not used

using UnityEngine;

public class LockUIPosition : MonoBehaviour
{
    public RectTransform lifeTextRect; 
    public RectTransform coinTextRect; 
    public Vector2 lifeTextAnchorPosition; 
    public Vector2 coinTextAnchorPosition; 

    void Start()
    {
        lifeTextRect.anchoredPosition = lifeTextAnchorPosition;

        coinTextRect.anchoredPosition = coinTextAnchorPosition;
    }
}
