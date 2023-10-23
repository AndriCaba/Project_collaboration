using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



using UnityEngine.UI;
public class InteractableObject : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DraggableImage draggableImage = eventData.pointerDrag.GetComponent<DraggableImage>();
        if (draggableImage != null)
        {
            // Perform the interaction or behavior when the image is dropped on the object.
            Debug.Log("Image dropped on object.");
        }
    }
}
