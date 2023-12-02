using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCUIAnimations : MonoBehaviour
{
    public Animator NPC_BG, NPC_Page1, NPC_NextButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextButtonClick()
    {
        NPC_NextButton.SetTrigger("OnClick");
        NPC_Page1.SetTrigger("OnClick");
    }
}
