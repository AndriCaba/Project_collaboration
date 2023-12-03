using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasswitch : MonoBehaviour
{
    public GameObject NextPage;
    public GameObject PreviousPages;



    public void EnableObject()
    {
        // Enable the targetObject
        if (NextPage != null)
        {
            NextPage.SetActive(true);
        }
        if (PreviousPages != null)
        {
            PreviousPages.SetActive(true);
        }
    }

    public void DisableObject()
    {
        // Disable the targetObject
        if (NextPage != null)
        {
            NextPage.SetActive(false);
        }
        if (PreviousPages != null)
        {
            PreviousPages.SetActive(false);
        }
    }
}
