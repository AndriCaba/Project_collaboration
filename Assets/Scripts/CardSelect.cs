using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardSelect : MonoBehaviour
{
    public Transform highlight;
    public Transform selection;
    public RaycastHit raycastHit;
    public LayerMask selectableObjectsLayer;

    void Update()
    {
        HandleHighlighting();
        HandleSelection();
    }

    void HandleHighlighting()
    {

        if (highlight != null && highlight != selection)
        {

            DisableOutline(highlight);
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {

            highlight = raycastHit.transform;

            if (highlight.CompareTag("Card") && highlight != selection)
            {

                HandleHighlightObject(highlight);
            }
            else if (!highlight.CompareTag("Card"))
            {


                highlight = null;
            }
        }
    }

    void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to select
        {
            if (highlight)
            {
                HandleSelectObject(highlight);
            }
        }
        else if (Input.GetMouseButtonDown(1)) // Right-click to stop highlighting
        {
            HandleDeselectObject();
        }
    }

    void HandleHighlightObject(Transform objToHighlight)
    {

        Outline outline = objToHighlight.GetComponent<Outline>();
        if (outline == null)
        {
            outline = objToHighlight.gameObject.AddComponent<Outline>();
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 7.0f;
        }
        outline.enabled = true;
    }

    void HandleSelectObject(Transform objToSelect)
    {
        if (selection != null && selection != objToSelect)
        {
            DisableOutline(selection);
        }
        selection = objToSelect;
        HandleHighlightObject(selection);
    }

    void HandleDeselectObject()
    {
        if (highlight)
        {
            DisableOutline(highlight);
            highlight = null;
        }
        if (selection)
        {
            DisableOutline(selection);
            selection = null;
        }
    }

    void DisableOutline(Transform obj)
    {
        Outline outline = obj.GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}
