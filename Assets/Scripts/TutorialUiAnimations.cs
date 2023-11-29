using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUiAnimations : MonoBehaviour
{
    public Animator Phase1, Panel, Phase2, Phase3, Phase4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerAnimations1()
    {
        Phase1.SetTrigger("Click");
        Panel.SetTrigger("FADE");
        Phase2.SetTrigger("SlideIn");
    }
    public void TriggerAnimations2()
    {
        Phase2.SetTrigger("Clicked");
        Phase3.SetTrigger("SlideIn");
    }
    public void TriggerAnimations3()
    {
        Phase3.SetTrigger("Clicked");
        Phase4.SetTrigger("SlideIn");
    }
    public void TriggerAnimations4()
    {
        Phase4.SetTrigger("Clicked");
        //Phase4.SetTrigger("SlideIn");
    }
}
