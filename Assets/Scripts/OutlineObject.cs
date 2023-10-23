using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineInteraction : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
   

    void Update()
    {
        HandleHighlighting();
        HandleSelection();
    }

    void HandleHighlighting()
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection)
            {
                HandleHighlightObject(highlight);
            }
            else
            {
                highlight = null;
            }
        }
    }

    void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (highlight)
            {
                HandleSelectObject(highlight);
            }
            
        }
        if (Input.GetMouseButtonDown(1))
        {

            HandleDeselectObject();

        }
    }

    void HandleHighlightObject(Transform objToHighlight)
    {
        if (objToHighlight.gameObject.GetComponent<Outline>() != null)
        {
            objToHighlight.gameObject.GetComponent<Outline>().enabled = true;
        }
        else
        {
            Outline outline = objToHighlight.gameObject.AddComponent<Outline>();
            outline.enabled = true;
            outline.OutlineColor = Color.white;
            outline.OutlineWidth = 7.0f;
        }
    }

    void HandleSelectObject(Transform objToSelect)
    {
        if (selection != null)
        {
            selection.gameObject.GetComponent<Outline>().enabled = false;
        }
        selection = objToSelect;
        HandleHighlightObject(selection);
        highlight = null;
    }

    void HandleDeselectObject()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            selection.gameObject.GetComponent<Outline>().enabled = false;
            selection = null;
        }
    }
}
