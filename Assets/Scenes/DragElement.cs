using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragElement : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    
    private Vector2 lastMousePosition;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        lastMousePosition = eventData.position;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentMousePosition = eventData.position;
        Vector2 diff = currentMousePosition - lastMousePosition;
        RectTransform rect = GetComponent<RectTransform>();
 
        Vector3 newPosition = rect.position +  new Vector3(diff.x, diff.y, transform.position.z);
        rect.position = newPosition;
        lastMousePosition = currentMousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
    }
}
