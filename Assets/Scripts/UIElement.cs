using UnityEngine;

public class UIElement : MonoBehaviour
{
    [SerializeField]
    private GameObject associatedUIElement; // Reference to the UI element you want to show/hide

    public GameObject AssociatedUIElement
    {
        get { return associatedUIElement; }
    }
}
