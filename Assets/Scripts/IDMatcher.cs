using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
public class IDMatcher : MonoBehaviour
{
    public Button buttonToMatch;
    public  ObjectSelection objectToMatch;
    public CardSelection cardToMatch;

    private void Start()
    {
        // Add a listener to the button click event
        buttonToMatch.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        // Check if both objects are assigned
        if (objectToMatch != null && cardToMatch != null)
        {
            // Check if the ids match
            if (objectToMatch.objectID == cardToMatch.CardID)
            {
                Debug.Log("Match Found!");
                PlayerAttack attack = GetComponent<PlayerAttack>();
                objectToMatch = null;
                
                if (attack != null)
                {
                    attack.Attack();
                }

            }
            else
            {
                Debug.Log("No Match Found. Try Again!");
                // Reset the references to allow for a new attempt
                objectToMatch = null;
               
            }
        }
        else
        {
            Debug.LogWarning("Objects not assigned. Please assign objects before clicking the button.");
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            ObjectSelection clickedObject = hit.collider.GetComponent<ObjectSelection>();
            
            if (clickedObject != null)
            {
                AssignObjectToMatch(clickedObject);
            }
        
        }
    }

    private void AssignObjectToMatch(ObjectSelection obj)
    {
        // Assign the object clicked by the player
        objectToMatch = obj;
    }

 /*   private void AssignCardToMatch(CardSelection card)
    {
        // Assign the card clicked by the player
        cardToMatch = card;
    }*/
    /*
        void startmatch()
        {
            Debug.Log("Start match ");



            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits any collider
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the collider belongs to the clicked object
                if (hit.collider.gameObject == gameObject)
                {
                    // Do something when the object is clicked

                    GameObject otherGameObject = GameObject.FindWithTag("Selectable");


                    if (otherGameObject != null)
                    {

                        ObjectSelection ID = GetComponent<ObjectSelection>();

                        if (ID != null)
                        {



                            Debug.Log("Match found!" + ID);



                        }
                        else
                        {
                            Debug.LogWarning("Object or Card not assigned.");
                        }
                    }


                }
            }
        }


        void StartsCheck()
        {
            Debug.Log("Start");
            GameObject otherGameObject = GameObject.FindWithTag("Selectable");

            if (otherGameObject != null)
            {

                objectToMatch = gameObject.GetComponent<ObjectSelection>();

                if (objectToMatch.objectID != null)
                {


                    if (objectToMatch != null && cardToMatch != null)
                    {
                        if (objectToMatch.objectID == cardToMatch.CardID)
                        {
                            // Object ID matches Card ID, do something
                            Debug.Log(cardToMatch.CardID + "Match found!" + objectToMatch.objectID);
                        }
                        else
                        {
                            Debug.Log("No match.");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Object or Card not assigned.");
                    }
                }
                else
                {
                    Debug.LogWarning("Object or Card not ssssassigned.");

                }
            }
            else
            {
                Debug.LogError("Other GameObject not found by tag.");

            }
        }
    */
}

    



